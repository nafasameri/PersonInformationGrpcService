using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PersonInformationGrpcService.Domain.Entities;

namespace PersonInformationGrpcService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
