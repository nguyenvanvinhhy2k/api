using Backend.Service.Repository;
using Backend.ViewModel.Authentication;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenRepository _res;
        public AuthenticationController(IAuthenRepository res)
        {
            _res = res;
        }
        [HttpPost("Authentication")]
        public async Task<IActionResult> Login([FromBody] LoginRequestVM request)
        {
            try
            {
                var result = await _res.Login(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
