using PersonInformationGrpcService.Domain.Entities;

namespace PersonInformationGrpcService.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<int> AddPersonAsync(Person person, CancellationToken cancellationToken);
        Task<Person?> GetPersonByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken);
        Task<bool> UpdatePersonAsync(Person updatedPerson, CancellationToken cancellationToken);
    }
}
