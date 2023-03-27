using NUnit.Framework;
using static TestFramework.PageObjects.PageManager;

namespace TestFramework.Tests
{
    [TestFixture]
    public class HomePageTests:BaseTest
    {       
        [Test]
        public void VerifyHomePageTitle()
        {
            homePage.GoToUrl(baseUrl);
            Assert.AreEqual(homePageTitle, homePage.GetTitle());
        }

    }
}
