using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers;

[ApiController]
[Route("{controller}")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinimumAge")]
    public IActionResult Get()
    {
        return Ok("Access allowed!");
    }
}