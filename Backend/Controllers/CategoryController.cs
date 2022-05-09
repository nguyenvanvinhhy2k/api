using Backend.Service;
using Backend.ViewModel.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _res;
        public CategoryController(ICategoryRepository res)
        {
            _res = res;
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
        public async Task<IActionResult> GetAllById(int ID)
        {
            try
            {
                var result = await _res.GetByID(ID);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllPageing")]
        public async Task<IActionResult> GetAll([FromQuery] CategoryRequestVM request)
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
        public async Task<IActionResult> Create([FromBody] CategoryCreateVM request)
        {
            try
            {
                var result = await _res.Create(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(int ID, [FromBody] CategoryUpdateVM request)
        {
            try
            {
                var result = await _res.Update(ID, request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            try
            {
                var result = await _res.Delete(ID);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
