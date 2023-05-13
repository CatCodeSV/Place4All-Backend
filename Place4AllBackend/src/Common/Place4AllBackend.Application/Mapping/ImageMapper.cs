using AutoMapper;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Mapping;

public class ImageMapper : Profile
{
    public ImageMapper()
    {
        CreateMap<Image, ImageDto>();
        CreateMap<ImageDto, Image>();
    }
}