using Backend.Service;
using Backend.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _res;
        public ProductController(IProductRepository res)
        {
            _res = res;
        }
        [HttpGet("GetProductByCategory/{ID}")]
        public async Task<IActionResult> GetProductByCategory(int ID)
        {
            try
            {
                var result = await _res.GetProductInCategory(ID);
                var products = await _res.GetAll();
                var relation = products.Where(x => x.ID != ID).Take(4).OrderBy(x => x.CreateDate);
                return Ok(new { result, relation });

               
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _res.GetAll();
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetById/{ID}")]
        public async Task<IActionResult> GetById(int ID)
        {
            try
            {
                var result = await _res.GetByID(ID);
                var products = await _res.GetAll();
                var relation = products.Where(x => x.CateID == result.CateID && x.ID != ID).Take(4).OrderBy(x=>x.CreateDate);
                return Ok(new {result, relation });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllPageing")]
        public async Task<IActionResult> GetAll([FromQuery] ProductRequestVM request)
        {
            try
            {
                var result = await _res.getAllPageing(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductCreateVM request)
        {
            try
            {
                var result = await _res.Create(request);
                return Ok(result);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] ProductEditVM request)
        {
            try
            {
                var result = await _res.Update(id, request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _res.Delete(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("SaveFile"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
