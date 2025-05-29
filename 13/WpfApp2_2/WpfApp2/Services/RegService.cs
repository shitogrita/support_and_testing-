using System.Linq;
using WpfApp2;            // модель данных


namespace WpfApp2.Services
{
    public class RegService
    {
        public bool Register(string fio, string login, string password, string confirmPassword)
        {
            if (new[] { fio, login, password, confirmPassword }.Any(string.IsNullOrEmpty))
                return false;

            using (var db = new akmetova_dbEntities())
                if (db.User.Any(u => u.Login == login))
                    return false;

            if (password.Length < 6 || !password.All(c => c < 128) || !password.Any(char.IsDigit))
                return false;
            if (password != confirmPassword)
                return false;

            using (var db = new akmetova_dbEntities())
            {
                db.User.Add(new User { FIO = fio, Login = login, Password = password });
                db.SaveChanges();
            }
            return true;
        }
    }
}
