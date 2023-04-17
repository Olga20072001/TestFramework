using Atata;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestFramework.PageObjects.SkyUpPages;

namespace TestFramework.Tests.SkyUpTests
{
    [AllureNUnit]
    [TestFixture]
    [AllureSuite("SkyUpUIAtataTests")]
    [AllureEpic("SkyUp Tests")]
    public class SkyUpUIAtataTests: SkyUpBaseTest
    {
        [Test]
        [AllureTag("Login")]
        [AllureStory("Verifying user can log in")]
        [AllureStep("Verifying user can log in")]
        public void Login()
        {
            Go.To<HomePage>()
                .logIn.ClickAndGo<LoginPage>()
                .WaitSeconds(2)
                .firstLogIn.Click()
                .WaitSeconds(2)
                .email.Set("pohoba6140@fitzola.com")
                .password.Set("Carl194854")
                .secondLogIn.ClickAndGo<HomePage>()
                .WaitSeconds(2)
                .cabinetBtn.Click()
                .WaitSeconds(2)
                .cabinetUserName.Get(out string cabinetUserNameValue)
                .Report.Screenshot();

            cabinetUserNameValue.Should().Equals("Carl");
        }
        [Test]
        [AllureStory("Verifying menu items count")]
        [AllureStep("Verifying menu items count")]
        public void MenuItemCount()
        {
            Go.To<HomePage>()
                .menuBtn.Click()
                .WaitSeconds(1)
                .menuItemList.Items.Count.Should.Equal(7)
                .menuItemList.Items[1].Content.Should.IgnoringCase.Equal("passengers")
                .menuItemList.Items[1].Click()
                .WaitSeconds(1)
                .passengersMenuItemList.Items.Count.Should.Equal(4);
        }
    }
}
