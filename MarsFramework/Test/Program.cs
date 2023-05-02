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

            [Test, Order(1), Description("Check if user is able to create a ShareSkill listing with valid data")]
            public void EnterShareSkill()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.EnterShareSkill(2);

            }
        }
    }
}