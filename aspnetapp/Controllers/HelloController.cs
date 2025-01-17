﻿using System.Threading.Tasks;
using aspnetapp.Services;
using Greet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{
    /// <summary>
    /// Hello controller
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class HelloController : Controller
    {
        private readonly ILogger<HelloController> _logger;
        private readonly IGreeterService _service;

        /// <summary>
        /// Hello constructor
        /// </summary>
        public HelloController(ILogger<HelloController> logger, IGreeterService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// A simple method to say hello
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /hello?name=MyName
        ///
        /// </remarks>
        /// <param name="name"></param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HelloReply))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SayHello(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            // Forward the call to the greeter service
            var response = await _service.SayHello(new HelloRequest { Name = name });
            return Ok(response);
        }
    }
}