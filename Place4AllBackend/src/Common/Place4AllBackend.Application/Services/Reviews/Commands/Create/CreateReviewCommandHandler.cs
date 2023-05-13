using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Reviews.Commands.Create;

public class CreateReviewCommandHandler : IRequestHandlerWrapper<CreateReviewCommand, ReviewDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateReviewCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResult<ReviewDto>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = new Review
        {
            Title = request.Title,
            Comment = request.Comment,
            Value = request.Value,
            RestaurantId = request.RestaurantId,
            InformationAccuracy = request.InformationAccuracy,
            AdditionalFeatures = request.AdditionalFeatures
        };

        await _context.Reviews.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<ReviewDto>(entity));
    }
}