using AutoMapper;
using HaberPortali.Dtos;
using HaberPortali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HaberPortali.Controllers
{
    [Route("api/Categories/[Action]")]
    [ApiController]
    [Authorize]
    public class CategroiesController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public CategroiesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        [HttpGet]
        public List<CategoryDto> GetList()
        {
            var categories = _context.Categories.ToList();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public CategoryDto Get(int id)
        {
            var categories = _context.Categories.Where(s => s.CategoryId == id).SingleOrDefault();
            var categoryDto = _mapper.Map<CategoryDto>(categories);
            return categoryDto;
        }



        [HttpGet]
        [Route("{id}/News")]

        public List<NewsDto> GetNewsByCategory(int id)
        {
            var news = _context.News.Where(s => s.Id == id).ToList();
            var newsDtos = _mapper.Map<List<NewsDto>>(news);
            return newsDtos;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ResultDto> Post(CategoryDto dto)
        {

            try
            {

                var category = _mapper.Map<Category>(dto);
                
                _context.Categories.Add(category);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Kategori Eklendi.";
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }



        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ResultDto Delete(int id)
        {
            try
            {
                var category = _context.Categories.Where(s => s.CategoryId == id).SingleOrDefault();
                if (category == null)
                {
                    result.Status = false;
                    result.Message = "Kategori Bulunamadı!";
                    return result;
                }
                _context.Categories.Remove(category);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Kateogori Silindi";
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
        public ResultDto Put(CategoryDto dto)
        {
            

            var category = _context.Categories.Where(s => s.CategoryId == dto.CategoryId).SingleOrDefault();
            if (category == null)
            {
                result.Status = false;
                result.Message = "kKateogri Bulunamadı!";
                return result;
            }
           category.CategoryName = dto.CategoryName;
            category.CategoryId = dto.CategoryId;
            _context.Categories.Update(category);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Kategori Düzenlendi";
            return result;
        }




    }
}
