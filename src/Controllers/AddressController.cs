using Hanan_csharp_backend_teamwork.src.Abstractions;
using Hanan_csharp_backend_teamwork.src.DTOs;
using Hanan_csharp_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Controllers;

namespace Hanan_csharp_backend_teamwork.src.Controllers
{
    public class AddressController : BaseController
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Address> CreateOne(AddressDTO userAddress)
        {
            if (userAddress is null)
            {
                return BadRequest();
            }
            _addressService.CreateOne(userAddress);
            return CreatedAtAction(nameof(CreateOne), userAddress);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteById(Guid id)
        {
            _addressService.DeleteById(id);
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Address> FindAll()
        {
            return _addressService.FindAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Address> FindOne(Guid id)
        {
            var foundAddress = _addressService.FindOne(id);
            if (foundAddress is null)
            {
                return NotFound();
            }
            return Ok(foundAddress);
        }
    }
}