using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]

        [Category("Sprint1")]
        class ServiceListings : Base
        {

            [Test, Order(1), Description("Check if user is able to Create a ShareSkill listing with valid data")]
            public void EnterShareSkill()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.EnterShareSkillByExcelData(2, test);
                shareSkillPage.VerifyShareSkillHasBeenEntered(2, test);
            }

            [Test, Order(2), Description("Check if user is able to View a ShareSkill listing with valid data")]
            public void ViewShareSkill()
            {
                ManageListings manageListingsPage = new ManageListings();
                manageListingsPage.GoToPage();
                manageListingsPage.ViewShareSkill(2, test);
            }

            [Test, Order(3), Description("Check if user is able to Edit an existing ShareSkill listing with valid data")]           
            public void EditShareSkill()
            {
               ManageListings manageListingsPage = new ManageListings();
               ShareSkill shareSkillPage = new ShareSkill();
               manageListingsPage.GoToPage();
               manageListingsPage.ClickEditButton();
               shareSkillPage.EditShareSkill(2, test);
            }

            [Test, Order(4), Description("Check if user is able to Delete a Service listing")]
            public void DeleteShareSkill()
            {
                ManageListings manageListingsPage = new ManageListings();
                manageListingsPage.GoToPage();
                manageListingsPage.DeleteShareSkill(2, test); 
            }
        }
        class ErrorAssertions : Base
        {
            [Test, Order(1), Description("Check if user is able to save a ShareSkill listing with Blank inputs")]
            public void Enter_Blank_Inputs()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.EnterShareSkill("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", false, test);
                shareSkillPage.VerifyFieldErrorMessages(4, test);
            }
            [Test, Order(2), Description("Check if user is able to save a ShareSkill listing with Incomplete inputs")]
            public void Enter_Incomplete_Inputs()
            {
                //This test case contains valid and invalid inputs eg: it will enter valid texts in some fields and leave other fields empty
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.EnterShareSkill("", "Design website banners and assist with web visuals", "Digital Marketing", "", "Advertising", "Hourly basis service", "On-site", "", "", "", "", "", "Skill-Exchange", "", "", "Active", false, test);
                shareSkillPage.VerifyFieldErrorMessages(5, test);
            }
            [Test, Order(3), Description("Check if user is able to save a ShareSkill listing with valid and invalid Category Dropdown inputs")]
            public void Enter_Valid_And_Invalid_Category_Dropdown_Inputs()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.EnterShareSkill("Digital Marketer", "", "Digital Marketing", "Social Media Marketing", "Advertising", "Hourly basis service", "On-site", "", "", "", "", "", "Skill-Exchange", "", "", "Active", false, test);
                shareSkillPage.VerifyFieldErrorMessages(6, test);
            }
            [Test, Order(4), Description("Check if user is able to Enter a Title with more than a 100 characters")]
            public void Enter_Over_100_Characters_Title()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.VerifyCharacterLengthOfTitle(7, test);
                shareSkillPage.VerifyCharacterLengthOfTitle(8, test);
            }
            [Test, Order(5), Description("Check if user is able to Enter a Title with invalid characters")]
            public void Enter_Title_With_Invalid_Characters()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.VerifyUserCannotInputTitleWithInvalidCharacters(" Test Analyst", "First character must be an alphabet character or a number.", test);
                shareSkillPage.VerifyUserCannotInputTitleWithInvalidCharacters("Quality Assurance +& ", "Special characters are not allowed.", test);
                shareSkillPage.VerifyUserCannotInputTitleWithInvalidCharacters("() Test 01", "First character must be an alphabet character or a number.", test);

            }
            [Test, Order(6), Description("Check if user is able to Enter a Descritpiton with more than 600 characters")]
            public void Enter_Over_600_Characters_Description()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.VerifyCharacterLengthOfDescription(9, test);
                shareSkillPage.VerifyCharacterLengthOfDescription(10, test);
            }
        
            [Test, Order(7), Description("Check if user is able to Enter a Description with invalid characters")]
            public void Enter_Description_With_Invalid_Characters()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.GoToShareSkill();
                shareSkillPage.VerifyUserCannotInputDescriptionWithInvalidCharacters(" Testing Software and Web Applications", "First character must be an alphabet character or a number.", test);
                shareSkillPage.VerifyUserCannotInputDescriptionWithInvalidCharacters("Testing Software  @% and Web Applications +& ", "Special characters are not allowed.", test);
                shareSkillPage.VerifyUserCannotInputDescriptionWithInvalidCharacters("() Test 01", "First character must be an alphabet character or a number.", test);
            }
        }
    }
}