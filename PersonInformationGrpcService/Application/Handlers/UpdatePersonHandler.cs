using MediatR;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using AutoMapper;
using Grpc.Core;

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
            try
            {
                var person = _mapper.Map<Person>(request);

                return await _repository.UpdatePersonAsync(person, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
