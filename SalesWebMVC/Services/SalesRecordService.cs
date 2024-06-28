using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService(SalesWebMVCContext context) : GenericService<SalesRecord, int?>(context);
}
