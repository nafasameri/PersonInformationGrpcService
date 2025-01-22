using AutoMapper;
using PersonInformationGrpcService.Application.Commands;
using PersonInformationGrpcService.Application.Queries;
using PersonInformationGrpcService.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonInformationGrpcService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, Person>();

            CreateMap<Person, CreatePersonCommand>().ReverseMap();

            CreateMap<CreatePersonRequest, CreatePersonCommand>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)));
            
            CreateMap<Person, UpdatePersonCommand>().ReverseMap();

            CreateMap<UpdatePersonRequest, UpdatePersonCommand>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)));
            CreateMap<GetPersonByIdRequest, GetPersonByIdQuery>();

            CreateMap<Person, GetPersonByIdResponse>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MM-dd")));

            CreateMap<DeletePersonRequest, DeletePersonCommand>();

        }
    }
}
