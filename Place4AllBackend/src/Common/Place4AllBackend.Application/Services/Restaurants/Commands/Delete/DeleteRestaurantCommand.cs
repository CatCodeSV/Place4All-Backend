using AutoMapper;
using MediatR;
using Place4AllBackend.Application.Common.Exceptions;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Place4AllBackend.Application.Services.Restaurants.Commands.Delete
{
    public class DeleteRestaurantCommand : IRequestWrapper<RestaurantDto>
    {
        public int Id { get; set; }
    }
}
