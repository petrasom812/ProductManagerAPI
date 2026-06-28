using Microsoft.AspNetCore.Mvc;
using ProductManger.Api.Dtos;
using ProductManager.Api.Interface;

namespace ProductManger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductManagerController : ControllerBase
    {
        private readonly IServiceFeatures _service;
        public ProductManagerController(IServiceFeatures service)
        {
            _service = service;
        }
        [HttpGet] //View all data
        public async Task<ActionResult<List<FeatureDto>>> Get()
        {
            var getFeature = await _service.GetFeaturesAsync();
            return Ok(getFeature);
        }
        [HttpPost] //Add Feature
        public async Task<ActionResult<FeatureDto>> Post(CreateFeatureDto dto)
        {
            var addFeature = await _service.AddFeatureAsync(dto.Title, dto.Description, dto.Priority);
            return Ok(addFeature);
        }
        [HttpPut("{id}")] // Update Feature
        public async Task<IActionResult> Put(int id, UpdateFeatureDto dto)
        {
            var updateFeature = await _service.UpdateFeatureAsync(id, dto.Title, dto.Description, dto.Priority, dto.IsCompleted);
            if (!updateFeature)
                return NotFound("Feature not found");
            return Ok(updateFeature);
        }
        [HttpDelete("{id}")] // Delete Feature
        public async Task<IActionResult> Delete(int id)
        {
            var deleteFeature = await _service.DeleteFeatureAsync(id);
            if (!deleteFeature)
                return NotFound("Feature not found");
            return NoContent();
        }
    }
}