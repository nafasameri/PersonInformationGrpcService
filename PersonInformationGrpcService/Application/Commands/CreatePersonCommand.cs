using MediatR;

namespace PersonInformationGrpcService.Application.Commands
{
    public record CreatePersonCommand(string FirstName, string LastName, string NationalCode, DateTime DateOfBirth) : IRequest<int>;
}
