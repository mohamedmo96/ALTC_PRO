namespace ALTC_Site.ViewModels
{
    public class DeptVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? Describtion { get; set; }
        public string? lang { get; set; }
        public IFormFile? File { get; set; }
    }
}
