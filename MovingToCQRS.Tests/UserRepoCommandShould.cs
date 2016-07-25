using System.Collections.Generic;
using MovingToCQRS.Src;
using NUnit.Framework;

namespace CQRS_Session1.Tests
{
    [TestFixture]
    public class UserRepoCommandShould
    {
        private string _name = "Surname";
        private UserRepoCommand _userRepo;
        private UserPhysicalRepo _userPhysicalRepo;
        private UserRepoQuery _userRepoQuery;

        [SetUp]
        public void SetUp()
        {
            _userPhysicalRepo = new UserPhysicalRepo();
            _userRepo = new UserRepoCommand(_userPhysicalRepo);
            _userRepoQuery = new UserRepoQuery(_userPhysicalRepo);
        }

        [Test]
        public void create_a_user()
        {
            var nbUsers = _userRepoQuery.AllUsers().Count;
            Assert.That(nbUsers, Is.EqualTo(0));

            _userRepo.CreateUser("User UserName", _name);

            nbUsers = _userRepoQuery.AllUsers().Count;
            Assert.That(nbUsers, Is.EqualTo(1));
        }

        [Test]
        public void update_a_user()
        {
            var userName = "User Name";
            var name = "Surname";
            _userRepo.CreateUser(userName, name);
            var createdUser = _userRepoQuery.FindByUserName(userName);

            var updatedName = "Updated Surname";
            _userRepo.UpdateName(createdUser, updatedName);
            var updatedUser = _userRepoQuery.FindByUserName(userName);

            Assert.That(updatedUser.Name, Is.EqualTo(updatedName));
        }

        [Test]
        public void delete_a_user()
        {
            var userName = "User Name";
            var name = "Surname";
            _userRepo.CreateUser(userName, name);

            var nbUsers = _userRepoQuery.AllUsers().Count;
            Assert.That(nbUsers, Is.EqualTo(1));

            _userRepo.Delete(userName);

            nbUsers = _userRepoQuery.AllUsers().Count;
            Assert.That(nbUsers, Is.EqualTo(0));

        }
    }
}
