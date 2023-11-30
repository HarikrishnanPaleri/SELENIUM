using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMeds.PageObjects
{
    internal class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text()='Proceed']")]
        public IWebElement? CheckoutButton { get; set; }

        public SignupPage CheckoutButtonClick()
        {
            
            CoreCodes.ScrollIntoView(driver, CheckoutButton);
             //Thread.Sleep(3000);
            CheckoutButton.Click();
            return new SignupPage(driver);
        }
    }
}
