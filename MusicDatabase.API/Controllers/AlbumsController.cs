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
    [Route("api/Albums")]
    public class AlbumsController : Controller
    {
        private MusicDbContext dbContext;
        public AlbumsController(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Albums
        [HttpGet]
        public IActionResult Get()
        {
            var albums = dbContext.Albums;
            if (albums == null) return NotFound(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Herhangi bir veri yok"
            });
            return Ok(new BaseAPIResponse()
            {
                IsSuccess=true,
                Result=albums
            });
        }

        // GET: api/Albums/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            var album = dbContext.Albums.SingleOrDefault(a => a.Id == id.Value);
            if (album == null) return NotFound(new BaseAPIResponse()
            {
                Message = $"{id.Value} bulunamadı"
            });

            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = album
            });
        }
        
        // POST: api/Albums
        [HttpPost]
        public IActionResult Post([FromBody]Album album)
        {
            if (album == null) return BadRequest(new BaseAPIResponse()
            {
                Message = "Boş geçilemez",
                IsSuccess = false
            });
            dbContext.Albums.Add(album);
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = album,
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
        
        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]Album newAlbum)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });

            newAlbum.Id = id.Value;
            dbContext.Albums.Update(newAlbum);

            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = newAlbum,
                    Message = "Güncellendi"
                });
            }
            catch (Exception)
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

            dbContext.Albums.Remove(new Album()
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
            catch (Exception)
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
