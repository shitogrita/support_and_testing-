using System.Linq;
// Пространство имён модели данных
using WpfApp2;

namespace WpfApp2.Services
{
    public class AuthService
    {
        /// <summary>
        /// Возвращает true если в БД есть user.Login/password
        /// </summary>
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
