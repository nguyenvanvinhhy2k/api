using Backend.Service.Repository;
using Backend.ViewModel.User;
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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _res;
        public UserController(IUserRepository res)
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
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _res.GetByID(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllPageing")]
        public async Task<IActionResult> GetAll([FromQuery] UserRequestVM request)
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
        public async Task<IActionResult> Create([FromBody] UserCreateVM request)
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
        public async Task<IActionResult> Update(int ID, [FromBody] UserUpdateVM request)
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
