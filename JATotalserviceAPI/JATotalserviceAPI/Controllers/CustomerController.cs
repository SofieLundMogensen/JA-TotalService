using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        BusinessLogicLayer.CustomerController customerController = new BusinessLogicLayer.CustomerController();

        [HttpGet("GetAll")]
        public List<Customer> GetAll()
        {
            return customerController.GetAll();
        }

    }
}
