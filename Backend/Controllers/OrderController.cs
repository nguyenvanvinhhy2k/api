using Backend.Service.Repository;
using Backend.ViewModel.Cart;
using Backend.ViewModel.StatisticalOrder;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepostiroy _res;
        public OrderController(IOrderRepostiroy res)
        {
            _res = res;
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult>CreateOrder([FromBody] OrderCreateVM model)
        {
            try
            {
                var result = await _res.CreateOrder(model);
                return Ok(result);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("CreateOrderDetail")]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailCreateVM model)
        {
            try
            {
                var result = await _res.CreateOrderDetail(model);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllPageing")]
        public async Task<IActionResult> GetAllPageing([FromQuery] OrderRequest model)
        {
            try
            {
                var result = await _res.getAllPageing(model);
                return Ok(result);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById/{ID}")]
        public async Task<IActionResult> GetDetailOrder(int ID)
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

        [HttpPut("UpdateOrderStatus/{ID}")]
        public async Task<IActionResult>UpdateOrderStatus(int ID,[FromBody]UpdateOrderStatus model)
        {
            try
            {
                var result = await _res.UpdateStatusOrder(model);
                return Ok(result);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("OrderSuccess")]
        public async Task<IActionResult> OrderSuccess([FromQuery] OrderRequest request)
        {
            try
            {
                var result = await _res.OrderSuccess(request);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Statistical")]
        public async Task<IActionResult> Statistical()
        {
            try
            {
                var result = await _res.Statistical();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
