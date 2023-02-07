using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QaMarsCompetition.PageObjects;
using QaMarsCompetition.Utilities;

namespace QaMarsCompetition.Tests
{
    public class Tests
    { 
         CommonDriver driver;
    public Tests()
    {
            driver = new CommonDriver();
    }

    
       
        [SetUp]
        public void loginsteps()
        {
          
            // Login page object initialization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj .CreateLogin();
          
        }

        [TestCase("Qa", "APITester","2" )]
        public void Addskill(string title, string description ,string credit)
        {
            ShareSkill shareskillobj = new ShareSkill();
                shareskillobj.ShareSkills(title ,description ,credit);
        }

        [TestCase("Testengineer","QaIntern","2")]
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