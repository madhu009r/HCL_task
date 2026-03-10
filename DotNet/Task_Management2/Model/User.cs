using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Task_Management2.Model
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string PasswordHash { get; set; }
        public string role { get; set; }
        public DateTime Lastlogin { get; set; }

    }
}
