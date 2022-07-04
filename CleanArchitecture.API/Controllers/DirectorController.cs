﻿using System.Net;
using CleanArchitecture.Application.Features.Directors.Commands.CreateDirector;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DirectorController : Controller
{
    private IMediator _mediator;

    public DirectorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpPost(Name = "CreateDirector")]
    [Authorize(Roles = "Administrator")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateDirector([FromBody] CreateDirectorCommand command)
    {
        return await _mediator.Send(command);
    }
}