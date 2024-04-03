using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Repositories;

public interface ITaskRepository
{
    List<TaskEntity> GetAll();
    TaskEntity GetById(int id);
    TaskEntity Create(TaskEntity task);
    TaskEntity Update(TaskEntity task);
    int Delete(int id);
}