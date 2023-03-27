using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Drivers;

namespace TestFramework.Tests.DriverTests
{
    [TestFixture]
    public class DriverFactoryTest
    {
        DriverManager driverManager;
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driverManager = DriverManagerFactory.GetManager(DriverType.EDGE);
            driver = driverManager.GetDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driverManager.QuitDriver();

        [Test]
        public void LaunchGoogleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.AreEqual("Google", driver.Title);
        }
    }
}
