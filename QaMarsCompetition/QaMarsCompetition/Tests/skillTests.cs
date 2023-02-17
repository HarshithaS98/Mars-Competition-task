global using AventStack.ExtentReports.Reporter;
global using AventStack.ExtentReports;
global using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QaMarsCompetition.PageObjects;
using QaMarsCompetition.Utilities;
using FluentAssertions;
 using ExcelDataReader;

using NUnit.Framework;

namespace QaMarsCompetition.Tests
{
    [TestFixture]
    public class Tests
    { 
         CommonDriver driver;

        public static ExtentTest test;
        
        public static ExtentReports extent = new ExtentReports();

       

        public Tests()
    {
            driver = new CommonDriver();

           
    }

       
        [SetUp]

        public void loginsteps()
        {
           var htmlreporter = new ExtentHtmlReporter(@"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\QaMarsCompetition\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            
            // Login page object initialization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj .CreateLogin();
          
        }


        [Test,Order(1)]
        
        public void Addskill()
        {
            test = null;
            test = extent.CreateTest("Test add skills").Info("Skills added in shareskill page");
            ShareSkill shareskillobj = new ShareSkill();
            shareskillobj.ShareSkills();
            test.Log(Status.Info, "skills added");
            shareskillobj.skillAdded.Should().BeTrue();

        }

        [Test,Order(2)]
       
        public void EdSkill()
        {
            
            test = extent.CreateTest("Test Edit skills");
            EditSkill editskillobj = new EditSkill();
            editskillobj.EditSkills();
            test.Log(Status.Info, "Skills edited in Manage listing page");
            editskillobj.skilledited.Should().BeTrue();
        }
        [Test , Order(3)]
        public void DelSkill()
        {
            
            test = extent.CreateTest("Test Delete skills");
            DeleteSkill deleteskillobj = new DeleteSkill();
            deleteskillobj.DeleteSkills();
            test.Log(Status.Info, "Skills Deleted in manage listing page ");
            deleteskillobj.skilldeleted.Should().BeTrue();
        }
        [TearDown]
        public void quit()
        {
            driver.shutDown();
            extent.Flush();
        }
    }
}