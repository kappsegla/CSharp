namespace TestConsoleApp
{
    public interface IAuthorizer
    {
        public bool Authorize(string username, string password);
    }
}