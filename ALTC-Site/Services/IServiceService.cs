using ALTC_WebSite.Models;

namespace ALTC_WebSite.Services

{
    public interface IServiceService
    {
     

        void Add(Service newService);
        List<Service> GetAllServices();
        Service GetServiceById(string id); // Add this method to get a service by its ID
        void DeleteService(string id);
        void UpdateService(string id, Service updatedService);

    }

}
