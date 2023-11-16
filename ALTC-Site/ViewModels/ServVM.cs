namespace ALTC_Site.ViewModels
{
    public class ServVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? Details { get; set; }
        public string? lang { get; set; }
        public IFormFile? File { get; set; }
    }
}
