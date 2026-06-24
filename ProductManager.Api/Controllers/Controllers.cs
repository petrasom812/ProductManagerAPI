using Microsoft.AspNetCore.Mvc;
using ProductManger.Api.Services;
using ProductManger.Api.Dtos;

namespace ProductManger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductMangerController: ControllerBase
    {
        private readonly ServiceFeatures _service;
        public ProductMangerController(ServiceFeatures service)
        {
            _service = service;
        }
        [HttpGet] //View all data
        public IActionResult Get()
        {
            var getFeature = _service.GetFeatures();
            return Ok(getFeature);
        }
        [HttpPost] //Add Feature
        public IActionResult Post(CreateFeatureDto dto)
        {
            var addFeature = _service.AddFeature(dto.Title, dto.Description, dto.Priority);
            return Ok(addFeature);
        }
        [HttpPut("{id}")] // Update Feature
        public IActionResult Put(int id, UpdateFeatureDto dto)
        {
            var updateFeature = _service.UpdateFeature(id, dto.Title, dto.Description, dto.Priority, dto.IsCompleted);
            if(!updateFeature)
                return NotFound("Feature not found");
            return Ok("Feature updated");
        }
        [HttpDelete("{id}")] // Delete Feature
        public IActionResult Delete(int id)
        {
            var deleteFeature = _service.DeleteFeature(id);
            if(!deleteFeature)
                return NotFound("Feature not found");
            return NoContent();
        }
    }
}