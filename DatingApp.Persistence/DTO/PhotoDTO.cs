namespace DatingApp.Persistence.DTO
{
    public class PhotoDTO
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
