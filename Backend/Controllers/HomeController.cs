using Backend.Service;
using Backend.Service.Repository;
using Backend.ViewModel.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _res;
        public HomeController(IProductRepository res)
        {
            _res = res;
        }
        [HttpGet("getNewProduct")]
        public async Task<IActionResult> GetNewProduct()
        {
            try
            {
                var result = await _res.GetProductNew();
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
