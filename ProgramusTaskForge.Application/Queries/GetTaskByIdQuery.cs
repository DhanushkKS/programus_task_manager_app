using MediatR;
using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Queries;

public record GetTaskByIdQuery(int id):IRequest<TaskEntity>;
public class GetTaskByIdQueryHandler:IRequestHandler<GetTaskByIdQuery,TaskEntity>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task<TaskEntity> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        TaskEntity task = _taskRepository.GetById(request.id);
        return Task.FromResult(task);
    }
}