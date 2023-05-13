using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Dto;

public class ImageDto
{
    public int Id { get; set; }
    public string Link { get; set; }
    public int RestaurantId { get; set; }
    public string CreateDate { get; set; }
}