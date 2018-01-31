using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API.Models.User
{
    public class RegisterModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adınız boş geçilemez")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyadınız boş geçilemez")]
        public string LastName { get; set; }

        [MinLength(5, ErrorMessage = "Lütfen en az 5 karakterli kullanıcı adı giriniz.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Emailiniz boş geçilemez")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Geçersiz E-Mail Adres")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre boş geçilemez")]
        [MaxLength(32, ErrorMessage = "Lütfen şifrenizi 8 ile 32 karakter arasında giriniz.")]
        [MinLength(8, ErrorMessage = "Lütfen şifrenizi 8 ile 32 karakter arasında giriniz.")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
