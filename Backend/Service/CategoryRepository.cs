using Backend.Entities;
using Backend.ViewModel.Category;
using Backend.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _db;
        public CategoryRepository(ShopDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(CategoryCreateVM model)
        {
            var category = new Category();
            category.Name = model.Name;
            category.Title = XString.ToAscii(model.Name);
            category.ParentID = 0;
            category.SortOrder = model.SortOrder;
            category.CreateDate = DateTime.Now;
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            var category = await _db.categories.FindAsync(ID);
            if (category == null)
            {
                return false;
            }
            _db.categories.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<List<CategoryVM>> GetAll()
        {
            var query = from p in _db.categories select p;
            var result = query.Select(x => new CategoryVM()
            {
                ID = x.ID,
                Name = x.Name,
                Title = x.Title,
                ParentID = x.ParentID,
                SortOrder = x.SortOrder
            }).ToListAsync();
            return result;
        }

        public async Task<PageResult<CategoryVM>> getAllPageing(CategoryRequestVM request)
        {
            var query = from p in _db.categories select p;
            if (!string.IsNullOrEmpty(request.keyWord))
            {
                query = query.Where(x => x.Name.Contains(request.keyWord));
            }
            int totoRecord = await query.CountAsync();
            var result = await query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize)
                .Select(x => new CategoryVM()
                {
                    ID = x.ID,
                    Name = x.Name,                    
                    Title = x.Title,
                    ParentID = x.ParentID,
                    SortOrder = x.SortOrder
                }).ToListAsync();
            var pageResult = new PageResult<CategoryVM>()
            {
                items = result,
                pageIndex = request.pageIndex,
                pageSize = request.pageSize,
                totalRecord = totoRecord
            };
            return pageResult;
        }

        public async Task<CategoryVM> GetByID(int ID)
        {
            var category = await _db.categories.FindAsync(ID);
            if (category == null)
            {
                return null;
            }
            var result = new CategoryVM()
            {
                ID = category.ID,
                Name = category.Name,
                Title = category.Title,
                ParentID = category.ParentID,
                SortOrder = category.SortOrder
            };
            return result;
        }

        public async Task<bool> Update(int ID, CategoryUpdateVM model)
        {
            var category = await _db.categories.FindAsync(ID);
            if (category == null)
            {
                return false;
            }
            category.Name = model.Name;
            category.Title = XString.ToAscii(model.Name);
            category.SortOrder = model.SortOrder;
            category.ParentID = model.ParentID;                        
            _db.categories.Update(category);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
