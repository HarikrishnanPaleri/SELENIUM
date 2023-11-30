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

namespace NetMeds.TestScripts
{
    internal class HomepageTest : CoreCodes
    {

        [Test, Order(1), Category("Smoke Test")]

        public void BeautyLinkTest()
        {

            var homePage = new NetMedsHomePage(driver);

            var fluentWait = Wait(driver);




            try
            {

                IWebElement beauty = driver.FindElement(By.XPath("(//a[text()='Beauty'][1])"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(beauty).Build().Perform();
                //Thread.Sleep(3000);
                homePage.FaceMakeUpClick();
                Assert.That(driver.Url.Contains("face-makeup"));
                LogTestResult("Beauty Link Test", "Beauty Link Test passed");
                test = extent.CreateTest("Add to cart Test - Fail");
                test.Fail("Add to cart Link failed");

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
                test.Fail("Wellness Link Test Passed");


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
                    test.Fail("Search function test passed");
                }
            }
            catch (AssertionException ex) 
            {
                LogTestResult("Search function test", "Search function test failled", ex.Message);
                test = extent.CreateTest("Search function Test - Fail");
                test.Fail("Search function test failed");
            }
} } }

    

