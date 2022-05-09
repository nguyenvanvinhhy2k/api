using Backend.Entities;
using Backend.ViewModel.Category;
using Backend.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public interface ICategoryRepository
    {
        Task<bool> Create(CategoryCreateVM model);
        Task<bool> Update(int ID, CategoryUpdateVM model);
        Task<bool> Delete(int ID);
        Task<PageResult<CategoryVM>> getAllPageing(CategoryRequestVM model);
        Task<List<CategoryVM>> GetAll();
        Task<CategoryVM> GetByID(int ID);
    }
}
