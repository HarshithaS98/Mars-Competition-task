using OpenQA.Selenium;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Data;

namespace QaMarsCompetition.PageObjects
{
    public class EditSkill : CommonDriver
    {
        public bool skilledited = false;
        private string filePath, edittitle, editdescription, skillexchange;
        private FileStream fileStream;
        public DataSet dataSet;
        private DataTable dataTable;
        public static ExtentTest test;

        public static ExtentReports extent = new ExtentReports();
        public IWebElement manageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        public IWebElement findEdit => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        public IWebElement edittitlebox => driver.FindElement(By.Name("title"));
        public IWebElement editdescriptionbox => driver.FindElement(By.Name("description"));

        public IWebElement edittagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement tagsedittab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span"));
        public IWebElement editservice => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        public IWebElement editlocation => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        public IWebElement thu1 => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input"));

        public IWebElement editstarttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input"));
        public IWebElement editendtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input"));
        public IWebElement editskilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
       
        public IWebElement editskillechangeApi => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
      
        public IWebElement edithidden => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        public IWebElement editsave => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

        public void ExcelReadDataForedikskillpage()
        {
             //Path to the excel file with data driven
            filePath = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\QaMarsCompetition\bin\editskillsexcelsheet.xls";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Reading skills title decsription credit from excel file to be used in skill page
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(fileStream);
            //Getting the excel file as a dataset
            dataSet = reader.AsDataSet();
           
            //Since only 1 sheet is in the excel file, index 0 is taken
            dataTable = dataSet.Tables[0];
            edittitle = dataTable.Rows[1][0].ToString();
            editdescription = dataTable.Rows[1][1].ToString();
            skillexchange = dataTable.Rows[1][2].ToString();
        }

        public void EditSkills()
        {   
            //reading values from excel file
            ExcelReadDataForedikskillpage();
            ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(@"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Extent Reports\Edit skills\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

            // Identify manage listing button
            manageListing.Click();

            
            //identify edit button
            findEdit.Click();
            test = extent.CreateTest("Test  edited  in skills").Info("edited in shareskill page");

            // edit title details
            edittitlebox.Clear();
            edittitlebox.SendKeys(edittitle);
            test.Log(Status.Pass, "title  edited");

            // edit description details
            editdescriptionbox.Clear();
            editdescriptionbox.SendKeys(editdescription);

            test.Log(Status.Info, "description  edited");
            //edit tagstab details
            tagsedittab.Click();
            edittagstab.SendKeys("API");
            edittagstab.SendKeys(Keys.Enter);
            test.Log(Status.Pass, "tags  edited");
            // screenshot 4 edit skills
            Screenshot screenshot4 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath4 = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshot4 edit skills.png";
            screenshot4.SaveAsFile(screenshotPath4);
            //edit service 

            editservice.Click();
            test.Log(Status.Info, "Service  edited");

            //edit available days
            thu1.Click();
            //edit start time
            editstarttime.SendKeys("500");
            //edit end time
            editendtime.SendKeys("530");
            test.Log(Status.Pass, "Available days  edited");

            // edit skilltrade
            editskilltrade.Click();
            test.Log(Status.Info, "skilltrade  edited");

            //edit skillexchange
            editskillechangeApi.Click();
            editskillechangeApi.SendKeys(skillexchange);
            editskillechangeApi.SendKeys(Keys.Enter);
            test.Log(Status.Info, "skillexchange  edited");

            // edit active to hidden 
            edithidden.Click();
            //save edited details
            editsave.Click();
            test.Log(Status.Info, "All skills are edited and saved");
            skilledited = true;
            extent.Flush();
    }
    }
}
