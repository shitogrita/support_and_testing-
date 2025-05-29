using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class AuthServicePositiveTests
    {
        private AuthService _svc;
        [TestInitialize] public void Init() => _svc = new AuthService();

        [TestMethod]
        public void ValidUsers_ReturnsTrue()
        {
            Assert.IsTrue(_svc.Authenticate("ivanov", "p@ssw0rd"));
            Assert.IsTrue(_svc.Authenticate("petrov", "123456"));
        }
    }
}
