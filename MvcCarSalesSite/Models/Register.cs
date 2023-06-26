using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçersiz email adresi")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor...")]
        public string ConfirmPassword { get; set; }
    }
}