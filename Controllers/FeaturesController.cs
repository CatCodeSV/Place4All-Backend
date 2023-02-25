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

        private readonly FeaturesService _featuresService;

        public FeaturesController(FeaturesService featuresService)
        {
            _featuresService = featuresService;
        }

        [HttpGet]
        public ActionResult<List<Features>> Get() => _featuresService.Get();

        //Se pasa por la URL un id que tiene que tener 24 caracteres ya que el BSON.Id tiene ese formato.
        [HttpGet("{id:length(24)}")]
        public ActionResult<Features> Get(string id)
        {
            var servicio = _featuresService.Get(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        [HttpPost]
        public ActionResult<Features> Create(Features feature)
        {
            var servicioCreado =  _featuresService.Create(feature);

            return CreatedAtRoute("", new { id = feature.Id }, servicioCreado);
        }

        [HttpPut( "{id:length(24)}")]
        public IActionResult Put(string id, Features feature)
        {
            var servicio = _featuresService.Get(id);
            
            if (servicio == null)
            {
                return NotFound();
            }

            feature.Id = servicio.Id;
            _featuresService.Update(id, feature);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var servicio = _featuresService.Get(id);
            
            
            if (servicio == null)
            {
                return NotFound();
            }
            
            _featuresService.Remove(servicio);

            return NoContent();
        }
    }
}