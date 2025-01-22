using MediatR;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using AutoMapper;

namespace PersonInformationGrpcService.Application.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePersonHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);

            return await _repository.UpdatePersonAsync(person, cancellationToken);
        }
    }
}
