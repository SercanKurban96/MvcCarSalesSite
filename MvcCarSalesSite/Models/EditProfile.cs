using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class EditProfile
    {
        public string EditProfileID { get; set; }
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Geçerli email adresi giriniz...")]
        public string Email { get; set; }

    }
}