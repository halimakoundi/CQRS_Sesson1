using System.Collections.Generic;

namespace CQRS_Session1.Src
{
    public class UserRepository
    {
        private readonly List<User> _repo = new List<User>();

        public List<User> AllUsers()
        {
            return _repo;
        }

        public void CreateUser(string userName, string name)
        {
            _repo.Add(new User(userName, name));
        }

        public User FindByUserName(string userName)
        {
            return _repo.Find(x => x.UserName == userName);
        }

        public void UpdateName(string userName, string updatedName)
        {
            var user    = FindByUserName(userName);
            user.UpdateName(updatedName);
        }
    }
}