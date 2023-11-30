using NetMeds.PageObjects;
using NetMeds.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using SeleniumExtras.WaitHelpers;

namespace NetMeds.TestScripts
{
    internal class HomepageTest : CoreCodes
    {

        [Test, Order(1), Category("Smoke Test")]

        public void BeautyLinkTest()
        {

            var homePage = new NetMedsHomePage(driver);

            var fluentWait = Wait(driver);

            if (!driver.Url.Equals("https://www.NetMeds.com/"))
            {
                driver.Navigate().GoToUrl("https://www.NetMeds.com/");
            }


            try
            {
                IWebElement beauty = driver.FindElement(By.XPath("(//a[text()='Beauty'][1])"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(beauty).Build().Perform();
                //Thread.Sleep(3000);
                homePage.FaceMakeUpClick();
                Assert.That(driver.Url.Contains("face-makeup"));
                LogTestResult("Beauty Link Test", "Beauty Link Test passed");
                test = extent.CreateTest("Beauty link Test - Pass");
                test.Pass("Beauty link test passed");

            }
            catch (AssertionException ex)
            {

                LogTestResult("Beauty Link Test", "Beauty Link Test Failed failed", ex.Message);
                test = extent.CreateTest("Add to cart Test - Fail");
                test.Fail("Add to cart Link failed");
            }
        }
        [Test, Order(2), Category("Smoke Test")]
        public void WellnessLinkTest()
        {

            var homePage = new NetMedsHomePage(driver);


            try
            {
                if (!driver.Url.Equals("https://www.NetMeds.com/"))
                {
                    driver.Navigate().GoToUrl("https://www.NetMeds.com/");
                }

                IWebElement wellness = driver.FindElement(By.XPath("//a[@class='h-pro'][normalize-space()='Wellness']"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(wellness).Build().Perform();
                //Thread.Sleep(3000);
                homePage.BathAndShowerLinkClick();
                Assert.That(driver.Url.Contains("bath-shower"));
                LogTestResult("Wellness Link Test", "Wellness Link Test passed");
                test = extent.CreateTest("Wellness link Test - Pass");
                test.Pass("Wellness Link Test Passed");


            }
            catch (AssertionException ex)
            {

                LogTestResult("Well Link Test", "Wellness link Test Failed failed", ex.Message);
                test = extent.CreateTest("Wellness link Test - Fail");
                test.Fail("Wellness Link failed");
            }

        }
        [Test, Order(3), Category("Smoke Test")]
        public void SearchTest()
        {
            if (!driver.Url.Equals("https://www.NetMeds.com/"))
            {
                driver.Navigate().GoToUrl("https://www.NetMeds.com/");
            }

            var homePage = new NetMedsHomePage(driver);
            var fluentWait = Wait(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Netmeds";

            List<SearchData> searchDataList = ExcelUtils.ReadSignUpData(excelFilePath, sheetName);
            try
            {
                foreach (var searchData in searchDataList)
                {
                    Thread.Sleep(1000);
                    string? getSearchText = searchData.searchText;
                    homePage.TypeSearch(getSearchText);
                    Log.Information("Search text entered");
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("vicks"));
                    LogTestResult("Search function test", "Search function test passed");
                    test = extent.CreateTest("Search function Test - Pass");
                    test.Pass("Search function test passed");
                }
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search function test", "Search function test failled", ex.Message);
                test = extent.CreateTest("Search function Test - Fail");
                test.Fail("Search function test failed");
            }
        }
        [Test, Order(4), Category("Smoke Test")]
        public void OfferLinkTest()
        {
            if (!driver.Url.Equals("https://www.NetMeds.com/"))
            {
                driver.Navigate().GoToUrl("https://www.NetMeds.com/");

            }
            try
            {
                var homePage = new NetMedsHomePage(driver);
                homePage.OffersLinkClick();
                Log.Information("Offers Link clicked");
                Assert.That(driver.Url.Contains("offers"));
                LogTestResult("Offers link test", "Offers link test passed");
                test = extent.CreateTest("offers link Test - Pass");
                test.Pass("offers link test passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Offers link test", "Offers link test failed", ex.Message);
                test = extent.CreateTest("Offers link Test - Fail");
                test.Fail("Offers link test failed");
            }

        }
        [Test, Order(5), Category("Smoke Test")]
        public void PinCodeChangeTest()
        {
            if (!driver.Url.Equals("https://www.NetMeds.com/"))
            {
                driver.Navigate().GoToUrl("https://www.NetMeds.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Netmeds";

            List<SearchData> searchDataList = ExcelUtils.ReadSignUpData(excelFilePath, sheetName);
            var homepage = new NetMedsHomePage(driver);
            foreach (var searchData in searchDataList)
            {

                try
                {
                    string? getPincode = searchData.Pincode;
                    homepage.TypePincode(getPincode);
                    var fluentWait = Wait(driver);
                    Thread.Sleep(1000);
                    //fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='delivery_details']//span")));
                    //fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='container_div10'][1])")));
                    Assert.That(driver.FindElement(By.XPath("//span[@id='delivery_details']//span")).Text.Equals(getPincode));

                    LogTestResult("Pincode change test", "Pincode change test passed");
                    test = extent.CreateTest("Pincode Change Test - Pass");
                    test.Pass("Pincode change test passed");
                }
                catch (AssertionException ex)
                {
                    LogTestResult("Pincode change test", "Pincode change test failed", ex.Message);
                    test = extent.CreateTest("Pincode change test - Fail");
                    test.Fail("Pincode change test failed");
                }

            }

        }
        [Test, Order(5), Category("Smoke Test")]
        public void InvalidPincodeTest()
        {
            
            if (!driver.Url.Equals("https://www.NetMeds.com/"))
            {
                driver.Navigate().GoToUrl("https://www.NetMeds.com/");

            }
            var homepage = new NetMedsHomePage(driver);
            try {
                homepage.TypePincode("465678");
                var fluentWait = Wait(driver);
                Assert.That(fluentWait.Until(d=> driver.FindElement(By.Id("rel_pin_msg")).Text.Equals("invalid pincode")));
                LogTestResult("Invalid Pincode Test", "Invalid Pincode test passed");
                test = extent.CreateTest("Invalid pincode test - pass");
                test.Pass("Invalid Pincode test passed");



            }
                catch (AssertionException ex)
                {
                    LogTestResult("Invalid Pincode test", "Invalid Pincode test failed", ex.Message);
                    test = extent.CreateTest("Invalid Pincode test Test - Fail");
                    test.Fail("Invalid Pincode test failed");
                }

            }

        }
    }


    

