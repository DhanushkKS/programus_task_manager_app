using AutoMapper;
using MediatR;
using ProgromusTaskForge.Application.Dtos.Task;
using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Commands;

public record UpdateTaskCommand(CreateTaskDto Task):IRequest<TaskEntity>;
public class UpdateTaskCommandHandler:IRequestHandler<UpdateTaskCommand,TaskEntity>
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;
    public UpdateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository)
    {
        _mapper = mapper;
        _taskRepository = taskRepository;
    }

    public Task<TaskEntity> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = _mapper.Map<TaskEntity>(request.Task);
        _taskRepository.Update(task);
        return Task.FromResult(task);
    }
}