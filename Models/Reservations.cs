namespace WebApi.Models;

public class Reservations
{
    public string? Id { get; set; }
    public Users Users { get; set; }
    public Restaurants Restaurants { get; set; }
    public int Personas { get; set; }
    public List<Features> Servicios { get; set; }
    public string InstruccionesEspeciales { get; set; }
}