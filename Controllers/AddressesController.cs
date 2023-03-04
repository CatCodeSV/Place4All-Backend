using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Addresses")]
    public class AddressesController : ControllerBase
{
    private readonly IAddressesService _addressesService;

    public AddressesController(IAddressesService addressesService)
    {
        _addressesService = addressesService;
    }

    [HttpGet]
    public ActionResult<List<Addresses>> Get() => _addressesService.Get();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Addresses>> Get(string id) => await _addressesService.Get(id);

    [HttpPost]
    public async Task<ActionResult<Addresses>> Create(Addresses address)
    {
        var direccionCreada =  await _addressesService.Create(address);

        return CreatedAtRoute("", new { id = address.Id }, direccionCreada);
    }
    
    [HttpPut( "{id:length(24)}")]
    public async Task<IActionResult> Put(string id, Addresses address)
    {
        var direccion = await _addressesService.Get(id);
            
        if (direccion == null)
        {
            return NotFound();
        }

        address.Id = direccion.Id;
        _addressesService.Update(address);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var direccion = await _addressesService.Get(id);
            
            
        if (direccion == null)
        {
            return NotFound();
        }
            
        _addressesService.Remove(direccion);

        return NoContent();
    }
}
}
