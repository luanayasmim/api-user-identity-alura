using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime BirthDate  { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set;}
}
public class LoginUserDto
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}