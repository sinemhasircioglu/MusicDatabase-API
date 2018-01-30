using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDatabase.API.Data;
using MusicDatabase.API.Data.Entities;

namespace MusicDatabase.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Genres")]
    public class GenresController : Controller
    {
        private MusicDbContext dbContext;
        public GenresController(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Genres
        [HttpGet]
        public IActionResult Get()
        {
            var genres = dbContext.Genres;
            if (genres == null) return NotFound(new BaseAPIResponse()
            {
                Message = "Herhangi bir veri yok"
            });
            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = genres
            });
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });

            var genre = dbContext.Genres.SingleOrDefault(g => g.Id == id.Value);
            if (genre == null) return NotFound(new BaseAPIResponse()
            {
                Message = $"{id.Value} bulunamadı"
            });

            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = genre
            });
        }

        // POST: api/Genres
        [HttpPost]
        public IActionResult Post([FromBody]Genre genre)
        {
            if (genre == null) return BadRequest(new BaseAPIResponse()
            {
                Message = "Boş geçilemez",
                IsSuccess = false
            });
            dbContext.Genres.Add(genre);
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = genre,
                    Message = "Başarıyla eklendi"
                });
            }
            catch 
            {
                return BadRequest(new BaseAPIResponse()
                {
                    Message = "Bir hata oluştu",
                    IsSuccess = false
                });
            }
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]Genre newGenre)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            newGenre.Id = id.Value;
            dbContext.Genres.Update(newGenre);
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = newGenre,
                    Message = "Güncellendi"
                });
            }
            catch 
            {
                return BadRequest(new BaseAPIResponse()
                {
                    Message = "Bir hata oluştu",
                    IsSuccess = false
                });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            dbContext.Genres.Remove(new Genre()
            {
                Id = id.Value
            });
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Message = "Başarıyla silindi"
                });
            }
            catch 
            {
                return BadRequest(new BaseAPIResponse()
                {
                    Message = "Bir hata oluştu",
                    IsSuccess = false
                });
            }
        }
    }
}
