namespace MovingToCQRS.Src
{
    public class UserRepoCommand
    {
        private readonly UserRepo _repo;

        public UserRepoCommand(UserRepo userRepo)
        {
            _repo = userRepo;
        }

        public void CreateUser(string userName, string name)
        {
            _repo.CreateUser(new User(userName, name));
        }
        
        public void UpdateName(User user, string updatedName)
        {
            user.UpdateName(updatedName);
            _repo.Save(user);
        }

        public void Delete(string userName)
        {
            _repo.Delete(userName);
        }
    }
}