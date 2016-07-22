using System.Collections.Generic;
using CQRS_Session1.Src;
using NUnit.Framework;

namespace CQRS_Session1.Tests
{
    [TestFixture]
    public class UserRepositoryShould
    {
        [Test]
        public void create_a_user()
        {
            var expectedUsers = new List<User>() {new User("User Name")};
            var userRepo    = new UserRepository();

            userRepo.CreateUser("User Name");

            var users   = userRepo.AllUsers();
            Assert.That(users, Is.EqualTo(expectedUsers));
        }

        [Test]
        public void find_user_by_name()
        {
            var userName = "User Name";
            var user    = new User(userName);
            var userRepo    = new UserRepository();
            userRepo.CreateUser(userName);

            var retrievedUser   = userRepo.FindByName(userName);

            Assert.That(retrievedUser, Is.EqualTo(user));
        }
    }
}
