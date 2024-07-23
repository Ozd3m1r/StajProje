using System.ComponentModel.DataAnnotations;

namespace stajProjeLogin.Models
{
    public class RegisterModel
    {
        
        public int ID { get; set; }

        [Display(Name = "Adı")]
        public string ADI { get; set; }

        [Display(Name = "Soyadı")]
        public string SOYADI { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string KULLANICI_ADI { get; set; }

        [Display(Name = "Şifre")]
        public string SIFRE { get; set; }
    }
}
