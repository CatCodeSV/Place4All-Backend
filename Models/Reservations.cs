using System.Collections.Generic;
using WebApi.Repositories;

namespace WebApi.Models;
[BsonCollection("Reservations")]
public class Reservations : Document
{
    public Users.IUser User { get; set; }
    public Restaurants Restaurant { get; set; }
    public int Personas { get; set; }
    public List<Features> Servicios { get; set; }
    public string InstruccionesEspeciales { get; set; }
}
