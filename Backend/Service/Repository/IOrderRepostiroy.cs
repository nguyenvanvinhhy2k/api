using Backend.ViewModel.Cart;
using Backend.ViewModel.Common;
using Backend.ViewModel.StatisticalOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.Repository
{
    public interface IOrderRepostiroy
    {
        Task<int> CreateOrder(OrderCreateVM model);
        Task<bool> CreateOrderDetail(OrderDetailCreateVM model);

        Task<PageResult<OrderVM>> getAllPageing(OrderRequest model);
        Task<PageResult<OrderVM>> OrderSuccess(OrderRequest model);
        Task<List<OrderDetailVM>> GetByID(int ID);

        Task<bool> UpdateStatusOrder(UpdateOrderStatus model);
        Task<object> Statistical();
    }
}
