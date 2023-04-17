using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.PageObjects.Pages;
using TestFramework.Tests;

namespace TestFramework.PageObjects
{
    public class PageManager:BaseTest
    {
        public static HomePage homePage;
        public static SearchResultsPage searchResultsPage;
        public static ProductPage productPage;
        public static CartPage cartPage;
        public static LoginPage loginPage;

        public static void Init(IWebDriver driver)
        {
            homePage = new HomePage(driver);
            searchResultsPage= new SearchResultsPage(driver);   
            productPage= new ProductPage(driver);   
            cartPage= new CartPage(driver);
            loginPage= new LoginPage(driver);
        }

    }
}
