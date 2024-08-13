using System.ComponentModel.DataAnnotations;

namespace CarRental.Core.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
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
            return $"Client: ID {Id}, {FirstName} {LastName} {YearOfBirth.ToString("yyyy-MM-dd")}";
        }
    }
}
