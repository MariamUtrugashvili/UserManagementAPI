namespace UserManagement.Application.Exceptions
{ 
    public class UserNotFoundException(string message) : Exception(message)
    {
        public string Messige = "This Item Was Not Found";

    }
}
