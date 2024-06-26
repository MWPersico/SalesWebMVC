﻿namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public ISet<SalesRecord> Sales { get; set; } = new HashSet<SalesRecord>();

        public Seller(){}

        public Seller(int id, string name, string email, DateTime birthDate, double salary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
            Department = department;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Seller seller = (Seller) obj;
            return seller.Id == Id;
        }
    }
}