using MediatR;

namespace PersonInformationGrpcService.Application.Commands
{
    public record DeletePersonCommand(int id) : IRequest<bool>;
}
