namespace SalesWebMVC.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public IList<Department> Departments { get; set; } = new List<Department>();
    }
}
