using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected ActionResult Return<T>(Response<T> response) =>
        response.IsSuccess
            ? Ok(response.Data)
            : BadRequest(new
            {
                code = response.Error.Code,
                message = response.Error.Message
            });
}