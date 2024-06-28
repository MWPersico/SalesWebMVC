using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService(SalesWebMVCContext context) : GenericService<Seller, int?>(context);
}
