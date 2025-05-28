using Microsoft.AspNetCore.Mvc;
using Airport.REST.Models;
using Airport.REST.Interfaces;

namespace Airport.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly ICrudServiceAsync<FlightModel> _service;

        public FlightController(ICrudServiceAsync<FlightModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.ReadAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.ReadAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FlightModel model)
        {
            await _service.CreateAsync(model);
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FlightModel model)
        {
            var updated = await _service.UpdateAsync(model);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] FlightModel model)
        {
            var removed = await _service.RemoveAsync(model);
            return removed ? Ok() : NotFound();
        }
    }
}
