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
    public class EstimatedPriceController : ControllerBase
    {
        BusinessLogicLayer.EstimatedPriceController estimatedPriceController = new BusinessLogicLayer.EstimatedPriceController();

        // POST api/EstimatedPrice
        [HttpPost]
        public void Post(EstimatedPrice estimatedPrice)
        {
            estimatedPriceController.Create(estimatedPrice);
        }

        // DELETE api/EstimatedPrice
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            estimatedPriceController.Delete(id);
        }

        [HttpGet("{id}")]
        public EstimatedPrice Get(int id)
        {
            return estimatedPriceController.Get(id);
        }

        [HttpGet]
        public List<EstimatedPrice> GetAll()
        {
            return estimatedPriceController.GetAll();
        }

        [HttpPut]
        public void Update(EstimatedPrice estimatedPrice)
        {
            estimatedPriceController.Update(estimatedPrice);
        }
    }
}
