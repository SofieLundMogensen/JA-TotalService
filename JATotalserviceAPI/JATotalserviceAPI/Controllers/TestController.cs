using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JATotalserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/Test
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            BusinessLogicLayer.Class1 class1 = new BusinessLogicLayer.Class1();
            int test = class1.test();
            return new string[] { "value1", "value2", test.ToString() };
        }

        // GET api/test/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}