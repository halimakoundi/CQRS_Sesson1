using System.Collections.Generic;

namespace MovingToCQRS.Src
{
    public class UserRepoQuery
    {
        private readonly UserRepo _repo;

        public UserRepoQuery(UserRepo userRepo)
        {
            _repo = userRepo;
        }

        public User FindByUserName(string userName)
        {
            return _repo.FindByUserName(userName);
        }

        public List<User> AllUsers()
        {
            return _repo.AllUsers();
        }
    }
}
