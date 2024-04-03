using Microsoft.EntityFrameworkCore;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Infrastructure;

public class TFDbContext:DbContext
{
    public TFDbContext(DbContextOptions<TFDbContext> options):base(options){}
    
    //DbSets
    public DbSet<TaskEntity> Tasks { get; set; }
}