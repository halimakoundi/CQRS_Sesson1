namespace CQRS_Session1.Src
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

        public override bool Equals(object obj)
        {
            var otherUser   = (User)obj;
            return UserName.Equals(otherUser.UserName)
                && Name.Equals(otherUser.Name);
        }

        public void UpdateName(string updatedName)
        {
            Name = updatedName;
        }
    }
}