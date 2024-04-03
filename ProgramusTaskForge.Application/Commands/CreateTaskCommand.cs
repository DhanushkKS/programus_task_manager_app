using AutoMapper;
using MediatR;
using ProgromusTaskForge.Application.Dtos.Task;
using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Commands;

public record CreateTaskCommand(CreateTaskDto Task):IRequest<TaskEntity>;
public class CreateTaskCommandHandler:IRequestHandler<CreateTaskCommand,TaskEntity>
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;
    public CreateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }

    public Task<TaskEntity> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = _mapper.Map<TaskEntity>(request.Task);
        _taskRepository.Create(task);
        return Task.FromResult(task);
    }
}