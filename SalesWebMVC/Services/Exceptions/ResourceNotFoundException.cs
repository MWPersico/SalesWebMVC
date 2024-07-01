namespace SalesWebMVC.Services.Exceptions
{
    public class ResourceNotFoundException(string id) : ApplicationException($"Resource with id {id} not found!");
}
