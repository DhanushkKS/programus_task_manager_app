using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProgromusTaskForge.Application.Commands;
using ProgromusTaskForge.Application.Queries;

namespace ProgromusTaskForge.API.Controllers.Task;

public class TaskController:ApiBaseController
{
    private IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region TasksAPI

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks =await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var task =await _mediator.Send(new GetTaskByIdQuery(id));
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
       var task =  await _mediator.Send(command);
        return Ok(task);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskCommand command)
    {
        var task = _mediator.Send(command);
        return Ok(task);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteTaskCommand(id));
        return Ok();
    }

    #endregion
}