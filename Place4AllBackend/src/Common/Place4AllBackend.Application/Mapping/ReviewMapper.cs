using AutoMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Mapping;

public class ReviewMapper : Profile
{
    string UserName = null;

    public ReviewMapper()
    {
        CreateMap<Review, ReviewDto>().ForMember(m => m.UserName, opt => opt.MapFrom(r => UserName));
    }
}