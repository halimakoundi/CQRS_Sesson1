using System;

namespace CQRSWithEvents.Src
{
    public class UserAccountChecker
    {
        public virtual void Check(string userId)
        {
            Console.WriteLine($"User is Valid {userId}");
        }
    }
}