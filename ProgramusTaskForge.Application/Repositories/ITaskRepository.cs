namespace ProgromusTaskForge.Application.Repositories;

public interface ITaskRepository
{
    List<Task> GetAll();
    Task GetById(int id);
    Task Create(Task task);
    Task Update(Task task);
    int Delete(int id);
}