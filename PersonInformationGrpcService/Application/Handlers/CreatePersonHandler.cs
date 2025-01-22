using MediatR;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using AutoMapper;

namespace PersonInformationGrpcService.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            return await _repository.AddPersonAsync(person, cancellationToken);
        }
    }
}
