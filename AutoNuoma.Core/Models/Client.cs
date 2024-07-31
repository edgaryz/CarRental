namespace CarRental.Core.Models
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime YearOfBirth { get; set; }

        public Client() { }
        public Client(string firstName, string lastName, DateTime yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }

        public override string ToString()
        {
            return $"Client: {FirstName} {LastName} {YearOfBirth.ToString("yyyy-MM-dd")}";
        }
    }
}
