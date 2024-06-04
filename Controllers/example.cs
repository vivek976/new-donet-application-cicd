using Microsoft.AspNetCore.Mvc;

namespace dotnetfordocker.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class example: ControllerBase
    {
        private readonly ILogger<example> _logger;
        public example(ILogger<example> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<int> exampleTask()
        {
            List<int> numbers = new List<int> { 1, 2, 5, 6, 7, 8, 9, 14, 15, 16 };
            List<int> evennumbers = numbers.Where(x => x % 2 == 0).ToList();

            return evennumbers;
        }
    }
}
