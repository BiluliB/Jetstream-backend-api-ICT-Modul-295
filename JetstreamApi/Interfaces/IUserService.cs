namespace JetstreamApi.Interfaces
{
    /// <summary>
    /// Interface defining the contract for the user service
    /// </summary>
    public interface IUserService
    {
        void CreateUser(string username, string password);
        bool VerifyPassword(string username, string password);
    }
}