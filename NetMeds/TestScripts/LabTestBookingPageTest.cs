using NetMeds.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetMeds.TestScripts
{
    internal class LabTestBookingPageTest : CoreCodes
    {
        [Test, Order(1), Category("Smoke Test")]
        public void InvalidNameTest()
        {
            var fluentWait = Wait(driver);
            var bookingPage = new BookingPage(driver);
            
                if (!driver.Url.Equals("https://www.netmeds.com/health-packages/"))
                {
                    driver.Navigate().GoToUrl("https://www.netmeds.com/health-packages/");
                }
            try { 

                bookingPage.NameEnter("@13adf");
                TakeScreenshot();
                Assert.That(fluentWait.Until(d => driver.FindElement(By.XPath("//div[@id ='fname-input-error']")).Text.Equals("Your Name must contain only alphabets!")));
                LogTestResult("Invalid Name test", "Invalid Name test passed");
                test = extent.CreateTest("Invalid Name test Test - Pass");
                test.Pass("Invalid Name test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Invalid Name test", "Invalid Name test failed", ex.Message);
                test = extent.CreateTest("Invalid Name test Test - Fail");
                test.Fail("Invalid Name test failed");
            }
     }
        [Test, Order(2), Category("Smoke Test")]
        public void InvalidPhoneNumberTest()
        {
            var fluentWait = Wait(driver);
            var bookingPage = new BookingPage(driver);

            if (!driver.Url.Equals("https://www.netmeds.com/health-packages/"))
            {
                driver.Navigate().GoToUrl("https://www.netmeds.com/health-packages/");
            }
            try
            {

                bookingPage.NumberEnter("123445");
                TakeScreenshot();
                Assert.That(fluentWait.Until(d => driver.FindElement(By.XPath("//div[@class ='form_error']")).Text.Equals("Please enter a valid Mobile number!")));
                Thread.Sleep(1000);
                LogTestResult("Invalid Mobilenumber test", "Invalid Mobilenumber test passed");
                test = extent.CreateTest("Invalid Mobilenumber Test - Pass");
                test.Pass("Invalid MobileNumber test failed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Invalid MobileNumber test", "Invalid MobileNumber test failed", ex.Message);
                test = extent.CreateTest("Invalid MobileNumber Test - fail");
                test.Fail("Invalid MobileNumber test failed");
            }
        }
       
    }
}