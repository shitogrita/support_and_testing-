using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class AuthServiceNegativeTests
    {
        private AuthService _svc;
        [TestInitialize] public void Init() => _svc = new AuthService();

        [TestMethod]
        public void EmptyCredentials_ReturnsFalse()
            => Assert.IsFalse(_svc.Authenticate("", ""));

        [TestMethod]
        public void InvalidCredentials_ReturnsFalse()
            => Assert.IsFalse(_svc.Authenticate("no_user", "wrong"));
    }
}
