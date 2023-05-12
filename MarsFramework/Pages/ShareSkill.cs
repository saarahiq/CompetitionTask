using AutoIt;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill(int rowNo, ExtentTest test)
        {
            int row = rowNo;

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);

            // Click on Share skill button 
            ShareSkillButton.Click();

            // Input Title
            string title = GlobalDefinitions.ExcelLib.ReadData(row, "Title");
            Title.SendKeys(title);

            //Input Description
            string description = GlobalDefinitions.ExcelLib.ReadData(row, "Description");
            Description.SendKeys(description);

            // Select Category and sub-category option
            CategoryDropDown.Click();
            string category = GlobalDefinitions.ExcelLib.ReadData(row, "Category");
            SelectElement select = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='categoryId']")));
            select.SelectByText(category);

            SubCategoryDropDown.Click(); 
            string subcategory = GlobalDefinitions.ExcelLib.ReadData(row, "SubCategory");
            SelectElement selectSubCategory = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='subcategoryId']")));
            selectSubCategory.SelectByText(subcategory);

            // Enter Tags
            string tags = GlobalDefinitions.ExcelLib.ReadData(row, "Tags");
            Tags.Click(); Tags.SendKeys(tags); Tags.SendKeys(Keys.Return);

            //Select Service Type 
            string serviceType = GlobalDefinitions.ExcelLib.ReadData(row, "ServiceType"); 

            if (serviceType == "Hourly basis service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (serviceType == "One-off service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }

            //Select Location Type
            string locationType = GlobalDefinitions.ExcelLib.ReadData(row, "LocationType");

            if (locationType == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }
            else if (locationType == "On-site")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }

            // Select Start and End Date
            string startDate = GlobalDefinitions.ExcelLib.ReadData(row, "Startdate");
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(startDate);

            string endDate = GlobalDefinitions.ExcelLib.ReadData(row, "Enddate");
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(endDate);

            // Select Day
            // If it's Monday, we get the Monday Checkbox, and the start time and end time.
            
            string day = GlobalDefinitions.ExcelLib.ReadData(row, "Selectday");
            string startTime = GlobalDefinitions.ExcelLib.ReadData(row, "Starttime");
            string endTime = GlobalDefinitions.ExcelLib.ReadData(row, "Endtime");
           
            if (day == "Mon")
            {
                // I need to get Monday Checkbox XPath
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")).Click();
                
                // I need to get Monday Start Time XPath
                IWebElement mondayStartTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
                mondayStartTime.Click(); mondayStartTime.SendKeys(startTime);
                
                // I need to get Monday End Time XPath.
                IWebElement mondayEndTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
                mondayEndTime.Click(); mondayEndTime.SendKeys(endTime);
            } 
            else if (day == "Tue")
            {
                // I need to get Tuesday Checkbox XPath
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")).Click();
                
                // I need to get Tuesday Start Time XPath
                IWebElement tueStartTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"));
                tueStartTime.Click();
                GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"), 5);
                tueStartTime.SendKeys(startTime);
                
                // I need to get Tuesday End Time XPath.
                IWebElement tueEndTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[3]/input"));
                tueEndTime.Click(); tueEndTime.SendKeys(endTime);
            }

            // Select Skill Trade option

            string skillTrade = GlobalDefinitions.ExcelLib.ReadData(row, "SkillTrade");

            if (skillTrade == "Skill-Exchange")
            {
                // I click on Skill-exchange option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();
                // Add Skill-Exchange
                string skillExchange = GlobalDefinitions.ExcelLib.ReadData(row, "Skill-Exchange");
                SkillExchange.Click(); SkillExchange.SendKeys(skillExchange); SkillExchange.SendKeys(Keys.Return);
            }
            else if (skillTrade == "Credit")
            {
                // I click on the Credit option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")).Click();
                string credit = GlobalDefinitions.ExcelLib.ReadData(row, "Credit");
                CreditAmount.Click(); CreditAmount.SendKeys(credit);
            }
            Thread.Sleep(2000);

            // Upload Work Samples
            IWebElement workSample = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            workSample.Click();
            
            Thread.Sleep(1000);
            
            AutoItX.WinActivate("Open"); // Window name to select a file 
            AutoItX.Send(@"C:\Users\saara\Downloads\ID-Supporting-Document.pdf"); // file path 
            AutoItX.Send("{Enter}");
            Thread.Sleep(2000);

            // Select Active option
            string active = GlobalDefinitions.ExcelLib.ReadData(row, "Active");

            if (active == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            }
            else if (active == "Hidden")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            }

            // Click on Save
            Save.Click();
            Thread.Sleep(2000);

            //Navigate to Manage Listings Page
            Global.GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/Home/ListingManagement");
            Thread.Sleep(2000);

            //Assertions
            var listingTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(row, "Title"), listingTitle.Text);

            var listingDescription = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(row, "Description"), listingDescription.Text);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully created a new Share Skill listing");
        }

        internal void EditShareSkill(int rowNo, ExtentTest test)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");

            // Edit Share Skill Page
            string title = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title");
            Title.Clear(); Title.SendKeys(title);
            Thread.Sleep(1000);

            string description = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Description");
            Description.Clear(); Description.SendKeys(description);
            Thread.Sleep(1000);

            CategoryDropDown.Click();
            string category = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Category");
            SelectElement select = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='categoryId']")));
            select.SelectByText(category);
            Thread.Sleep(1000);

            SubCategoryDropDown.Click();
            string subcategory = GlobalDefinitions.ExcelLib.ReadData(rowNo, "SubCategory");
            SelectElement selectSubCategory = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='subcategoryId']")));
            selectSubCategory.SelectByText(subcategory);
            Thread.Sleep(1000);

            string tags = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Tags");
            //Remove existing Tag
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")).Click();
            Tags.Click(); Tags.SendKeys(tags); Tags.SendKeys(Keys.Return);
            Thread.Sleep(1000);

            // Edit Service Type
            string serviceType = GlobalDefinitions.ExcelLib.ReadData(rowNo, "ServiceType");

            if (serviceType == "Hourly basis service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (serviceType == "One-off service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }
            Thread.Sleep(1000);

            // Edit Location Type
            string locationType = GlobalDefinitions.ExcelLib.ReadData(rowNo, "LocationType");

            if (locationType == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }
            else if (locationType == "On-site")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }
            Thread.Sleep(1000);

            string startDate = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Startdate");
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(startDate);
            Thread.Sleep(1000);

            string endDate = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Enddate");
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(endDate);
            Thread.Sleep(1000);

            string day = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Selectday");
            string startTime = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Starttime");
            string endTime = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Endtime");

            if (day == "Mon")
            {
                // I need to get Monday Checkbox XPath
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")).Click();

                // I need to get Monday Start Time XPath
                IWebElement mondayStartTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
                mondayStartTime.Click(); mondayStartTime.SendKeys(startTime);

                // I need to get Monday End Time XPath.
                IWebElement mondayEndTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
                mondayEndTime.Click(); mondayEndTime.SendKeys(endTime);
            }
            else if (day == "Tue")
            {
                // I need to get Tuesday Checkbox XPath
                GlobalDefinitions.wait(3);
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[1]/div/input")).Click();
                                                                 
                // I need to get Tuesday Start Time XPath
                IWebElement tueStartTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"));
                tueStartTime.Click();
                GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"), 5);
                tueStartTime.SendKeys(startTime);

                // I need to get Tuesday End Time XPath.
                IWebElement tueEndTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[3]/input"));
                tueEndTime.Click(); tueEndTime.SendKeys(endTime);
            }
            Thread.Sleep(1000);

            // Select Skill Trade option

            string skillTrade = GlobalDefinitions.ExcelLib.ReadData(rowNo, "SkillTrade");

            if (skillTrade == "Skill-Exchange")
            {
                // I click on Skill-exchange option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();
                // Add Skill-Exchange
                string skillExchange = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Skill-Exchange");
                SkillExchange.Click(); SkillExchange.SendKeys(skillExchange); SkillExchange.SendKeys(Keys.Return);
            }
            else if (skillTrade == "Credit")
            {
                // I click on the Credit option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")).Click();
                string credit = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Credit");
                CreditAmount.Click(); CreditAmount.SendKeys(credit);
            }
            Thread.Sleep(1000);

            //// Upload Work Samples - Cannot upload when editing and saving, shows error message "There is an error when updating Work Samples - undefined"
            //IWebElement workSample = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            //workSample.Click();

            //Thread.Sleep(2000);

            //AutoItX.WinActivate("Open"); // Window name to select a file 
            //AutoItX.Send(@"C:\Users\saara\Downloads\Team photo_April 19, 2023.png");  
            //AutoItX.Send("{Enter}");
            //Thread.Sleep(2000);


            // Select Active option
            string active = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Active");

            if (active == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            }
            else if (active == "Hidden")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            }
            // Click on Save
            Save.Click();
            Thread.Sleep(1000);

            //Assert that the listing was edited successfully with valid details 
            var listingTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title"), listingTitle.Text);

            var listingDescription = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Description"), listingDescription.Text);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Edited an existing Share Skill listing");
        }
    }
}
