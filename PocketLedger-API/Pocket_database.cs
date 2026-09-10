using Microsoft.EntityFrameworkCore;
namespace PocketLedger;

public class Pocket_database : DbContext
{
	public DbSet<Expenses> Expenses { get; set; }
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite("Data Source=PocketLedger.db");
	}
}