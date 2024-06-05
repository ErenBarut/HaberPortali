using AutoMapper;
using HaberPortali.Dtos;
using HaberPortali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HaberPortali.Controllers
{
    [Authorize]
    [Route("api/News/[Action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public NewsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }
        [HttpGet]
        public List<NewsDto> GetList()
        {
            var news = _context.News.ToList();
            var newsDtos = _mapper.Map<List<NewsDto>>(news);
            return newsDtos;
        }

        [HttpGet]
        [Route("{id}")]
       
        public NewsDto Get(int id)
        {
            var news = _context.News.Where(s => s.Id == id).SingleOrDefault();
            var newsDto = _mapper.Map<NewsDto>(news);
            return newsDto;
        }
        [HttpPost]
        [Authorize(Roles = "Gazeteci")]

        public async Task<ResultDto> Post(NewsDto dto)
        {
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userID = usernameClaim.Value.ToString();

            ;
            
            try
            {

                var news = _mapper.Map<News>(dto);  
                news.CreatedDate = DateTime.Now;
                news.UpdatedDate = DateTime.Now;

                news.UserId = userID;

                _context.News.Add(news);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Haber Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin")]

        public ResultDto Put(NewsDto dto)
        {
            var usernameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userID = usernameClaim.Value.ToString();

            var news = _context.News.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (news == null)
            {
                result.Status = false;
                result.Message = "Haber Bulunamadı!";
                return result;
            }
            news.Title = dto.Title;
            news.Content= dto.Content;
            news.UserId = userID;
            news.UpdatedDate = DateTime.Now;
            news.CreatedDate = dto.CreatedDate;
            _context.News.Update(news);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Haber Düzenlendi";
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]

        public ResultDto Delete(int id)
        {
            var news = _context.News.Where(s => s.Id == id).SingleOrDefault();
            if (news == null)
            {
                result.Status = false;
                result.Message = "Haber Bulunamadı!";
                return result;
            }
            _context.News.Remove(news);
            _context.SaveChanges(); 
            result.Status = true;
            result.Message = "Haber Silindi";
            return result;
        }












    }
}