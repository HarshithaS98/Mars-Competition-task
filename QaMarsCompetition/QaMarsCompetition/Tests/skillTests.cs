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


        [Test,Order(1)]
        
        public void Addskill()
        {
            
            ShareSkill shareskillobj = new ShareSkill();
            shareskillobj.ShareSkills();
            
            shareskillobj.skillAdded.Should().BeTrue();

        }

        [Test,Order(2)]
       
        public void EdSkill()
        {
           
            EditSkill editskillobj = new EditSkill();
            editskillobj.EditSkills();
          
            editskillobj.skilledited.Should().BeTrue();
        }
        [Test , Order(3)]
        public void DelSkill()
        {
            
           
            DeleteSkill deleteskillobj = new DeleteSkill();
            deleteskillobj.DeleteSkills();
           
            deleteskillobj.skilldeleted.Should().BeTrue();
        }
        [TearDown]
        public void quit()
        {
            driver.shutDown();
          
        }
    }
}