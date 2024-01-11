using JetstreamApi.Common;
using JetstreamApi.Models;

namespace JetstreamApi.Interfaces
{
    /// <summary>
    /// Interface defining the contract for the user service
    /// </summary>
    public interface IUserService
    {
        void CreateUser(string username, string password, Roles role);
        bool VerifyPassword(string username, string password);
        void UnlockUser(string username);
        User GetUserByUsername(string userName);
    }
}