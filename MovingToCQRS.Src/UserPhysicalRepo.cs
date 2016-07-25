using System.Collections.Generic;

namespace MovingToCQRS.Src
{
    public class UserPhysicalRepo : UserRepo
    {
        private readonly List<User> _repo = new List<User>();

        public void CreateUser(User user)
        {
            _repo.Add(user);
        }

        public int Count()
        {
            return _repo.Count;
        }

        public User FindByUserName(string userName)
        {
            return _repo.Find(user => user.UserName == userName);
        }

        public void Save(User user)
        {
            var usertoUpdate = FindByUserName(user.UserName);
            _repo.Remove(usertoUpdate);
            _repo.Add(user);
        }

        public void Delete(string userName)
        {
            _repo.Remove(FindByUserName(userName));
        }

        public List<User> AllUsers()
        {
            return _repo;
        }
    }
}
