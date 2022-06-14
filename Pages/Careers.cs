using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Automation_Coding_Test.util;
using OpenQA.Selenium;

namespace QA_Automation_Coding_Test.Pages
{
    public class Careers
    {
        IWebDriver driver;
        Util util;
        public Careers(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        public string GetTextOfJobTitle()
        {
            return util.GetText("//h1[@class='job-title']");
        }
        public string GetTextOfLocation()
        {
            return util.GetText("//span[@class='au-target job-location']");
        }
        public string GetTextOfJobId()
        {
            return util.GetText("//span[@class='au-target jobId']");
        }
        public string GetTextOfJobType()
        {
            return util.GetText("//span[@class='au-target type']");
        }
        public string GetTextOfJobCategory()
        {
            return util.GetText("//span[@class='au-target job-category']");
        }
        public string GetTextOfThirdParagraph()
        {
            return util.GetText("//p[3]");
        }
        public string GetTextOfSecondBulletPointer()
        {
            return util.GetText(" //div[@class='jd-info au-target']/ul/li[2]");
        }

        public string GetTextOfTitleFromApplyNow()
        {
            util.WaitForElementVisible(By.XPath("//h3"));
            return util.GetText("//h3");
        }

        public void SearchAnyPositionandClick(string position)
        {
            IWebElement searchBox = driver.FindElement(By.XPath("//label[text()='Search job title or location']/following-sibling::input"));
            searchBox.SendKeys(position);
            //Select and browse to the position
            driver.FindElement(By.XPath("//div[@class='global-search-block']//span[@au-target-id='227']/button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//div[@class='job-title']/span[contains(.,'"+position+"')]")).Click();
        }

        public void ClickOnApplyNow()
        {
            IWebElement applyNow = driver.FindElement(By.XPath("//div[@class='Sub-Actions']/a[@ph-tevent='apply_click']"));
            applyNow.Click();
        }

        public void ReturnToCarrersHome()
        {
            IWebElement careersHome = driver.FindElement(By.XPath("//button[text()='Careers Home']"));
            careersHome.Click();
        }
    }
}
