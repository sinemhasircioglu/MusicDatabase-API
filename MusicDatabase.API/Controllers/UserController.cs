using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDatabase.API.Data;
using MusicDatabase.API.Models.User;

namespace MusicDatabase.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private MusicDbContext dbContext;
        public UserController(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // POST: /api/user/login
        [HttpPost("login")]
        [ValidateModel]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            var user = dbContext.Users.SingleOrDefault(u => u.UserName == loginModel.Username && u.Password == loginModel.Password);
            if (user == null) return NotFound(new BaseAPIResponse()
            {
                Message = "Kullanıcı Bulunamadı",
                IsSuccess = false
            });

            string token = TokenHelper.GenerateToken(user.Id, user.UserName, user.Email);
            if (string.IsNullOrEmpty(token)) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Token üretilirken bir hata oluştu"
            });

            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Message = "Giriş yapıldı",
                Result = new
                {
                    AccessToken = token
                }
            });

        }

        // POST: /api/user/register
        [ValidateModel]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel registerModel)
        {
            var isRegister = dbContext.Users.Any(u => u.Email == registerModel.Email.ToLower() || u.UserName == registerModel.UserName.ToLower());
            if (isRegister) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Bu kullanıcı zaten kayıtlı"
            });

            dbContext.Users.Add(new Data.Entities.User()
            {
                Email = registerModel.Email.ToLower(),
                CreatedDate = DateTime.Now,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Password = registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber,
                UserName = registerModel.UserName.ToLower()
            });
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Message = "Kaydedildi"
                });
            }
            catch
            {
                return BadRequest(new BaseAPIResponse()
                {
                    IsSuccess = false,
                    Message = "Kayıt olurken bir hata oluştu"
                });
            }
        }
    }
}
