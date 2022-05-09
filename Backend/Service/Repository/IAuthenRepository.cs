using Backend.ViewModel.Authentication;
using Backend.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.Repository
{
    public interface IAuthenRepository
    {
        Task<ApiResult<string>> Login(LoginRequestVM request);
    }
}
