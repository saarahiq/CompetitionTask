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
                shareSkillPage.EnterShareSkill(2);

            }

            [Test, Order (2), Description("Check if user is able to Edit a ShareSkill listing with valid data")]
            public void EditShareSkill()
            {
                ManageListings manageListingsPage = new ManageListings();
                ShareSkill shareSkillPage = new ShareSkill();

                manageListingsPage.GoToPage();
                shareSkillPage.EditShareSkill(2);
            }
        }
    }
}