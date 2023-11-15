using ALTC_WebSite.Models;

namespace ALTC_Site.Services
{
    public interface IDepartment
    {
        void Create(Department department);

        void Delete(string id);

        List<Department> GetAll();
        Department GetById(string id);
        void Update(Department department);
        List<Department> GetBylang(string lang);

    }
}
