using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Serilog;
using static TestFramework.PageObjects.PageManager;

namespace TestFramework.Tests
{
    [AllureNUnit]
    [TestFixture]
    [AllureSuite("HomePageTests")]
    [AllureEpic("Shop tests")]
    public class HomePageTests:BaseTest
    {
        [Test(Description = "Verifying title on the HomePage")]
        [AllureTag("Smoke")]
        [AllureStory("Verifying title on the HomePage")]
        [AllureStep("Verifying title on the HomePage")]
        public void VerifyHomePageTitle()
        {
            Log.Information("VerifyPageTitle()");
            homePage.GoToUrl(baseUrl);
            Assert.AreEqual(homePageTitle, homePage.GetTitle());
        }

    }
}
