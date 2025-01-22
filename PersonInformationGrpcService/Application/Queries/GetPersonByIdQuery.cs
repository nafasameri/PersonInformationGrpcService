using MediatR;
using PersonInformationGrpcService.Domain.Entities;

namespace PersonInformationGrpcService.Application.Queries
{
    public record GetPersonByIdQuery(int Id) : IRequest<Person?>;
}
