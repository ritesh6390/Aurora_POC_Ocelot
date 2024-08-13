using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aurora.Services.OrderManagement.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        [HttpGet("list")]
        public async Task<ActionResult<string>> GetOrderList()
        {

            return Ok("success");

        }
    }
}
