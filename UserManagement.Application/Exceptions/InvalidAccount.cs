namespace UserManagement.Application.Exceptions
{
    public class InvalidAccount(string message) : Exception(message)
    {
        public string Messige = "Invalid Account";
    }
}
