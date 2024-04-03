using MediatR;
using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Queries;

public record GetAllTasksQuery():IRequest<List<TaskEntity>>;

public class GetAllTasksQueryhandler : IRequestHandler<GetAllTasksQuery, List<TaskEntity>>
{
    public readonly ITaskRepository _TaskRepository;

    public GetAllTasksQueryhandler(ITaskRepository taskRepository)
    {
        _TaskRepository = taskRepository;
    }

    public Task<List<TaskEntity>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        List<TaskEntity> tasks = _TaskRepository.GetAll();
        return Task.FromResult(tasks);
    }
}