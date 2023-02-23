using SCMDWH.Shared.Models;

namespace SCMDWH.Client.Brokers.Api
{
    public partial interface IApiBroker
    {
        Task<List<GlobalAppUsers>> GetAllGlobalUsersAsync();

        Task AddGlobalUserAsync(GlobalAppUsers user);

        Task UpdateGlobalUserAsync(GlobalAppUsers user);

        Task DeleteGlobalUserAsync(string userName);

    }
}
