using Backend.Entities;
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
