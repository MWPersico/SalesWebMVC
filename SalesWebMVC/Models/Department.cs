using System.Runtime.InteropServices.JavaScript;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<Seller> Sellers { get; set; } = new HashSet<Seller>();

        public Department() { }

        public Department(int id, string name) { Id = id; Name = name; }

        // TODO
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        // TODO
        public double TotalSales(DateTime initial, DateTime final)
        {
            return 0.0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Department department = (Department)obj;
            return department.Id == Id;
        }
    }
}
