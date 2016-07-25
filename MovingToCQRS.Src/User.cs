namespace MovingToCQRS.Src
{
    public class User
    {
        public string UserName { get; }
        public string Name { get; private set; }

        public User(string userName, string name)
        {
            UserName = userName;
            Name = name;
        }

        public void UpdateName(string updatedName)
        {
            Name = updatedName;
        }
    }
}