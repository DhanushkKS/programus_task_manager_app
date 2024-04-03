using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Infrastructure.Persistences.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly TFDbContext _dbContext;

    public TaskRepository(TFDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Domain.Entities.Task.TaskEntity> GetAll()
    {
        return _dbContext.Tasks.ToList();
    }

    public TaskEntity GetById(int id)
    {
        return _dbContext.Tasks.FirstOrDefault(t => t.Id == id) ?? throw new InvalidOperationException();
    }

    public TaskEntity Create(TaskEntity task)
    {
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
        return task;
    }

    public TaskEntity Update(TaskEntity task)
    {
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
        return task;
    }

    public int Delete(int id)
    {
        TaskEntity task = GetById(id);
        _dbContext.Remove(task);
        return id;
    }
}