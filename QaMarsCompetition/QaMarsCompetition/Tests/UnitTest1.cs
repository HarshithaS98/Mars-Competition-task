using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QaMarsCompetition.PageObjects;
using QaMarsCompetition.Utilities;

namespace QaMarsCompetition.Tests
{
    public class Tests : CommonDriver
    {
       
        [SetUp]
        public void loginsteps()
        {
          
            // Login page object initialization and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj .CreateLogin(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test , Order(1)]
        public void Addskill()
        {
            ShareSkill shareskillobj = new ShareSkill();
                shareskillobj.ShareSkills();
        }

        [Test , Order(2)]
        public void EdSkill()
        {
                EditSkill editskillobj = new EditSkill();
                editskillobj.EditSkills();
        }
        [Test , Order(3)]
        public void DelSkill()
        {

            DeleteSkill deleteskillobj = new DeleteSkill();
            deleteskillobj.DeleteSkills();
        }
    }
}