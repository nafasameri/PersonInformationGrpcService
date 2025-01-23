using MediatR;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using AutoMapper;
using Grpc.Core;

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
            try
            {
                return await _repository.DeletePersonAsync(request.id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
