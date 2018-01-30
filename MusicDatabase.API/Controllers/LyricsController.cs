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
    [Route("api/Lyrics")]
    public class LyricsController : Controller
    {
        private MusicDbContext dbContext;
        public LyricsController(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/Lyrics
        [HttpGet]
        public IActionResult Get()
        {
            var lyrics = dbContext.Lyrics;
            if (lyrics == null) return NotFound(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Herhangi bir veri yok"
            });
            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = lyrics
            });
        }

        // GET: api/Lyrics/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });

            var lyric = dbContext.Lyrics.SingleOrDefault(l => l.Id == id.Value);
            if (lyric == null) return NotFound(new BaseAPIResponse()
            {
                Message = $"{id.Value} bulunamadı"
            });

            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = lyric
            });
        }
        
        // POST: api/Lyrics
        [HttpPost]
        public IActionResult Post([FromBody]Lyric lyric)
        {
            if (lyric == null) return BadRequest(new BaseAPIResponse() {
                IsSuccess=false,
                Message="Boş geçilemez"
            });
            dbContext.Lyrics.Add(lyric);

            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Message = "Başarıyla eklendi",
                    Result = lyric
                });
            }
            catch (Exception)
            {
                return BadRequest(new BaseAPIResponse()
                {
                    IsSuccess = false,
                    Message = "Bir hata oluştu"
                });
            }
        }
        
        // PUT: api/Lyrics/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]Lyric newLyric)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            newLyric.Id = id.Value;
            dbContext.Lyrics.Update(newLyric);

            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = newLyric,
                    Message = "başarıyla güncellendi"
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

            dbContext.Lyrics.Remove(new Lyric()
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
