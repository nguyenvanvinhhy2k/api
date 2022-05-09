using Backend.Entities;
using Backend.Service.Repository;
using Backend.ViewModel.Cart;
using Backend.ViewModel.Common;
using Backend.ViewModel.StatisticalOrder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class OrderRepostiroy : IOrderRepostiroy
    {
        private readonly ShopDbContext _db;

        public OrderRepostiroy(ShopDbContext db)
        {
            _db = db;
        }   
        public async Task<int> CreateOrder(OrderCreateVM model)
        {
            var order = new Order();
            order.CustomerID = model.CustomerID;
            order.CustemerName = model.CustemerName;
            order.CustemerAddress = model.CustemerAddress;
            order.CreateDate = DateTime.Now;
            order.CustemerPhone = model.CustemerPhone;
            order.Status = OrderStatus.InProgress;
            _db.orders.Add(order);
            await _db.SaveChangesAsync();
            return order.ID;
        }

        public async Task<bool> CreateOrderDetail(OrderDetailCreateVM model)
        {
            var orderDetail = new OrderDetail();
            orderDetail.ProductID = model.ProductID;
            orderDetail.OrderID = model.OrderID;
            orderDetail.Price = model.Price;
            orderDetail.CreateDate = DateTime.Now;
            orderDetail.Quantity = model.Quantity;
            orderDetail.Image = model.Image;
            _db.orderDetails.Add(orderDetail);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<PageResult<OrderVM>> getAllPageing(OrderRequest model)
        {
            var query = from o in _db.orders where(o.Status!=(OrderStatus)3 && o.Status!=(OrderStatus)4) select o;
            if (!string.IsNullOrEmpty(model.keyWord))
            {
                query = query.Where(x => x.CustemerName.Contains(model.keyWord));
            }
            
            var totoReccord = await query.CountAsync();
            var result = query.Skip((model.pageIndex - 1) * model.pageSize).Take(model.pageSize)
                .Select(x => new OrderVM()
                {
                    ID = x.ID,
                    CustemerName = x.CustemerName,
                    CreateDate = x.CreateDate,
                    CustemerAddress = x.CustemerAddress,
                    CustemerPhone = x.CustemerPhone,
                    Status = x.Status
                }).OrderByDescending(x => x.CreateDate).ToList();
            var pageresult = new PageResult<OrderVM>()
            {
                items = result,
                pageIndex = model.pageIndex,
                pageSize = model.pageSize,
                totalRecord = totoReccord
            };
            return pageresult;
        }

        public Task<List<OrderDetailVM>> GetByID(int ID)
        {
            var orderDetail = from o in _db.orders
                              join dt in _db.orderDetails on o.ID equals dt.OrderID
                              join p in _db.products on dt.ProductID equals p.ID
                              where (o.ID == ID)
                              select new { o, dt, p };
            var result = orderDetail.Select(x => new OrderDetailVM()
            {
                ID = x.dt.ID,
                Image = x.dt.Image,
                Price = x.dt.Price,
                ProductName = x.p.Name,
                Quantity = x.dt.Quantity
            }).ToListAsync();
            return result;
        }

        public async Task<PageResult<OrderVM>> OrderSuccess(OrderRequest model)
        {
            var query = from o in _db.orders
                        
                        where (o.Status == (OrderStatus)3 && o.Status != (OrderStatus)4) select new { o};
            if (!string.IsNullOrEmpty(model.keyWord))
            {
                query = query.Where(x => x.o.CustemerName.Contains(model.keyWord));
            }

            var totoReccord = await query.CountAsync();
            var result = query.Skip((model.pageIndex - 1) * model.pageSize).Take(model.pageSize)
                .Select(x => new OrderVM()
                {
                    ID = x.o.ID,
                    CustemerName = x.o.CustemerName,
                    CreateDate = x.o.CreateDate,
                    CustemerAddress = x.o.CustemerAddress,
                    CustemerPhone = x.o.CustemerPhone,
                    Status = x.o.Status,
                }).ToList();
            var pageresult = new PageResult<OrderVM>()
            {
                items = result,
                pageIndex = model.pageIndex,
                pageSize = model.pageSize,
                totalRecord = totoReccord
            };
            return pageresult;
        }

        public async Task<object> Statistical()
        {
            // Lấy ra danh sách hàng
            var orders = from o in _db.orders 
                               join od in _db.orderDetails on o.ID equals od.OrderID
                               join p in _db.products on od.ProductID equals p.ID
                               select new { o,od,p };
            var order = from o in _db.orders select o;
            var totalrevenue = await orders.SumAsync(x => x.od.Quantity * x.od.Price);
            var profit = await (orders.SumAsync(x => x.od.Quantity * x.od.Price)) - (orders.Sum(x => x.od.Quantity * x.p.OriginalPrice));
            var ordernotprocessed = await order.CountAsync(x => x.Status == (OrderStatus)0 && x.Status != (OrderStatus)4);
            var ordersuccess = await order.CountAsync(x => x.Status == (OrderStatus)3 && x.Status != (OrderStatus)4);
            var result = new 
            {
                Totalrevenue=totalrevenue,
                Profit = profit,
                Ordernotprocessed = ordernotprocessed,
                Ordersuccess = ordersuccess
            };
            return result;
        }

        public async Task<bool> UpdateStatusOrder(UpdateOrderStatus model)
        {
            var order = await _db.orders.FindAsync(model.ID);
            order.Status = model.status;
            _db.orders.Update(order);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
