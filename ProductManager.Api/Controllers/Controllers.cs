using Microsoft.AspNetCore.Mvc;
using ProductManger.Api.Services;
using ProductManger.Api.Dtos;

namespace ProductManger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductMangerController : ControllerBase
    {
        private readonly ServiceFeatures _service;
        public ProductMangerController(ServiceFeatures service)
        {
            _service = service;
        }
        [HttpGet] //View all data
        public async Task<ActionResult<List<FeatureDto>>> Get()
        {
            var getFeature = _service.GetFeatures();
            return Ok(getFeature);
        }
        [HttpPost] //Add Feature
        public async Task<ActionResult<FeatureDto>> Post(CreateFeatureDto dto)
        {
            var addFeature = await _service.AddFeature(dto.Title, dto.Description, dto.Priority);
            return CreatedAtAction(nameof(Post), new { id = addFeature.Id }, addFeature);
        }
        [HttpPut("{id}")] // Update Feature
        public async Task<IActionResult> Put(int id, UpdateFeatureDto dto)
        {
            var updateFeature = await _service.UpdateFeature(id, dto.Title, dto.Description, dto.Priority, dto.IsCompleted);
            if (!updateFeature)
                return NotFound("Feature not found");
            return Ok("Feature updated");
        }
        [HttpDelete("{id}")] // Delete Feature
        public async Task<IActionResult> Delete(int id)
        {
            var deleteFeature = await _service.DeleteFeature(id);
            if (!deleteFeature)
                return NotFound("Feature not found");
            return NoContent();
        }
    }
}