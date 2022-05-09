using Backend.Service.Repository;
using Backend.ViewModel.Customer;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _res;
        public CustomerController(ICustomerRepository res)
        {
            _res = res;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CustomerAuthenVM request)
        {
            try
            {
                var result = await _res.LoginCutomer(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Registor")]
        public async Task<IActionResult> Registor([FromBody] CustomerRegistorVM request)
        {
            try
            {
                var result = await _res.Register(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("FavoriteProduct")]
        public async Task<IActionResult> FavoriteProduct(int productId, int customeId)
        {
            try
            {
                var reuslt = await _res.FavoriteProduct(productId, customeId);
                return Ok(reuslt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("DeleteFavoriteProduct")]
        public async Task<IActionResult> DeleteFavoriteProduct(int productid, int customeId)
        {
            try
            {
                var reuslt = await _res.DeleteFavoriteProduct(productid, customeId);
                return Ok(reuslt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetFavoriteCustomer")]
        public async Task<IActionResult> GetFavoriteCustomer(int customerId)
        {
            try
            {
                var reuslt = await GetFavoriteCustomer(customerId);
                return Ok(reuslt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
