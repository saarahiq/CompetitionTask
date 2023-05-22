using AutoIt;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Deployment.Internal;
using System.Net.NetworkInformation;
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

        //PopUp Message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement PopUpMessage { get; set; }

        //Title required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")]
        private IWebElement TitleErrorMessage { get; set; }

        //Description required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[2]/div")] 
        private IWebElement DescriptionErrorMessage { get; set; }

        //Category required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div[2]")]
        private IWebElement CategoryErrorMessage { get; set; }

        //SubCategory required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[2]/div")]
        private IWebElement SubCategoryErrorMessage { get; set; }                                                          

        //Tags required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div[2]")]
        private IWebElement TagsErrorMessage { get; set; }

        //Skill-Exchange Tags required Error Message
        [FindsBy(How = How.XPath, Using = "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[2]")]
        private IWebElement SkillExchangeErrorMessage { get; set; }
        public void GoToShareSkill()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);
            ShareSkillButton.Click();
        }
        internal void EnterShareSkillByExcelData(int row, ExtentTest test)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            // Input Title
            string title = GlobalDefinitions.ExcelLib.ReadData(row, "Title");

            //Input Description
            string description = GlobalDefinitions.ExcelLib.ReadData(row, "Description");

            // Select Category and sub-category option
            string category = GlobalDefinitions.ExcelLib.ReadData(row, "Category");

            string subcategory = GlobalDefinitions.ExcelLib.ReadData(row, "SubCategory");

            // Enter Tags
            string tags = GlobalDefinitions.ExcelLib.ReadData(row, "Tags");

            //Select Service Type 
            string serviceType = GlobalDefinitions.ExcelLib.ReadData(row, "ServiceType");

            //Select Location Type
            string locationType = GlobalDefinitions.ExcelLib.ReadData(row, "LocationType");

            // Select Start and End Date
            string startDate = GlobalDefinitions.ExcelLib.ReadData(row, "Startdate");

            string endDate = GlobalDefinitions.ExcelLib.ReadData(row, "Enddate");

            string day = GlobalDefinitions.ExcelLib.ReadData(row, "Selectday");
            string startTime = GlobalDefinitions.ExcelLib.ReadData(row, "Starttime");
            string endTime = GlobalDefinitions.ExcelLib.ReadData(row, "Endtime");

            // Select Skill Trade option
            string skillTrade = GlobalDefinitions.ExcelLib.ReadData(row, "SkillTrade");

            string skillExchange = GlobalDefinitions.ExcelLib.ReadData(row, "Skill-Exchange");

            string credit = GlobalDefinitions.ExcelLib.ReadData(row, "Credit");

            // Select Active option
            string active = GlobalDefinitions.ExcelLib.ReadData(row, "Active");

            EnterShareSkill(title, description, category, subcategory, tags, serviceType, locationType, startDate, endDate, day, startTime, endTime, skillTrade, skillExchange, credit, active, true, test);
             
        }

        internal void EnterShareSkill(string title,
            string description,
            string category,
            string subcategory,
            string tags,
            string serviceType,
            string locationType,
            string startDate,
            string endDate,
            string day,
            string startTime,
            string endTime,
            string skillTrade,
            string skillExchange,
            string credit,
            string active,
            bool uploadWorkSample,
            ExtentTest test)
        {
            Title.SendKeys(title);
            Description.SendKeys(description);
       
            if (category != "")
            {
                CategoryDropDown.Click();
                SelectElement select = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='categoryId']")));
                select.SelectByText(category);
            }
     
            if (subcategory != "")
            {
                SubCategoryDropDown.Click();
                SelectElement selectSubCategory = new SelectElement(GlobalDefinitions.driver.FindElement(By.XPath("//select[@name ='subcategoryId']")));
                selectSubCategory.SelectByText(subcategory);
            }

            Tags.Click(); Tags.SendKeys(tags); Tags.SendKeys(Keys.Return);

            if (serviceType == "Hourly basis service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }
            else if (serviceType == "One-off service")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")).Click();
            }           

            if (locationType == "Online")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }
            else if (locationType == "On-site")
            {
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }

            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(startDate);

            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(endDate);

            // Select Day
            // If it's Monday, we get the Monday Checkbox, and the start time and end time.
      
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

            if (skillTrade == "Skill-Exchange")
            {
                // I click on Skill-exchange option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();
                // Add Skill-Exchange

                SkillExchange.Click(); SkillExchange.SendKeys(skillExchange); SkillExchange.SendKeys(Keys.Return);
            }
            else if (skillTrade == "Credit")
            {
                // I click on the Credit option
                GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")).Click();

                CreditAmount.Click(); CreditAmount.SendKeys(credit);
            }
            
            // Upload Work 
            if (uploadWorkSample == true)
            { 
                IWebElement workSample = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                workSample.Click();
                AutoItX.WinActivate("Open"); // Window name to select a file 
                Thread.Sleep(1000);
                AutoItX.Send(@"C:\Users\saara\OneDrive\Documents\Mars Competition Task-2\Test Upload File.txt"); // file path 
                AutoItX.Send("{Enter}");
                Thread.Sleep(1000);
            }
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
            Thread.Sleep(500);        
        }
        internal void VerifyShareSkillHasBeenEntered(int row, ExtentTest test)
        {
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

        internal void VerifyFieldErrorMessages(int row, ExtentTest test)
        {
            Thread.Sleep(1000);

            //Verify PopUp Error Message
            Assert.AreEqual("Please complete the form correctly.", PopUpMessage.Text);

            //Verify Title is required
            string title = GlobalDefinitions.ExcelLib.ReadData(row, "Title");
            if (title == "")
            {
                Assert.AreEqual("Title is required", TitleErrorMessage.Text);
            }

            //Verify Description is required
            string description = GlobalDefinitions.ExcelLib.ReadData(row, "Description");
            if (description == "")
            {
                Assert.AreEqual("Description is required", DescriptionErrorMessage.Text);
            }

            //Verify Category is required
            string category = GlobalDefinitions.ExcelLib.ReadData(row, "Category");
            if (category == "")
            {
                Assert.AreEqual("Category is required", CategoryErrorMessage.Text);
            }
            else
            {
                string subCategory = GlobalDefinitions.ExcelLib.ReadData(row, "Subcategory");
                if (subCategory == "")
                {
                    Assert.AreEqual("Subcategory is required", SubCategoryErrorMessage.Text);
                }
            }

            //Verify Tags are required
            string tags = GlobalDefinitions.ExcelLib.ReadData(row, "Tags");
            if (tags == "")
            {
                Assert.AreEqual("Tags are required", TagsErrorMessage.Text);
            }

            //Verify Skill-Exchange Tags is required
            string skillExchange = GlobalDefinitions.ExcelLib.ReadData(row, "Skill-Exchange");
            if (skillExchange == "")
            {
                Assert.AreEqual("Tag is required", SkillExchangeErrorMessage.Text);
            }
            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Verified field error messages");
        }
        internal void VerifyCharacterLengthOfTitle(int row, ExtentTest test)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Title.Clear();
            // Input Title
            string title = GlobalDefinitions.ExcelLib.ReadData(row, "Title");
            Title.SendKeys(title);

            string typedTitle = Title.GetAttribute("value");

            //Assert the length of the Title is a 100 characters
            Assert.LessOrEqual(typedTitle.Length, 100);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Verified character length of Title");
        }
        internal void VerifyUserCannotInputTitleWithInvalidCharacters(string title, string expectedErrorMessage, ExtentTest test)
        {
            wait(3);
            Title.Clear();
            Title.SendKeys(title);
            Assert.That(TitleErrorMessage.Text == expectedErrorMessage);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Verified User cannot input Title with Invalid characters");
        }
        internal void VerifyUserCannotInputDescriptionWithInvalidCharacters(string description, string expectedErrorMessage, ExtentTest test)
        {
            wait(3);
            Description.Clear();
            Description.SendKeys(description);
            Assert.That(DescriptionErrorMessage.Text == expectedErrorMessage);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Verified User cannot input Descripton with Invalid characters");
        }
        internal void VerifyCharacterLengthOfDescription(int row, ExtentTest test)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Description.Clear();
            // Input Description
            string description = GlobalDefinitions.ExcelLib.ReadData(row, "Description");
            Description.SendKeys(description);

            string typedDescription = Description.GetAttribute("value");

            //Assert the length of the Description is 600 characters
            Assert.LessOrEqual(typedDescription.Length, 600);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Verified character length of Description");
        }
    }
}
