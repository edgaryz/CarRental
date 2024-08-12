﻿using CarRental.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Core.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }

        public Employee() { }
        public Employee(string firstName, string lastName, Position position)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
        public Employee(int id, string firstName, string lastName, Position position)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }

        public double CountSalary(double baseSalary, int completedOrders = 0)
        {
            if (Position == Position.Dealer)
            {
                return baseSalary + (completedOrders * 7);
            }
            else
            {
                return baseSalary;
            }
        }
        public override string ToString()
        {
            return $"Employee: {Id} {FirstName} {LastName}, {Position}";
        }
    }
}
