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
    internal class ProductList
    {
        IWebDriver driver;
        public ProductList(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        public ProductPage ProductSelectClick(string position)
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            int intposition= Convert.ToInt32(position);
            intposition--;
            fluentWait.Until(d => driver.FindElement(By.XPath("//li[@class='ais-InfiniteHits-item'][" + intposition.ToString() + "]")).Displayed == true);
            driver.FindElement(By.XPath("//li[@class='ais-InfiniteHits-item']["+ intposition.ToString()+"]")).Click();
            return new ProductPage(driver);
        }
    }
}
