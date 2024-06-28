using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Models
{
    // OBS: Entidade de domínio implementada manualmente, sobrescreve hashcode e equals

    //Annotations
    [Table("tb_department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ISet<Seller> Sellers { get; set; } = new HashSet<Seller>();

        public Department() { }

        public Department(string name) { Name = name; }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(initial, final));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Department department = (Department)obj;
            return department.Id == Id;
        }
    }
}
