using Place4AllBackend.Application.ApplicationUser.Queries.GetToken;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Application.Services.ApplicationUser.Commands.Create;

public class CreateUserCommand : IRequestWrapper<LoginResponse>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public bool HasDisability { get; set; }
    public int? DisabilityDegree { get; set; }
    public string PhoneNumber { get; set; }
    
    //Creación de la dirección asociada al usuario
    
    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Province { get; set; }
}