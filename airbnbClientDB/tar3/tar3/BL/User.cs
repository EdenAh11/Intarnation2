﻿namespace Q1.BL
{
    public class User
    {
        private string _firstName;
        private string _familyName;
        private string _email;
        private string _password;

        private static List<User> _user = new List<User>();

        public User() { }


        public User(string firstName, string familyName, string email, string password)
        {
            _firstName = firstName;
            _familyName = familyName;
            _email = email;
            _password = password;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string FamilyName { get => _familyName; set => _familyName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        public bool Insert()
        {
            foreach (User item in _user)
            {
                if (item._email== _email)
                {
                    return false;
                }
            }
            _user.Add(this);
            return true;
        }

        public List<User> Read() => _user;

    }
}
