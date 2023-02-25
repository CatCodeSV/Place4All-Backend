using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Addresses")]
    public class AddressesController : ControllerBase
{
    private readonly AddressesService _addressesService;

    public AddressesController(AddressesService addressesService)
    {
        _addressesService = addressesService;
    }

    [HttpGet]
    public ActionResult<List<Addresses>> Get() => _addressesService.Get();

    [HttpGet("{id:length(24)}")]
    public ActionResult<Addresses> Get(string id) => _addressesService.Get(id);

    [HttpPost]
    public ActionResult<Addresses> Create(Addresses address)
    {
        var direccionCreada =  _addressesService.Create(address);

        return CreatedAtRoute("", new { id = address.Id }, direccionCreada);
    }
    
    [HttpPut( "{id:length(24)}")]
    public IActionResult Put(string id, Addresses address)
    {
        var direccion = _addressesService.Get(id);
            
        if (direccion == null)
        {
            return NotFound();
        }

        address.Id = direccion.Id;
        _addressesService.Update(id, address);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
        var direccion = _addressesService.Get(id);
            
            
        if (direccion == null)
        {
            return NotFound();
        }
            
        _addressesService.Remove(direccion);

        return NoContent();
    }
}
}
