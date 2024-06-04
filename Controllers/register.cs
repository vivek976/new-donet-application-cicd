using Microsoft.AspNetCore.Mvc;

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
}
    