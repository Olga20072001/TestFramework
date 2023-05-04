using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Drivers;

namespace TestFramework.Tests.DriverTests
{
    [TestFixture]
    public class DriverFactoryTest: BaseTest
    {

        [Test]
        public void LaunchGoogleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.AreEqual("Google", driver.Title);
        }
    }
}
