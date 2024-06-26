﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyFellows.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator = null;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
