using Microsoft.EntityFrameworkCore;

namespace SupplierHub.Config
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
