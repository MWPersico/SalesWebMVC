namespace SalesWebMVC.Models.ViewModels
{
    public class SalesRecordFormViewModel
    {
        public SalesRecord SalesRecord { get; set; }
        public IList<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
