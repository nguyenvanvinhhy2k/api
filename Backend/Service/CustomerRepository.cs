﻿using Backend.Entities;
using Backend.Service.Repository;
using Backend.ViewModel.Common;
using Backend.ViewModel.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopDbContext _db;
        public CustomerRepository(ShopDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteFavoriteProduct(int productId, int customeId)
        {
            var checkFavorite = await _db.Favorites.FirstOrDefaultAsync(x => x.ProductId == productId && x.CustomerId == customeId);
            if (checkFavorite == null)
            {
                return false;
            }
            var checkFavoriteProduct = await _db.Favorites.FirstAsync(x => x.ProductId == productId && x.CustomerId == customeId);
            _db.Favorites.Remove(checkFavoriteProduct);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> FavoriteProduct(int productId, int customeId)
        {
            var checkFavorite = await _db.Favorites.FirstOrDefaultAsync(x => x.ProductId == productId && x.CustomerId == customeId);
            if (checkFavorite == null)
            {
                return false;
            }
            var favarite = new Favorite();
            favarite.ProductId = productId;
            favarite.CustomerId = customeId;
            favarite.CreatedDate = DateTime.Now;
            _db.SaveChanges();
            return true;
        }

        public Task<List<Product>> GetFavoriteCustomer(int customeId)
        {
            var favorite = (from f in _db.Favorites
                           join c in _db.customers on f.CustomerId equals c.ID
                           join p in _db.products on f.ProductId equals p.ID
                           where c.ID == customeId
                           select p).ToListAsync();
            return favorite;
                           
        }

        public async Task<ApiResult<CustomerVM>> LoginCutomer(CustomerAuthenVM model)
        {
            var passs = XString.ToMD5(model.PassWord);
            var checkUser = _db.customers.FirstOrDefault(x => x.UserName == model.UserName && x.PassWord == XString.ToMD5(model.PassWord));
            if (checkUser == null)
            {
                return new ApiResultError<CustomerVM>("Tài khoản hoặc mật khẩu sai");
            }
            var user = new CustomerVM()
            {
                FullName = checkUser.FullName,
                ID = checkUser.ID,
                UserName = checkUser.UserName
            };
            return new ApiResultSuccess<CustomerVM>(user);
        }

        public async Task<bool> Register(CustomerRegistorVM model)
        {
            var customer = new Customer();
            customer.FullName = model.FullName;
            customer.UserName = model.UserName;
            customer.PassWord = XString.ToMD5(model.PassWord);
            _db.customers.Add(customer);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
