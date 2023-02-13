using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaMarsCompetition.Utilities;
using System.Data;
using ExcelDataReader;

namespace QaMarsCompetition.PageObjects
{
    public class LoginPage : CommonDriver
    {
        private string filePath, username, password;
        private FileStream fileStream;
        public DataSet dataSet;
        private DataTable dataTable;


        public void ExcelReadDataForloginpage()
        {
            //Path to the excel file with data driven
            filePath = @"D:\QAMarsCompetition\QaMarsCompetition\QaMarsCompetition\QaMarsCompetition\bin\loginfileexcelsheet.xls";
            //Encoding excel file stream
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Reading login credentials from excel file to be used in skill page
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(fileStream);
            //Getting the excel file as a dataset
            dataSet = reader.AsDataSet();
            //reader.DataSEt
            //Since only 1 sheet is in the excel file, index 0 is taken
            dataTable = dataSet.Tables[0];
            username = dataTable.Rows[1][0].ToString();
            password = dataTable.Rows[1][1].ToString();
          
        }





        public void CreateLogin()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement element;
            // Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            ExcelReadDataForloginpage();
            // Identify signin button and click 
            element = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            element.Click();

            // Identify Username textbox and enter valid username
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            element.SendKeys(username);


            // Identify Password textbox and enter valid password
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            element.SendKeys(password);


            // Click login button
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            element.Click();

           
        }
    }
}
