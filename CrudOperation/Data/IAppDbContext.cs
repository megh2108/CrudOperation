using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data
{
    public interface IAppDbContext : IDbContext
    {
        public DbSet<SampleTable> SampleTables { get; set; }
    }
}
