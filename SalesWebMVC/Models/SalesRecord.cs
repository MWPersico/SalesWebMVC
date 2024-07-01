using SalesWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Models
{
    [Table("tb_sales_record")]
    public class SalesRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller? Seller { get; set; }
        public int SellerId { get; set; }

        public SalesRecord() { }

        public SalesRecord(DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null)return false;
            SalesRecord salesRecord = (SalesRecord)obj;
            return salesRecord.Id == Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
