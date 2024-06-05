using AutoMapper;
using HaberPortali.Dtos;
using HaberPortali.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using static HaberPortali.Service.ManageImage;
using static HaberPortali.Service.ImanageImage;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HaberPortali.Controllers
{
    

    [Route("api/File/[action]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IManageImage _iManageImage;
        ResultDto result = new ResultDto();

        public FileController(AppDbContext context, IMapper mapper, IManageImage iManageImage)
        {
            _context = context;
            _mapper = mapper;
            _iManageImage = iManageImage;

        }
        [HttpGet]
        public List<FileDto> GetList()
        {
            var files = _context.Files.ToList();
            var FileDtos = _mapper.Map<List<FileDto>>(files);
            return FileDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public FileDto Get(int id)
        {
            var file = _context.Files.Where(s => s.Id == id).SingleOrDefault();
            var fileDto = _mapper.Map<FileDto>(file);   
            return fileDto;
        }

        [HttpPost]
        //[Authorize(Roles = "Gazeteci")]
        public async Task<ResultDto> UploadFile([FromForm] IFormFile file, [FromForm] FileDto dto)
        {
            ResultDto result = new ResultDto();
            try
            {

                var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                var userId = usernameClaim?.Value.ToString();


                var fileName = await _iManageImage.UploadFile(file);


                var fileNew = new Models.File  
                {

                    UserId = userId,
                    FilePath = fileName,
                    File_Name= dto.File_Name,
                    Updated = DateTime.Now,
                    Created = DateTime.Now
                };


                _context.Files.Add(fileNew);
                await _context.SaveChangesAsync();


                result.Status = true;
                result.Message = "File eklendi " + fileName;
            }
            catch (Exception ex)
            {
                // Hata durumunu ve mesajını ayarlıyoruz
                result.Status = false;
                result.Message = "Hata oluştu: " + ex.Message;
            }

            // Sonucu döndürüyoruz
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ResultDto Delete(int id)
        {
            var file = _context.Files.Where(s => s.Id == id).SingleOrDefault();
            if (file == null)
            {
                result.Status = false;
                result.Message = "Dosya Bulunamadı!";
                return result;
            }
            _context.Files.Remove(file);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Dosya Silindi";
            return result;
        }
        

    }
}
