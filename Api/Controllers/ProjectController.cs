using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ProjectController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Response<ProjectDto>>> GetById(int id) =>
        Return(await Mediator.Send(new GetProjectByIdQuery(id)));

    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<ProjectForListDto>>>> GetList(int pageIndex, int pageSize, string namePrefix) =>
        Return(await Mediator.Send(new GetProtectListQuery(pageIndex, pageSize, namePrefix)));

    [HttpPost]
    public async Task<ActionResult<Response<bool>>> Add([FromBody] AddProjectDto addProjectDto) =>
        Return(await Mediator.Send(new AddProjectCommand(addProjectDto)));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Edit(int id, [FromBody] EditProjectDto editProjectDto) =>
        Return(await Mediator.Send(new EditProjectCommand(id, editProjectDto)));

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id) =>
        Return(await Mediator.Send(new DeleteProjectCommand(id)));
}