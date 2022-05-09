using Backend.Entities;
using Backend.Service.Repository;
using Backend.ViewModel.Common;
using Backend.ViewModel.Product;
using Backend.ViewModel.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class UserRepository:IUserRepository
    {
        private readonly ShopDbContext _db;
        public UserRepository(ShopDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(UserCreateVM model)
        {
            var user = new User();
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.PassWord = XString.ToMD5(model.PassWord);
            user.CreateDate = DateTime.Now;
            _db.users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            var user = await _db.users.FindAsync(ID);
            if (user == null)
            {
                return false;
            }
            _db.users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<List<UserVM>> GetAll()
        {
            var query = from p in _db.users select p;
            var result = query.Select(x => new UserVM()
            {
                UserName = x.UserName,
                PassWord = x.PassWord,
                UserID = x.UserID,
                FullName = x.FullName
            }).ToListAsync();
            return result;
        }

        public async Task<PageResult<UserVM>> getAllPageing(UserRequestVM request)
        {
            var query = from p in _db.users select p;
            if (!string.IsNullOrEmpty(request.keyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.keyWord));
            }
            int totoRecord = await query.CountAsync();
            var result = await query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize)
                .Select(x => new UserVM()
                {
                    UserName = x.UserName,
                    PassWord = x.PassWord,
                    UserID = x.UserID,
                    FullName = x.FullName
                }).ToListAsync();
            var pageResult = new PageResult<UserVM>()
            {
                items = result,
                pageIndex = request.pageIndex,
                pageSize = request.pageSize,
                totalRecord = totoRecord
            };
            return pageResult;
        }

        public async Task<UserVM> GetByID(int ID)
        {
            var user = await _db.users.FindAsync(ID);
            if (user == null)
            {
                return null;
            }
            var result = new UserVM()
            {
                UserName = user.UserName,
                PassWord = user.PassWord,
                UserID = user.UserID,
                FullName = user.FullName
            };
            return result;
        }

        public async Task<bool> Update(int ID, UserUpdateVM model)
        {
            var user = await _db.users.FindAsync(ID);
            if (user == null)
            {
                return false;
            }
            user.UserName = model.UserName;
            user.FullName = model.FullName;
            user.CreateDate = DateTime.Now;
           
            _db.users.Update(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
