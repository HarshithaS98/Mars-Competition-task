global using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QaMarsCompetition.PageObjects;
using QaMarsCompetition.Utilities;

using AventStack.ExtentReports;

using NUnit.Framework;

namespace QaMarsCompetition.Tests
{
    [TestFixture]
    public class Tests
    { 
         CommonDriver driver;

        public static ExtentTest test;
        public static ExtentReports extent;


        public Tests()
    {
            driver = new CommonDriver();
         
;        }

    
       
        [SetUp]
        public  void loginsteps()
        {

            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
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
        }

        [TestCase("Testengineer","QaIntern","Newman"),Order(2)]
        [TestCase("Automation","Loadtest","Jira")]
        public void EdSkill(string edittitle, string editdescription, string skillexchange)
        {
                EditSkill editskillobj = new EditSkill();
                editskillobj.EditSkills(edittitle,editdescription,skillexchange);
        }
        [Test , Order(3)]
        public void DelSkill()
        {

            DeleteSkill deleteskillobj = new DeleteSkill();
            deleteskillobj.DeleteSkills();
        }
        [TearDown]
        public void quit()
        {
            driver.shutDown();
        }
    }
}