using System.Linq;
using WpfApp2;

namespace WpfApp2.Services
{
    public class AuthService
    {
        public bool Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;

            using (var db = new akmetova_dbEntities())
            {
                return db.User.Any(u => u.Login == login && u.Password == password);
            }
        }
    }
}
