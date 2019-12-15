using GorgeousFood.PointOfSale.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.PointOfSale.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleRepository _pointOfSaleRepository;

        public PointOfSaleController(IPointOfSaleRepository pointOfSaleRepository) => _pointOfSaleRepository = pointOfSaleRepository;

        // GET: PointOfSale
        [HttpGet]
        public IEnumerable<Models.PointOfSale> GetPointOfSale() => _pointOfSaleRepository.GetAllPointOfSale();

        // GET: PointOfSale/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPointOfSale([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.PointOfSale pointOfSale = await _pointOfSaleRepository.GetPointOfSaleByIDAsync(id);

            return pointOfSale == null ? NotFound() : (IActionResult)Ok(pointOfSale);
        }

        // GET: PointOfSale/exists/5
        [HttpGet("exists/{id}")]
        public bool PointOfSaleExists([FromRoute] long id) => _pointOfSaleRepository.PointOfSaleExists(id);

        // PUT: PointOfSale/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPointOfSale([FromRoute] long id, [FromBody] Models.PointOfSale pointOfSale)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != pointOfSale.PointOfSaleID)
                return BadRequest();

            try
            {
                await _pointOfSaleRepository.EditPointOfSaleAsync(pointOfSale);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOfSaleExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: PointOfSale
        [HttpPost]
        public async Task<IActionResult> PostPointOfSale([FromBody] Models.PointOfSale pointOfSale)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pointOfSaleRepository.AddPointOfSaleAsync(pointOfSale);

            return CreatedAtAction("GetPointOfSale", new { id = pointOfSale.PointOfSaleID }, pointOfSale);
        }

        // DELETE: PointOfSale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePointOfSale([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.PointOfSale pointOfSale = await _pointOfSaleRepository.GetPointOfSaleByIDAsync(id);

            if (pointOfSale == null)
                return NotFound();

            await _pointOfSaleRepository.DeletePointOfSaleAsync(pointOfSale);

            return Ok(pointOfSale);
        }
    }
}