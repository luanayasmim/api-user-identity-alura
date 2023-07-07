using Microsoft.AspNetCore.Identity;

namespace UserApi.Models;

public class User : IdentityUser
{
    public User(): base()
    {
    }

    public DateTime BirthDate { get; set; }
}
