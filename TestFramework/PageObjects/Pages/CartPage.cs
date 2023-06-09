﻿using OpenQA.Selenium;
using TestFramework.Utilities;
using TestFramework.Utilities.Enums;
using static TestFramework.Utilities.WaitingHelper;

namespace TestFramework.PageObjects.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private IWebElement cartTitle => LocateElement(LocatorType.Xpath, "//p[@class='headline headline--level2-bold basket__headline']");
        private IList<IWebElement> cartItems => LocateElements(LocatorType.Xpath, "//div[@class='basket-products__group-item']");
        private IList<IWebElement> deleteProductFromCartBtn => LocateElements(LocatorType.Xpath, "//button[@class='basket-product__del--link']");
        private IWebElement emptyCartMassage => LocateElement(LocatorType.Xpath, "//p[@class='basket-empty__message']");
        private IWebElement goToProductListBtn => LocateElement(LocatorType.Xpath, "//p[@class='basket-empty__message']//a");
        private IWebElement closeCartBth => LocateElement(LocatorType.Xpath, "//div[contains(@class,'cart-popup')]//button[@title='Close']");
        private IWebElement makeAPurchaseBtn => LocateElement(LocatorType.Xpath, "//button[contains(@class,'purchase-btn')]");

        public string GetCartTitle()
        {
            WaitForPageLoadingComplete(driver);
            ElementsIsPresent(driver, "//p[@class='headline headline--level2-bold basket__headline']");
            return GetText(cartTitle);
        }
        public uint GetItemsCountInCart()
        {
            WaitForPageLoadingComplete(driver);
            ElementIsPresent(driver, "//div[@class='basket-products__group-item']");
            return (uint)cartItems.Count;
        }
        public CartPage DeleteAllProductsFromCart()
        {
            for(int i=0;i<cartItems.Count;i++)
            {
                deleteProductFromCartBtn[i].Click();
            }
            return new CartPage(driver);
        }
        public string EmptyCartMessageIsVisible()
        {
            return GetText(emptyCartMassage);
        }
        public SearchResultsPage CloseCart()
        {
            ClickAndWaitForPageToLoad(driver, closeCartBth);
            return new SearchResultsPage(driver);
        }
        public void MakeAPurchase()
        {
            makeAPurchaseBtn.Click();
        }

    }
}
