using MediatR;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using AutoMapper;

namespace PersonInformationGrpcService.Application.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public DeletePersonHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeletePersonAsync(request.id, cancellationToken);
        }
    }
}
