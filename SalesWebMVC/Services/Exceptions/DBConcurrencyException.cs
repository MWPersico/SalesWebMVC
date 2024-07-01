namespace SalesWebMVC.Services.Exceptions
{
    public class DBConcurrencyException(string message) : ApplicationException(message);
}
