using OpenQA.Selenium;
using TestFramework.Utilities.Enums;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class OrderProcessPage : BasePage
    {
        public OrderProcessPage(IWebDriver driver) : base(driver) { }


        private IWebElement phoneNumberField => LocateElement(LocatorType.Xpath, "//input[contains(@placeholder,'Введіть номер телефону')]");
        private IWebElement nameField=> LocateElement(LocatorType.Xpath, "//input[contains(@placeholder,'Введіть ваше ім')]");
        private IWebElement surnameField => LocateElement(LocatorType.Xpath, "//input[contains(@placeholder,'Введіть ваше прізвище')]");
        private IWebElement emailField => LocateElement(LocatorType.Xpath, "//input[contains(@placeholder,'Введіть ваш email')]");

        public OrderProcessPage FillOrderForm(string number, string name, string surname, string email)
        {
            WaitForPageLoadingComplete(driver);
            phoneNumberField.SendKeys(number);
            nameField.SendKeys(name);
            surnameField.SendKeys(surname);
            emailField.SendKeys(email);
            return this;
        }

    }
}
