//using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoIt;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography.X509Certificates;
using SharpCompress.Common;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using ExcelDataReader;

namespace QaMarsCompetition.PageObjects
{
    public class ShareSkill : CommonDriver
    {
        public bool skillAdded = false;
        //private IExcelDataReader reader;
        private string filePath, title, description,credit;
        private FileStream fileStream;
        public DataSet dataSet;
        private DataTable dataTable;
        
        public IWebElement shareskillbutton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
        public IWebElement titlebox => driver.FindElement(By.Name("title"));
       public IWebElement descriptionbox => driver.FindElement(By.Name("description"));

       public IWebElement tagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement service => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        public IWebElement location => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        public IWebElement thu => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input"));

        public IWebElement starttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input"));
        public IWebElement endtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input"));
        public IWebElement skilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
       public IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
      public IWebElement exchangecredit => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        public IWebElement active => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        public IWebElement save => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
       
        public void ExcelReadDataForskillspagedatadriven()
        {
             //Path to the excel file with data driven
            filePath = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\QaMarsCompetition\Excelsheet.xls";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Reading skills title decsription credit from excel file to be used in skill page
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader  reader = ExcelReaderFactory.CreateReader(fileStream);
            //Getting the excel file as a dataset
            dataSet = reader.AsDataSet();
            //reader.DataSEt
            //Since only 1 sheet is in the excel file, index 0 is taken
            dataTable = dataSet.Tables[0];
            title = dataTable.Rows[1][0].ToString();
            description = dataTable.Rows[1][1].ToString();
            credit = dataTable.Rows[1][2].ToString();
        }


        public void ShareSkills()

        {
            //getting data from excel sheet
            ExcelReadDataForskillspagedatadriven();
            // Click on the Share Skill button
             shareskillbutton.Click();

            if (!string.IsNullOrEmpty(title))
            {
                // Identify the title text box
                titlebox.SendKeys(title);
            }
            else
            {
                // Log or throw an exception indicating that the title value is missing
            }

            if (!string.IsNullOrEmpty(description))
            {
                // Identify the description text box
                descriptionbox.SendKeys(description);
            }
            else
            {
                // Log or throw an exception indicating that the description value is missing
            }
            // Take screenshot
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshots.png";
            screenshot.SaveAsFile(screenshotPath);

            //identify category
            SelectElement categoryBox = new SelectElement(driver.FindElement(By.Name("categoryId")));
            categoryBox.SelectByText("Programming & Tech");
           
            //identify subcategory
            SelectElement subcategoryBox = new SelectElement(driver.FindElement(By.Name("subcategoryId")));
            subcategoryBox.SelectByText("QA");

            //identify tags
            tagstab.SendKeys("Selenium");
            tagstab.SendKeys(Keys.Enter);

            //identify service type
             service.Click();
            
            //identify location type
             location.Click();
            Screenshot screenshot1 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath1 = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshot2 Autoit.png";
            screenshot1.SaveAsFile(screenshotPath1);

            // identify available days
            thu.Click();
            starttime.SendKeys("300pm");
            endtime.SendKeys("400pm");

            //identify skill trade and select skillexchange
            skilltrade.Click();

            // identify skill exchange  and select credit
            skillexchange.Click();
            if (!string.IsNullOrEmpty(description))
            {
                // Identify the description text box
                descriptionbox.SendKeys(description);
            }
            else
            {
                // Log or throw an exception indicating that the description value is missing
            }
            ////click on worksample btton. 
            IWebElement Worksample = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                Worksample.Click();
            Screenshot screenshot2 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath2 = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshot2 Autoit.png";
            screenshot2.SaveAsFile(screenshotPath2);

            AutoItX.WinActivate("[CLASS:#32770");
            
            AutoItX.ControlFocus("[CLASS:#32770]", "", "Edit1");
            Thread.Sleep(1000);
            
            AutoItX.Send(@"D:\My Testing resume\Sample_Upload_File.txt");
            Thread.Sleep(1000);
            
            AutoItX.Send("{ENTER}");
            
            //identify active and click active
            active.Click();


            // identify save button
             save.Click();
            Screenshot screenshot3 = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath3 = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\Screenshots\screenshot1.png";
            screenshot3.SaveAsFile(screenshotPath3);
            skillAdded = true;
        }
    }
}
