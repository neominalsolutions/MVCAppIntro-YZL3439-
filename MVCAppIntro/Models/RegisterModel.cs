using System.ComponentModel.DataAnnotations;

namespace MVCAppIntro.Models
{
  public class RegisterModel
  {
    [Required(ErrorMessage = "Username boş geçilemez")]
    public string UserName { get; set; }

    [EmailAddress(ErrorMessage = "E-posta formatında giriniz")]
    [Required(ErrorMessage = "E-posta boş geçilemez")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parola Boş Geçilemez")]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*_.-]).{8,12}$", ErrorMessage = "Güvenli Parola seçiniz 8,12 karakter arası")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Parola eşleşmiyor")]
    [Required(ErrorMessage = "Parola Boş Geçilemez")]
    public string PasswordAgain { get; set; }


  }
}
