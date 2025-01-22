using AutoMapper;
using PersonInformationGrpcService.Domain.Entities;
using PersonInformationGrpcService.Domain.Repositories;
using PersonInformationGrpcService.Infrastructure.Persistence;

namespace PersonInformationGrpcService.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddPersonAsync(Person person, CancellationToken cancellationToken)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync(cancellationToken);
            return person.Id;
        }

        public async Task<Person?> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Persons.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(new object[] { id }, cancellationToken);
            if (person == null) return false;

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdatePersonAsync(Person updatedPerson, CancellationToken cancellationToken)
        {
            var existingPerson = await _context.Persons.FindAsync(new object[] { updatedPerson.Id }, cancellationToken);

            if (existingPerson == null)
            {
                return false;
            }

            _mapper.Map(updatedPerson, existingPerson);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
