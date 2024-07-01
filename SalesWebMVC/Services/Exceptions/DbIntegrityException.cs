namespace SalesWebMVC.Services.Exceptions
{
    public class DbIntegrityException(string message) : ApplicationException(message);
}
