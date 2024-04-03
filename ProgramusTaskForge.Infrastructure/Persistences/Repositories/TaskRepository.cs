using ProgromusTaskForge.Application.Repositories;

namespace ProgromusTaskForge.Infrastructure.Persistences.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly TFDbContext _dbContext;

    public TaskRepository(TFDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Task> GetAll()
    {
        return _dbContext.Tasks.ToList();
    }

    public Task GetById(int id)
    {
        return _dbContext.Tasks.FirstOrDefault(t => t.Id == id) ?? throw new InvalidOperationException();
    }

    public Task Create(Task task)
    {
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
        return task;
    }

    public Task Update(Task task)
    {
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
        return task;
    }

    public int Delete(int id)
    {
        Task task = GetById(id);
        _dbContext.Remove(task);
        return id;
    }
}