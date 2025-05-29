using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class RegServiceNegativeTests
    {
        private RegService _svc;
        [TestInitialize] public void Init() => _svc = new RegService();

        [TestMethod]
        public void EmptyFields_ReturnsFalse()
            => Assert.IsFalse(_svc.Register("", "", "", ""));

        [TestMethod]
        public void DuplicateLogin_ReturnsFalse()
            => Assert.IsFalse(_svc.Register("Иванов", "ivanov", "abc123", "abc123"));

        [TestMethod]
        public void InvalidPasswordRules_ReturnsFalse()
            => Assert.IsFalse(_svc.Register("A B C", "u1", "пароль", "пароль"));

        [TestMethod]
        public void PasswordMismatch_ReturnsFalse()
            => Assert.IsFalse(_svc.Register("A B C", "u2", "abc123", "xyz789"));
    }
}
