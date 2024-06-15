/*﻿using Microsoft.AspNetCore.Mvc;

namespace dotnetfordocker.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class register : ControllerBase
    {
        private readonly ILogger<register> _logger;
        public register(ILogger<register> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string RegistrationForm()
        {
            return " You are sucessfully signed up ";
        }
    }
}*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnetfordocker.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return Ok("You are successfully signed up");
        }
    }
}

    
