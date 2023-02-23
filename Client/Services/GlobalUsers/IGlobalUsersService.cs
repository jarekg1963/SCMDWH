using SCMDWH.Shared.Models;

namespace SCMDWH.Client.Services.GlobalUsers
{
    public interface IGlobalUsersService
    {
        Task<List<GlobalAppUsers>> GetAllUsersAsync();
        Task AddUsersAsync(GlobalAppUsers user);

        Task DeleteUsersAsync(GlobalAppUsers user);
    }
}
