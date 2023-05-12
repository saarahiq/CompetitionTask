using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1), Description("Check if user is able to Create a ShareSkill listing with valid data")]
            public void EnterShareSkill()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.EnterShareSkill(2, test);
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
    }
}