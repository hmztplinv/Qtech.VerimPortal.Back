using MediatR;
using Microsoft.AspNetCore.Mvc;

public class BaseController:ControllerBase
{
    private IMediator? _mediator; // Elimizde bir mediator enjecte edılmısse, vasrsa bunu kullan.
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); // Mediator null ise HttpContext.RequestServices.GetService<IMediator>()'ı ata.
}