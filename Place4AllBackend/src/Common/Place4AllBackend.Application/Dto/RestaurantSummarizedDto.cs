namespace Place4AllBackend.Application.Dto;

public class RestaurantSummarizedDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }
    public float Rating { get; set; } = 0;
    public int NumberOfReviews { get; set; } = 0;
    public string Address { get; set; }
    public string Summary { get; set; }
}