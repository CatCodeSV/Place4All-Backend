namespace Place4AllBackend.Application.Dto;

public class AddressDto
{
    public int Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Province { get; set; }
    public string CreateDate { get; set; }
}