using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMeds.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//div[@class ='actionspd'])[2]")]
        public IWebElement? AddToCartButton { get; set; }
        [FindsBy(How = How.Id, Using = "minicart_btn")]
        public IWebElement? GoToCartButton { get; set; }

        //[FindsBy(How = How.ClassName, Using = "//i[@class ='fa fa-angle-down prev']")]
        //public IWebElement? AvailabilityText { get; set; }

        public void AddToCartButtonClick()
        {

            CoreCodes.ScrollIntoView(driver, driver.FindElement( By.XPath("//div[text()='Availability & Expiry']")));

            Thread.Sleep(5000);


            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton));

           AddToCartButton?.Click();
        }
        public CheckoutPage GoToCartButtonClick()
        {
           
            GoToCartButton?.Click();
            return new CheckoutPage(driver);
        }
    }
}
