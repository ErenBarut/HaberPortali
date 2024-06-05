namespace HaberPortali.Dtos
{
    public class GetFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
