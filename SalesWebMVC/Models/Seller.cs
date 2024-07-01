using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Models
{
    [Table("tb_seller")]
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual ISet<SalesRecord>? Sales { get; set; } = new HashSet<SalesRecord>();

        public Seller(){}

        public Seller(string name, string email, DateTime birthDate, double salary, Department department)
        {
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

        public void AddSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales
                .Where(s => s.Date >= initial && s.Date <= final)
                .Sum(s => s.Amount);
        }
    }
}