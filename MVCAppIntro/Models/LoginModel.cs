



using System.ComponentModel.DataAnnotations;

namespace MVCAppIntro.Models
{
  public class LoginModel
  {
    [Required(ErrorMessage = "Username boş geçilemez")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Parola boş geçilemez")]
    [MinLength(8,ErrorMessage = "Parola min 8 karakter uzunluğunda olmalıdır")]
    public string Password { get; set; }

    public bool RememberMe { get; set; } // Oturumun kalıcı olup olmamasının seçimini kullanıcıya bırakacağız. Sistem beni hatırlasın mı hatırlamasın mı


  }
}
