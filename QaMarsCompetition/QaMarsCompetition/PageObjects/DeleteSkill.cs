using OpenQA.Selenium;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaMarsCompetition.PageObjects
{
    public class DeleteSkill : CommonDriver
    {
        public static ExtentTest test;

        public static ExtentReports extent = new ExtentReports();
        public bool skilldeleted = false;
        public IWebElement delmanageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        public IWebElement findDel => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
        public IWebElement delebutton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        public void DeleteSkills()
        {
           
            ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(@"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Extent Reports\Del skills\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
            // identify manage listing button
            delmanageListing.Click();

            // identify delete button
             findDel.Click();
            test = extent.CreateTest("Test  edited  in skills").Info("edited in shareskill page");
           
            //screnshot5 for del skills
            Screenshot screenshot5 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath5 = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshot5 del skills.png";
            screenshot5.SaveAsFile(screenshotPath5);
           
            delebutton.Click();
            test.Log(Status.Info, " skills deleted");
           
            skilldeleted = true;
            extent.Flush();
        }
    }
}
