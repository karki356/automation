using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QA_Automation_Coding_Test.util;
namespace QA_Automation_Coding_Test.pages
{
    class Home
    {
        //########## Setup ############
        private IWebDriver driver = null;
        private Util util = null;
        public Home(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        public void OpenHome(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void ClickOnCareerLink()
        {
            IWebElement link = driver.FindElement(By.XPath("//div[@class='grid-container extrawide-grid logo-utility-container']//a[@href='http://www.labcorpcareers.com/']"));
            link.Click();
        }
    }
}
