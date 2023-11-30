using NetMeds.PageObjects;
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
    }
}
