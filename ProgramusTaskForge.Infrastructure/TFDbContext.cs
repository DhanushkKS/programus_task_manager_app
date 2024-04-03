using Microsoft.EntityFrameworkCore;

namespace ProgromusTaskForge.Infrastructure;

public class TFDbContext:DbContext
{
    public TFDbContext(DbContextOptions<TFDbContext> options):base(options){}
    
    //DbSets
    public DbSet<Task> Tasks { get; set; }
}