using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MaterialController : ControllerBase
    {
        BusinessLogicLayer.MaterialController materialController = new BusinessLogicLayer.MaterialController();

        // POST api/Material
        [HttpPost("Post")]
        public bool Post(Material material)
        {
            return materialController.Create(material);
        }

        // DELETE api/Material
        [HttpDelete(("Delete") + ("{id}"))]
        public bool Delete(int id)
        {
           return materialController.Delete(id);
        }

        [HttpGet(("Get") + ("{id}"))]
        public Material Get(int id)
        {
            return materialController.Get(id);
        }

        [HttpGet("GetAll")]
        public List<Material> GetAll()
        {
            return materialController.GetAll();
        }

        [HttpPut("Put")]
        public bool Update(Material material)
        {
            return materialController.Update(material);
        }
    }
}