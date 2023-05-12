using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.ComponentModel;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing

        [FindsBy(How = How.XPath, Using = "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");


        }
        public void GoToPage()
        {
            // Navigate to Manage Listings page
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Manage Listings"), 10);
            manageListingsLink.Click();
        }

        public void ClickEditButton()
        {
            // Click on Edit button on Manage Listings page
            GlobalDefinitions.wait(5);
            edit.Click();
        }

        public void DeleteShareSkill(int rowNo, ExtentTest test)
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "DeleteShareSkill");
            string title = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title");
            
            // Click on Delete button on Manage Listings page
            GlobalDefinitions.wait(5);
            delete.Click();
            Thread.Sleep(1000);
            clickActionsButton.Click();
            IWebElement yesButton = clickActionsButton.FindElement(By.XPath(".//button[contains(text(), 'Yes')]"));
            yesButton.Click();
            Thread.Sleep(1000);

            //Assert that the listing was deleted by Checking the PopUp message 
            IWebElement popUpMessage = GlobalDefinitions.driver.FindElement(By.ClassName("ns-box-inner"));
            Assert.AreEqual(title + " has been deleted", popUpMessage.Text);

            // logging to extent reports
            test.Log(LogStatus.Info, "Successfully Deleted an existing Share Skill listing");

        }
        public void ViewShareSkill(int rowNo, ExtentTest test)
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            string title = GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title");

            // Click on View button on Manage Listings page
            GlobalDefinitions.wait(5);
            view.Click();
            Thread.Sleep(1000);

            // Assert that the View page has the correct details
            var listingTitle = GlobalDefinitions.driver.FindElement(By.ClassName("skill-title"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Title"), listingTitle.Text);
            Thread.Sleep(1000);

            var listingDescription = GlobalDefinitions.driver.FindElement(By.ClassName("description"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(rowNo, "Description"), listingDescription.Text);

            // logging to extent report 
            test.Log(LogStatus.Info, "Successfully Viewed a Share Skill listing");
        }

    }
}
