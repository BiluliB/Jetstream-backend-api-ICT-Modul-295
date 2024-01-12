namespace JetstreamApi.Interfaces
{
    public interface IAssignService
    {
        Task AssignServiceRequestToUser(int Id, int userId, string? currentUserName);
        Task AssignServiceRequestToUser(int id, int userId);
    }
}