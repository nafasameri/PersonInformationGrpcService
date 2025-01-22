using MediatR;

namespace PersonInformationGrpcService.Application.Commands
{
    public record UpdatePersonCommand(int id, string FirstName, string LastName, string NationalCode, DateTime DateOfBirth) : IRequest<bool>;
}
