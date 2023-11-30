using NetMeds.PageObjects;
using NetMeds.Utilities;
using NetMeds;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using OpenQA.Selenium.Support.UI;
using System.Security.Policy;

namespace CaseStudy.TestScripts
{
    [TestFixture]
    internal class BookMedicineTest : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]

        public void AddToCartE2ETest()
        {
            
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
                    string? getPincode = searchData.Pincode;
                    homePage.TypePincode(getPincode);
                    //fluentWait.Until(d => d.FindElement(By.XPath("//span[@id='delivery_details']"))).Equals(getPincode);
                    Thread.Sleep(1000);
                    string? getSearchText = fluentWait.Until(d => searchData.searchText);
                    var productlist = homePage.TypeSearch(getSearchText);
                    Log.Information(driver.Url);
                    // Thread.Sleep(3000);
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("vicks"));
                    string? productposition = searchData.SearchPosition;
                    
                    var productpage = productlist.ProductSelectClick(productposition);
                    Log.Information("clicked product number 4");
                   // Thread.Sleep(3000);
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("vaporub"));

                    productpage.AddToCartButtonClick();
                    Log.Information("Add to cart button clicked");
                    //Thread.Sleep(3000);


                    /*var checkoutpage = productpage.GoToCartButtonClick();
                    Thread.Sleep(2000);
                    Log.Information("Go to cart button clicked");
                    TakeScreenshot();
                    fluentWait.Until(d => driver.Url.Contains("cart"));
                    Assert.That(driver.Url.Contains("cart"));
                    
                    var signuppage = checkoutpage.CheckoutButtonClick();
                    signuppage.EnterMobileNo();
                    Log.Information("Proceed button clicked");
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("account"));
                   // Thread.Sleep(2000);
                    test = extent.CreateTest("Add to cart Test - Pass");
                    test.Pass("Add to cart link failed");
               */ }
            }
            catch (AssertionException ex)
            {
                LogTestResult("Add to cart test", "Add to cart failed", ex.Message);
                test = extent.CreateTest("Add to cart Test - Fail");
                test.Fail("Add to cart Link failed");

            }
                

               
                
                //var productpage = searchpage.ClickProduct(getProduct);
                //List<string> lstwindow = driver.WindowHandles.ToList();
                //driver.SwitchTo().Window(lstwindow[1]);
                //Thread.Sleep(2000);
                //productpage.ClickSize();
                //productpage.ClickAddToCart();
                //string urllink = productpage.GetTitle();
                //Thread.Sleep(2000);
                //Assert.That(urllink, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'BRG9')]")).GetAttribute("href")));

            }

        }
    }
