using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicDatabase.API.Data;
using MusicDatabase.API.Data.Entities;

namespace MusicDatabase.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Artists")]
    public class ArtistsController : Controller
    {
        private MusicDbContext dbContext;
        public ArtistsController(MusicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/Artists
        [HttpGet]
        public IActionResult Get()
        {
            var artists = dbContext.Artists;
            if (artists == null) return NotFound(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Herhangi bir veri bulunamadı"
            });
            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = artists
            });
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            var artist = dbContext.Artists.SingleOrDefault(a => a.Id == id.Value);
            if (artist == null) return NotFound(new BaseAPIResponse()
            {
                Message = $"{id.Value} bulunamadı"
            });

            return Ok(new BaseAPIResponse()
            {
                IsSuccess = true,
                Result = artist
            });
        }
        
        // POST: api/Artists
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Artist artist)
        {
            if (artist == null) return BadRequest(new BaseAPIResponse()
            {
                Message = "Boş geçilemez",
                IsSuccess = false
            });
            dbContext.Artists.Add(artist);
            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Result = artist,
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
        
        // PUT: api/Artists/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int? id, [FromBody]Artist newArtist)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            newArtist.Id = id.Value;
            dbContext.Artists.Update(newArtist);

            try
            {
                dbContext.SaveChanges();
                return Ok(new BaseAPIResponse()
                {
                    IsSuccess = true,
                    Message = "Başarıyla güncellendi",
                    Result=newArtist
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
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseAPIResponse()
            {
                IsSuccess = false,
                Message = "Geçersiz Id Girdiniz"
            });
            dbContext.Artists.Remove(new Artist()
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
