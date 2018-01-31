using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Models.User
{
    public class LoginModel
    {
        [MinLength(5,ErrorMessage ="Lütfen en az 5 karakterli kullanıcı adı giriniz.")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Şifre boş geçilemez")]
        [MaxLength(32,ErrorMessage ="Lütfen şifrenizi 8 ile 32 karakter arasında giriniz.")]
        [MinLength(8,ErrorMessage ="Lütfen şifrenizi 8 ile 32 karakter arasında giriniz.")]
        public string Password { get; set; }
    }
}
