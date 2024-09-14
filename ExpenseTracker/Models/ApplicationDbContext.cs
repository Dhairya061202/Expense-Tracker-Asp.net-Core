using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<TranscationTable> trans { get; set; }
		public DbSet<CategoryTable> cat { get; set; }

       


    }
}
