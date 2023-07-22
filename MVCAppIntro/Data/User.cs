using Microsoft.AspNetCore.Identity;

namespace MVCAppIntro.Data
{
  public class User
  {
    public string Id { get;  init; } // sadece consturctordan init olsun  diye bir özellik
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    // Kullanıcının Rolleri
    public List<Role> Roles { get; set; }

    public User()
    {
      Id = Guid.NewGuid().ToString();
    }

   

  }
}
