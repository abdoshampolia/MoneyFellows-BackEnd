using Microsoft.AspNetCore.Identity;

namespace MoneyFellows.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User(string firstName, string lastName, string userName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
