using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string photoPath;

        public User(string firstName, string lastName, string email, string photoPath)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.photoPath = photoPath;
        }

        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string PhotoPath { get { return photoPath; } set { photoPath = value; } }

    }
}
