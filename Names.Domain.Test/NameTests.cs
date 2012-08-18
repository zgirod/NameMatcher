using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Names.Domain.Abstract;
using Names.Domain.Concrete;
using NUnit.Framework;

namespace Names.Domain.Test
{

    [TestFixture]
    public class NameTests
    {

        [Test]
        public void ZachGirod_Matches_ZacharyGirod()
        {

            INicknameRepository nicknameRepo = new TestNicknameRepository();
            INameMatcher nameMatcher = new NameMatcher(nicknameRepo);

            //make sure zach girod matches zachary girod
            Assert.That(nameMatcher.AreNamesEqual("Zach Girod", "Zachary Girod"), Is.True);
            Assert.That(nameMatcher.AreNamesEqual("Zachary Girod", "Zach Girod"), Is.True);

        }

        [Test]
        public void RichardJones_Matches_RickJones()
        {

            INicknameRepository nicknameRepo = new TestNicknameRepository();
            INameMatcher nameMatcher = new NameMatcher(nicknameRepo);

            //make sure zach girod matches zachary girod
            Assert.That(nameMatcher.AreNamesEqual("Richard Jones", "Rick Jones"), Is.True);
            Assert.That(nameMatcher.AreNamesEqual("Rick Jones", "Richard Jones"), Is.True);

        }

        [Test]
        public void RichardJones_DoesNotMatches_RickJordan()
        {

            INicknameRepository nicknameRepo = new TestNicknameRepository();
            INameMatcher nameMatcher = new NameMatcher(nicknameRepo);

            //make sure zach girod matches zachary girod
            Assert.That(nameMatcher.AreNamesEqual("Richard Jones", "Rick Jordan"), Is.False);
            Assert.That(nameMatcher.AreNamesEqual("Rick Jordan", "Richard Jones"), Is.False);

        }

    }

}
