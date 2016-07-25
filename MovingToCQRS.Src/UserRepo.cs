using System.Collections.Generic;

namespace MovingToCQRS.Src
{
    public interface UserRepo
    {
        void CreateUser(User user);
        int Count();
        User FindByUserName(string userName);
        void Save(User user);
        void Delete(string userName);
        List<User> AllUsers();
    }
}