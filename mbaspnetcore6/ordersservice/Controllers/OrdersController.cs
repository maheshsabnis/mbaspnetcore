using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ordersservice.Models;

namespace ordersservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        Orders orders;

        public OrdersController()
        {
            orders = new Orders();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            orders.Add(order);
            return Ok(orders);
        }
    }
}
