namespace HaberPortali.Dtos
{
    public class FileDto
    {

        public int? Id { get; set; } 
        public string File_Name { get; set; }  
        // user id eklenecek   
        public IFormFile file { get; set; }
        public string? UserId { get; set; }  
        public string? FilePath { get; set; }


    }
}