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
    internal class BookingPage
    {
        IWebDriver driver;
        public BookingPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "fname-input")]
        [CacheLookup]
        private IWebElement? NameInput { get; set; }

        [FindsBy(How = How.Name, Using = "diagnosis_mobi")]
        [CacheLookup]
        private IWebElement? MobileNumber { get; set; }

        [FindsBy(How = How.Name, Using = "diagnosis_pincode")]
        private IWebElement? EnterPin { get; set; }

        [FindsBy(How = How.Id, Using = "diagnosis_states")]
        private IWebElement?Drop1 { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Select test']")]
        private IWebElement? Drop2 { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement? Terms { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement? Bookbuton { get; set; }

        //input[@type='checkbox']
        public void BookingDetails(string name, string mobilenumber, string pin)
        {
            //IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            NameInput?.SendKeys(name);
            MobileNumber?.SendKeys(mobilenumber);
            EnterPin?.SendKeys(pin);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.Id("fname-input")));
            Thread.Sleep(2000);
            Drop1?.Click();
            //Thread.Sleep(1000);
            //Thread.Sleep(1000);
            SelectElement selectPackage = new(Drop1);
            selectPackage.SelectByValue("Aarogyam C");
          
            //Thread.Sleep(2000);

            Drop2?.SendKeys("Diabetes");
            Drop2.SendKeys(Keys.Enter);
            //SelectElement selectTest = new(Drop2);
            //selectPackage.SelectByValue("Diabetes");
            Terms?.Click();
            Bookbuton?.Click();
           // Thread.Sleep(2000);



            //CreateAccountButton?.Click();
        }
       public void NameEnter(string name)
        {
            NameInput?.SendKeys(name);
          
        }
        public void NumberEnter(string num)
        {
            MobileNumber?.SendKeys(num);

        }


    }
}
