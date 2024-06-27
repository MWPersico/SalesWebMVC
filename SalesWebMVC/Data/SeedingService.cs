using SalesWebMVC.Models.Enums;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _dbContext;

        public SeedingService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Department.Any() || _dbContext.SalesRecord.Any() || _dbContext.Seller.Any())
            {
                return;
            }

            Department[] departments =
            {
                new Department("Computers"),
                new Department("Electronics"),
                new Department("Fashion"),
                new Department("Books")
            };

            Seller[] sellers =
            {
                new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, departments[0]),
                new Seller("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, departments[1]),
                new Seller("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, departments[0]),
                new Seller("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, departments[3]),
                new Seller("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, departments[2]),
                new Seller("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, departments[1])
            };


            

            SalesRecord[] salesRecords =
            {
                new SalesRecord(new DateTime(2018, 09, 25), 11000.0, SaleStatus.BILLED, sellers[0]),
                new SalesRecord(new DateTime(2018, 09, 4), 7000.0, SaleStatus.BILLED, sellers[4]),
                new SalesRecord(new DateTime(2018, 09, 13), 4000.0, SaleStatus.CANCELED, sellers[3]),
                new SalesRecord(new DateTime(2018, 09, 1), 8000.0, SaleStatus.BILLED, sellers[0]),
                new SalesRecord(new DateTime(2018, 09, 21), 3000.0, SaleStatus.BILLED, sellers[2]),
                new SalesRecord(new DateTime(2018, 09, 15), 2000.0, SaleStatus.BILLED, sellers[0]),
                new SalesRecord(new DateTime(2018, 09, 28), 13000.0, SaleStatus.BILLED, sellers[1]),
                new SalesRecord(new DateTime(2018, 09, 11), 4000.0, SaleStatus.BILLED, sellers[3]),
                new SalesRecord(new DateTime(2018, 09, 14), 11000.0, SaleStatus.PENDING, sellers[5]),
                new SalesRecord(new DateTime(2018, 09, 7), 9000.0, SaleStatus.BILLED, sellers[5]),
                new SalesRecord(new DateTime(2018, 09, 13), 6000.0, SaleStatus.BILLED, sellers[1]),
                new SalesRecord(new DateTime(2018, 09, 25), 7000.0, SaleStatus.PENDING, sellers[2]),
                new SalesRecord(new DateTime(2018, 09, 29), 10000.0, SaleStatus.BILLED, sellers[3]),
                new SalesRecord(new DateTime(2018, 09, 4), 3000.0, SaleStatus.BILLED, sellers[4]),
                new SalesRecord(new DateTime(2018, 09, 12), 4000.0, SaleStatus.BILLED, sellers[0]),
                new SalesRecord(new DateTime(2018, 10, 5), 2000.0, SaleStatus.BILLED, sellers[3]),
                new SalesRecord(new DateTime(2018, 10, 1), 12000.0, SaleStatus.BILLED, sellers[0]),
                new SalesRecord(new DateTime(2018, 10, 24), 6000.0, SaleStatus.BILLED, sellers[2]),
                new SalesRecord(new DateTime(2018, 10, 22), 8000.0, SaleStatus.BILLED, sellers[4]),
                new SalesRecord(new DateTime(2018, 10, 15), 8000.0, SaleStatus.BILLED, sellers[5]),
                new SalesRecord(new DateTime(2018, 10, 17), 9000.0, SaleStatus.BILLED, sellers[1]),
                new SalesRecord(new DateTime(2018, 10, 24), 4000.0, SaleStatus.BILLED, sellers[3]),
                new SalesRecord(new DateTime(2018, 10, 19), 11000.0, SaleStatus.CANCELED, sellers[1]),
                new SalesRecord(new DateTime(2018, 10, 12), 8000.0, SaleStatus.BILLED, sellers[4]),
                new SalesRecord(new DateTime(2018, 10, 31), 7000.0, SaleStatus.BILLED, sellers[2]),
                new SalesRecord(new DateTime(2018, 10, 6), 5000.0, SaleStatus.BILLED, sellers[3]),
                new SalesRecord(new DateTime(2018, 10, 13), 9000.0, SaleStatus.PENDING, sellers[0]),
                new SalesRecord(new DateTime(2018, 10, 7), 4000.0, SaleStatus.BILLED, sellers[2]),
                new SalesRecord(new DateTime(2018, 10, 23), 12000.0, SaleStatus.BILLED, sellers[4]),
                new SalesRecord(new DateTime(2018, 10, 12), 5000.0, SaleStatus.BILLED, sellers[1])
            };

            _dbContext.Department.AddRange(departments);
            _dbContext.Seller.AddRange(sellers);
            _dbContext.SalesRecord.AddRange(salesRecords);

            _dbContext.SaveChanges();
        }
    }
}
