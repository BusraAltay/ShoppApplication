using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="İsminizi giriniz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrenizi kontrol ediniz.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "E-mail adresinizi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
