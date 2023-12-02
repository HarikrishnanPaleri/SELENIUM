using NetMeds.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMeds.TestScripts
{
    internal class SearchResultPageTest : CoreCodes
    {
        [Test, Order(1), Category("Smoke Test")]
        public void NetmedsIconClickTest()
        {
            var fluentWait = Wait(driver);
            var prodPage = new ProductList(driver);
            if (!driver.Url.Equals("https://www.netmeds.com/catalogsearch/result/vicks/all/"))
            {
                driver.Navigate().GoToUrl("https://www.netmeds.com/catalogsearch/result/vicks/all/");
            }
            try
            {
                prodPage.LogoButtonClik();
                Log.Information("Logo button clicked");
                TakeScreenshot();
                Assert.That(fluentWait.Until(d => driver.Url.Equals("https://www.netmeds.com/")));
                LogTestResult("Netmeds Icon test", "Netmeds Icon  test passed");
                test = extent.CreateTest("Netmeds Icon Test - Pass");
                test.Pass("Netmeds Icon test failed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Netmeds Icon test", "Netmeds Icon  test passed", ex.Message);
                test = extent.CreateTest("Netmeds Icon Test - Pass");
                test.Fail("Netmeds Icon test failed");
            }
        }
        [Test, Order(2), Category("Smoke Test")]
        public void SortByDiscountTest()
        {
            var fluentWait = Wait(driver);
            var bookingPage = new BookingPage(driver);

            if (!driver.Url.Equals("https://www.netmeds.com/catalogsearch/result/vicks/all"))
            {
                driver.Navigate().GoToUrl("https://www.netmeds.com/catalogsearch/result/vicks/all");
            }
            try
            {
                var prodPage = new ProductList(driver);
                prodPage.SortByDiscountButtonClick();
                Log.Information("Discount button clicked");
                TakeScreenshot();
                Assert.That(driver.FindElement(By.XPath("//span[@class='save-badge']")).Text.Contains("% OFF"));
                LogTestResult("Sort By Discount test", "Sort By Discount test pass");
                test = extent.CreateTest("Sort By Discount Test - pass");
                test.Pass("Sort By Discount test pass");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Sort By Discount test", "Sort By Discount test failed", ex.Message);
                test = extent.CreateTest("Sort By Discount Test - fail");
                test.Fail("Sort By Discount test failed");
            }
        }
        [Test, Order(3), Category("Smoke Test")]
        public void CheckBoxTest()
        {
            var fluentWait = Wait(driver);
            var bookingPage = new BookingPage(driver);

            if (!driver.Url.Equals("https://www.netmeds.com/catalogsearch/result/vicks/all"))
            {
                driver.Navigate().GoToUrl("https://www.netmeds.com/catalogsearch/result/vicks/all");
            }
            try
            {
                var prodPage = new ProductList(driver);
                //Thread.Sleep(1000);
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@type='checkbox'])[2]")));
                prodPage.CheckboxClick();
                Log.Information("Checkbox clicked");
                //Thread.Sleep(1000);
                TakeScreenshot();
                Assert.That(driver.FindElement(By.XPath("//span[@class='clsgetname']")).Text.Contains("Kofol"));
                LogTestResult("Check box test", "Checkbox test pass");
                test = extent.CreateTest("Checkbox Test - pass");
                test.Pass("CheckBox test pass");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Checkbox Test", "Checkbox Test failed", ex.Message);
                test = extent.CreateTest("Checkbox Test - fail");
                test.Fail("Checkbox Test failed");
            }
        }
    }
}
