using AutoMapper;
using MediatR;
using ProgromusTaskForge.Application.Repositories;

namespace ProgromusTaskForge.Application.Commands;

public record DeleteTaskCommand(int id):IRequest<int>;
public class DeleteTaskCommandHandler:IRequestHandler<DeleteTaskCommand,int>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        _taskRepository.Delete(request.id);
        return Task.FromResult(request.id);
    }
}