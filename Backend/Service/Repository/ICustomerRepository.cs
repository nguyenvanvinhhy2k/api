using Backend.ViewModel.Common;
using Backend.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.Repository
{
    public interface ICustomerRepository
    {
        Task<ApiResult<CustomerVM>> LoginCutomer(CustomerAuthenVM model);
        Task<bool> Register(CustomerRegistorVM model);
        Task<bool> FavoriteProduct(int productId, int customeId);
        Task<bool> DeleteFavoriteProduct(int productId, int customeId);
    }
}
