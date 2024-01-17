using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("addition")]
public class AdditionController : Controller
{
    private readonly ILogger<AdditionController> _logger;

    public AdditionController(ILogger<AdditionController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public string Get()
    {
        return "You have reached the addition controller";
    }

    [HttpGet("{num1}/{num2}")]
    public int Get(int num1, int num2)
    {
        return num1 + num2;
    }
}