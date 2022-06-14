using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;

namespace QA_Automation_Coding_Test.util
{
    class Util
    {
        public IWebDriver driver;
        public Util(IWebDriver d)
        {
            driver = d;
        }


        public String GetText(string xpath)
        {
            string returnValue = null;
            try
            {
                IWebElement element = driver.FindElement(By.XPath(xpath));

                if(element != null)
                {
                    returnValue = element.Text;
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + xpath + "not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
            }
            return returnValue;
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until(driver => driver.FindElement(locator));
            return element;
        }
    }
}
