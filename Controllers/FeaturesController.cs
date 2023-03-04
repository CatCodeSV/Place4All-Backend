using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Features")]
    public class FeaturesController : ControllerBase
    {

        private readonly IFeaturesService _featuresService;

        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        [HttpGet]
        public ActionResult<List<Features>> Get() => _featuresService.Get();

        //Se pasa por la URL un id que tiene que tener 24 caracteres ya que el BSON.Id tiene ese formato.
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Features>> Get(string id)
        {
            var servicio = await _featuresService.Get(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        [HttpPost]
        public async Task<ActionResult<Features>> Create(Features feature)
        {
            var servicioCreado = await  _featuresService.Create(feature);

            return CreatedAtRoute("", new { id = feature.Id }, servicioCreado);
        }

        [HttpPut( "{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Features feature)
        {
            var servicio = await _featuresService.Get(id);
            
            if (servicio == null)
            {
                return NotFound();
            }

            feature.Id = servicio.Id;
            _featuresService.Update(feature);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var servicio = await _featuresService.Get(id);
            
            
            if (servicio == null)
            {
                return NotFound();
            }
            
            _featuresService.Remove(servicio);

            return NoContent();
        }
    }
}