using System.ComponentModel.DataAnnotations;

namespace stajProjeLogin.Models;

public class User
{
    public int ID { get; set; }

    [Display(Name = "ADI")]
    public string ADI { get; set; }

    [Display(Name = "Soyadı")]
    public string SOYADI { get; set; }

    [Display(Name = "Kullanıcı Adı")]
    public string KULLANICI_ADI { get; set; }

    [Display(Name = "Şifre")]
    public string SIFRE { get; set; }

}
