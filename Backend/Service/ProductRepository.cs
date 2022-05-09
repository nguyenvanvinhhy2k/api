using Backend.Entities;
using Backend.ViewModel.Common;
using Backend.ViewModel.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Backend.Service
{
    class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _db;
        public ProductRepository(ShopDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(ProductCreateVM model)
        {
            var product = new Product();
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.OriginalPrice = model.OriginalPrice;
            product.Size = model.Size;
            product.Image = model.Image;
            product.Title = XString.ToAscii(model.Name);
            product.CreateDate = DateTime.Now;
            product.Quantity = model.Quantity;
            product.CateID = model.CateID;

            _db.products.Add(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int ID)
        {
            var product = await _db.products.FindAsync(ID);
            if (product == null)
            {
                return false;
            }
            _db.products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<List<ProductVM>> GetAll()
        {
            var query = from p in _db.products select p;
            var result = query.Select(x=> new ProductVM()
            {
                ID = x.ID,
                Name = x.Name,
                Price = x.Price,
                OriginalPrice = x.OriginalPrice,
                Description = x.Description,
                Image = x.Image,
                Size = x.Size,
                Quantity = x.Quantity,
                Title = x.Title,
                CateID = x.CateID
            }).ToListAsync();
            return result;
        }

        public async Task<PageResult<ProductVM>> getAllPageing(ProductRequestVM request)
        {
            var query = from p in _db.products select p;
            if (!string.IsNullOrEmpty(request.keyWord))
            {
                query = query.Where(x => x.Name.Contains(request.keyWord));
            }
            int totoRecord = await query.CountAsync();
            var result = await query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize)
                .Select(x=>new ProductVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    OriginalPrice = x.OriginalPrice,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Size = x.Size,
                    Title = x.Title,
                    CateID = x.CateID
                }).ToListAsync();
            var pageResult = new PageResult<ProductVM>()
            {
                items = result,
                pageIndex = request.pageIndex,
                pageSize = request.pageSize,
                totalRecord = totoRecord
            };
            return pageResult;
        }

        public async Task<ProductVM> GetByID(int ID)
        {
            var product = await _db.products.FindAsync(ID);
            if (product == null)
            {
                return null;
            }
            var result = new ProductVM()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Description = product.Description,
                Image = product.Image,
                Size = product.Size,
                Quantity = product.Quantity,
                Title = product.Title,
                CateID = product.CateID
            };
            return result;
        }

        public async Task<PageResult<ProductVM>> GetProductInCategory(int ID)
        {
            var query = from p in _db.products select p;
            query = query.Where(x => x.CateID == ID);
            int totoRecord = await query.CountAsync();
            var result = await query
                .Select(x => new ProductVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    OriginalPrice = x.OriginalPrice,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Size = x.Size,
                    Title = x.Title,
                    CateID = x.CateID
                }).ToListAsync();
            var pageResult = new PageResult<ProductVM>()
            {
                items = result,
                totalRecord = totoRecord
            };
            return pageResult;
        }

        public async Task<PageResult<ProductVM>> GetProductNew()
        {
            var query = from p in _db.products select p;
            var result = await query.Skip(0).Take(8).OrderBy(x=>x.CreateDate)
                .Select(x => new ProductVM()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    OriginalPrice = x.OriginalPrice,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Size = x.Size,
                    Title = x.Title,
                    CateID = x.CateID
                }).ToListAsync();
            var pageResult = new PageResult<ProductVM>()
            {
                items = result,                
            };
            return pageResult;
        }

        public async Task<bool> Update(int ID,ProductEditVM model)
        {
            var product = await _db.products.FindAsync(ID);
            if (product==null)
            {
                return false;
            }
            product.Name = model.Name;
            product.Price = model.Price;
            product.OriginalPrice = model.OriginalPrice;
            product.Quantity = model.Quantity;
            product.Description = model.Description;
            product.Size = model.Size;
            if (model.Image != null)
            {
                product.Image = model.Image;
            }
            product.Title = XString.ToAscii(model.Name);
            product.CateID = model.CateID;
            _db.products.Update(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
