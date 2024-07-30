namespace CarRental.Core.Models
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly YearOfBirth { get; set; }

        public Client() { }
        public Client(string firstName, string lastName, DateOnly yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }
    }
}
