namespace ALTC_Site.ViewModels
{
    public class TeamVM
    {
         public string? Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}