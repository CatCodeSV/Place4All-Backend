namespace WebApi.Models;

public class Reservations
{
    public string? Id { get; set; }
    public Users User { get; set; }
    public Restaurants Restaurant { get; set; }
    public int Personas { get; set; }
    public List<Features> Servicios { get; set; }
    public string InstruccionesEspeciales { get; set; }
}
