using Backend.ViewModel.Common;
using Backend.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public interface IProductRepository
    {
        Task<bool> Create(ProductCreateVM model);
        Task<bool> Update(int ID,ProductEditVM model);
        Task<bool> Delete(int ID);
        Task<PageResult<ProductVM>> getAllPageing(ProductRequestVM request);
        Task<List<ProductVM>> GetAll();
        Task<ProductVM> GetByID(int ID);

        Task<PageResult<ProductVM>> GetProductNew();
        Task<PageResult<ProductVM>> GetProductInCategory(int ID);

    }
}
