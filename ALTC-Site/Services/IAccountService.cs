using ALTC_Site.Models;

namespace ALTC_Site.Services
{
    public interface IAccountService
    {
        bool IsAuthenticated(string email, string password);
        Account Get(string email, string password);
        List<Account> GetAll();
        public Account GetById(string id);
        void Delete(string id);
        void Add(Account account);
    }
}
