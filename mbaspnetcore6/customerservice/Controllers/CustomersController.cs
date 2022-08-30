using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using customerservice.Models;

namespace customerservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        Customers customers;

        public CustomersController()
        {
            customers = new Customers();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }
    }
}
