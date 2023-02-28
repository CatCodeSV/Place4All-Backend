using System.Collections.Generic;

namespace WebApi.Models;

public class Reservations : Document
{
    public Users User { get; set; }
    public Restaurants Restaurant { get; set; }
    public int Personas { get; set; }
    public List<Features> Servicios { get; set; }
    public string InstruccionesEspeciales { get; set; }
}
