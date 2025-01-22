using AutoMapper;
using Grpc.Core;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Application.Queries;
using MediatR;

namespace PersonInformationGrpcService.Presentation.Services
{
    public class PersonService : PersonServices.PersonServicesBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<CreatePersonCommand>(request);

            var id = await _mediator.Send(command);

            return new CreatePersonResponse { Id = id };
        }

        public override async Task<GetPersonByIdResponse> GetPersonById(GetPersonByIdRequest request, ServerCallContext context)
        {
            var query = new GetPersonByIdQuery(request.Id);
            var person = await _mediator.Send(query);

            if (person == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Person not found"));
            }

            return _mapper.Map<GetPersonByIdResponse>(person);
        }

        public override async Task<UpdatePersonResponse> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<UpdatePersonCommand>(request);

            var updated = await _mediator.Send(command);

            return new UpdatePersonResponse { Status = updated };
        }

        public override async Task<DeletePersonResponse> DeletePerson(DeletePersonRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<DeletePersonCommand>(request);

            var deleted = await _mediator.Send(command);

            return new DeletePersonResponse { Status = deleted };
        }
    }
}
