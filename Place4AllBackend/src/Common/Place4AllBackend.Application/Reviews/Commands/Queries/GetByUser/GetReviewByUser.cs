using System.Collections.Generic;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.Reviews.Commands.Queries.GetByUser;

public class GetReviewByUser : IRequestWrapper<List<ReviewDto>>
{
    public string userId { get; set; }
}