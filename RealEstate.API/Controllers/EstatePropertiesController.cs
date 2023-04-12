using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTO;
using RealEstate.API.Models;
using RealEstate.API.Repository;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatePropertiesController : ControllerBase
    {
  
        private readonly IPropertyRepository _propertyRepository;
        public EstatePropertiesController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllEstateProperties()
        {
           return Ok(await _propertyRepository.GetAllProperty());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstateProperty(EstatePropertyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProperty = new EstateProperty
            {
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address,
                UrlImages = dto.UrlImages,
                PriceifRent = dto.PriceifRent,
                PriceifSale = dto.PriceifSale
            };

            var property = await _propertyRepository.AddProperty(newProperty);

            return Ok(property);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            var property = await _propertyRepository.GetPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }

            await _propertyRepository.DeleteProperty(property.Id);

            return Ok(property);
        }

        [HttpPost("{id}")]
        public IActionResult EditEstateProperty(int id, EstatePropertyDto dto)
        {
            var property =  _propertyRepository.GetPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProperty = new EstateProperty
            {
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address,
                UrlImages = dto.UrlImages,
                PriceifRent = dto.PriceifRent,
                PriceifSale = dto.PriceifSale
            };

            var propertyToReturn = _propertyRepository.UpdateProperty(id, updatedProperty);

            return Ok(propertyToReturn);
        }

    }
}
