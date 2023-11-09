using ALTC_WebSite.Models;

namespace ALTC_Website.Services
{
    public interface IComplainService
    {
        void Add(Complain newComplain);
        Complain GetComplaintById(string id);
        List<Complain> GetAllComplaints();
    }
}
