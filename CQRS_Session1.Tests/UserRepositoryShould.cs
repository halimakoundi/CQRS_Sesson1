using System.Collections.Generic;
using CQRS_Session1.Src;
using NUnit.Framework;

namespace CQRS_Session1.Tests
{
    [TestFixture]
    public class UserRepositoryShould
    {
        private string _name = "Surname";

        [Test]
        public void create_a_user()
        {
            var expectedUsers = new List<User>() { new User("User UserName", _name) };
            var userRepo = new UserRepository();

            userRepo.CreateUser("User UserName", _name);

            var users = userRepo.AllUsers();
            Assert.That(users, Is.EqualTo(expectedUsers));
        }

        [Test]
        public void find_user_by_userName()
        {
            var userName = "User UserName";
            var user = new User(userName, _name);
            var userRepo = new UserRepository();
            userRepo.CreateUser(userName, _name);

            var retrievedUser = userRepo.FindByUserName(userName);

            Assert.That(retrievedUser, Is.EqualTo(user));
        }

        [Test]
        public void update_a_user()
        {
            var userName = "User Name";
            var name = "Surname";
            var userRepo = new UserRepository();
            userRepo.CreateUser(userName, name);
            var updatedName = "Updated Surname";
            var expectedUser = new User(userName, updatedName);
            userRepo.UpdateName(userName, updatedName);

            var updatedUser = userRepo.FindByUserName(userName);

            Assert.That(updatedUser, Is.EqualTo(expectedUser));
        }
    }
}
