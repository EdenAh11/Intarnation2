namespace Q1.BL
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

        public int Insert()
        {
            foreach (User item in _user)
            {
                if (item._email== _email)
                {
                    return 0;
                }
            }
            _user.Add(this);
            UserDBservices UDBservices = new UserDBservices();
            return UDBservices.Insert(this);
        }

        public List<User> Read() => _user;

        public int Update()
        {
            UserDBservices u = new UserDBservices();
            return u.Update(this);  
        }

    }
}
