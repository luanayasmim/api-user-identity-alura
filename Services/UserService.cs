using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService
    (
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        TokenService tokenService
    )
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Create(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
            throw new ApplicationException("Error to register user");
    }

    public async Task<string> SignIn(LoginUserDto userDto)
    {
        var result = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);
        if (!result.Succeeded)
            throw new ApplicationException("Not autheticated user!");

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userDto.Username.ToUpper());

        //Generate Token with JWT
        var token = _tokenService.GenerateToken(user);

        return token;

    }
}
