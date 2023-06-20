using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage ="Lütfen ad alanını boş bırakmayınız.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyad alanını boş bırakmayınız.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı boş bırakmayınız.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen email adresinizi boş bırakmayınız.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
        public int WorkLocationID { get; set; }

    }
}
