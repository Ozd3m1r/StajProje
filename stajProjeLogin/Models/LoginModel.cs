using StajProje;
using System.ComponentModel.DataAnnotations;

namespace stajProjeLogin.Models

{
    public class LoginModel
    {

        [Display(Name = "Kullanıcı Adı")]
        public string  KULLANICI_ADI { get; set; }

        [Display(Name = "Şifre")]
        public string SIFRE { get; set; }

    }
}
