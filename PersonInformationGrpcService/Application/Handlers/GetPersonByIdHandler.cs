using MediatR;
using PersonInformationGrpcService.Application.Queries;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;

namespace PersonInformationGrpcService.Application.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person?>
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPersonByIdAsync(request.Id, cancellationToken);
        }
    }
}
