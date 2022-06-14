using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QA_Automation_Coding_Test.pages;
using QA_Automation_Coding_Test.Pages;
using System.Configuration;
namespace QA_Automation_Coding_Test
{
    [TestClass]
    public class UnitTest1
    {
        Home home;
        IWebDriver driver;
        Careers career;
        string paragraph = "We are seeking an individual who has an obsession with quality and efficiency, and the desire to optimize processes to ensure highest software quality with the use of modern tools and technologies. Successful candidate will also have strong communication skills, keen interest in learning clinical development methods, and will be able to partner effectively with the application development teams and business stakeholders.";
        string point = "- Create an automation test bed, configure testing tools for all products based on current test scripts and processes and generate automated reports conforming to Labcorp's quality standards using industry best practices.";
        string title = "Software Test Engineer";
        string location = "Bangalore, India";
        string jobId = "Job Id : 2022-80853_CP";
        string jobType = "Full-Time";
        string jobCategory = "Regulatory/Compliance";

        [TestInitialize]
        public void Initialization()
        {
           driver = new ChromeDriver();
           home = new Home(driver);
           career = new Careers(driver);
        }
        [TestMethod]
        public void TestMethod1()
        {
            //1.Start the test by opening a browser to www.labcorp.com
            home.OpenHome("https://www.labcorp.com");

            //2.Find and click Careers link
            home.ClickOnCareerLink();

            //switch to second tab
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //Search for any position ("Software Test Engineer") and Select and browse to the position.
            career.SearchAnyPositionandClick("Software Test Engineer");

            // Add assertions to confirm
            // a. Job Title
            Assert.AreEqual(title, career.GetTextOfJobTitle());
            // b. Job Location
            Assert.IsTrue(career.GetTextOfLocation().Contains(location));
            // c. Job Id
            Assert.AreEqual(jobId, career.GetTextOfJobId());
            // d. Job type (Any 3 other assertions of your choice)
            Assert.IsTrue(career.GetTextOfJobType().Contains(jobType));
            // e. Job Category
            Assert.IsTrue(career.GetTextOfJobCategory().Contains(jobCategory));
            // f. Text from Third Paragraph
            Assert.AreEqual(paragraph,career.GetTextOfThirdParagraph());
            // g. Text from Second Bullet pointer
            Assert.AreEqual(point, career.GetTextOfSecondBulletPointer());

            //click Apply Now and verify the  job title Only as UI not having other info on same page.
            
            career.ClickOnApplyNow();
            //switch to third tab
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            Assert.AreEqual(title,career.GetTextOfTitleFromApplyNow());

            //Click to Return to Job Search
            career.ReturnToCarrersHome();

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}