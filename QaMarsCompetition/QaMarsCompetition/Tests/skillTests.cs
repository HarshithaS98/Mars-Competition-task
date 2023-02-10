global using AventStack.ExtentReports.Reporter;
global using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QaMarsCompetition.PageObjects;
using QaMarsCompetition.Utilities;
using FluentAssertions;


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

    
       
        [OneTimeSetUp]
        public  void loginsteps()
        {
           // extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\QaMarsCompetition\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);



            // Login page object initialization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj .CreateLogin();
          
        }
        

        [TestCase("Qa", "APITester","2" ),Order(1)]
        [TestCase("QualityAnalyst","Performance","4")]
        public void Addskill(string title, string description ,string credit)
        {
            test = null;
            test = extent.CreateTest("Test add skills").Info("Skills added in shareskill page");
            ShareSkill shareskillobj = new ShareSkill();
            shareskillobj.ShareSkills(title ,description ,credit);
            test.Log(Status.Info, "skills added");
            shareskillobj.skillAdded.Should().BeTrue();

        }

        [TestCase("Testengineer","QaIntern","Newman"),Order(2)]
        [TestCase("Automation","Loadtest","Jira")]
        public void EdSkill(string edittitle, string editdescription, string skillexchange)
        {
            test = null;
            test = extent.CreateTest("Test Edit skills");
            EditSkill editskillobj = new EditSkill();
            editskillobj.EditSkills(edittitle,editdescription,skillexchange);
            test.Log(Status.Info, "Skills edited in Manage listing page");
            editskillobj.skilledited.Should().BeTrue();
        }
        [Test , Order(3)]
        public void DelSkill()
        {
            test = null;
            test = extent.CreateTest("Test Delete skills");
            DeleteSkill deleteskillobj = new DeleteSkill();
            deleteskillobj.DeleteSkills();
            test.Log(Status.Info, "Skills Deleted in manage listing page ");
            deleteskillobj.skilldeleted.Should().BeTrue();
        }
        [OneTimeTearDown]
        public void quit()
        {
            driver.shutDown();
            extent.Flush();
        }
    }
}