using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class RegServicePositiveTests
    {
        private RegService _svc;
        [TestInitialize] public void Init() => _svc = new RegService();

        [TestMethod]
        public void Register_ValidNewUser_ReturnsTrue()
        {
            string unique = "t" + Guid.NewGuid().ToString("N").Substring(0, 8);
            Assert.IsTrue(_svc.Register(
                fio: "Test User",
                login: unique,
                password: "abc123",
                confirmPassword: "abc123"));
        }
    }
}
