using Backend.Entities;
using Backend.ViewModel.Authentication;
using Backend.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Repository
{
    public class AuthenRepository : IAuthenRepository
    {
        private readonly ShopDbContext _db;
        private readonly IConfiguration _config;
        public AuthenRepository(ShopDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public async Task<ApiResult<string>> Login(LoginRequestVM request)
        {
            var checkUser = await _db.users.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync();
            if (checkUser == null)
            {
                return new ApiResultError<string>("Sai tài khoản");
            }
            var user = _db.users.Where(x => x.PassWord == XString.ToMD5(request.PassWord)).FirstOrDefault();
            if (user == null)
            {
                return new ApiResultError<string>("Sai mật khẩu");
            }
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName,user.UserName),
                new Claim(ClaimTypes.GivenName,user.FullName)

            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var Token = new JwtSecurityToken(
                    _config["Tokens:Issuer"],
                    _config["Tokens:Issuer"],
                    Claims,
                    expires: DateTime.Now.AddDays(30.0),
                    signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );
            return new ApiResultSuccess<string>(new JwtSecurityTokenHandler().WriteToken(Token));
        }
    }
}
