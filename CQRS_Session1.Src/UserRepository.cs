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
            var user = _repo.Find(x => x.UserName == userName);
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }
            return user;
        }

        public void UpdateName(string userName, string updatedName)
        {
            var user    = FindByUserName(userName);
            user.UpdateName(updatedName);
        }

        public void Delete(string userName)
        {
            var user = FindByUserName(userName);
            _repo.Remove(user);
        }
    }
}