using Backend.ViewModel.Common;
using Backend.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.Repository
{
    public interface IUserRepository
    {
        Task<bool> Create(UserCreateVM model);
        Task<bool> Update(int ID, UserUpdateVM model);
        Task<bool> Delete(int ID);
        Task<PageResult<UserVM>> getAllPageing(UserRequestVM request);
        Task<List<UserVM>> GetAll();
        Task<UserVM> GetByID(int ID);
    }
}
