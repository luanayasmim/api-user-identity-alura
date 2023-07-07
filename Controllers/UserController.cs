using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signUp")]
    public async Task<IActionResult> SignUp(CreateUserDto userDto)
    {
        await _userService.Create(userDto);
        return Ok("Registered User!");
    }

    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn(LoginUserDto userDto)
    {
        var token = await _userService.SignIn(userDto);
        return Ok(token);
    }
}