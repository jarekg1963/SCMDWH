using SCMDWH.Shared.Models;

namespace SCMDWH.Client.Brokers.Api
{
    public partial class ApiBroker
    {
        private const string PostRelativeUrl = "/api/GlobalAppUsers/";
        public async Task<List<GlobalAppUsers>> GetAllGlobalUsersAsync() =>
            await this.GetAsync<List<GlobalAppUsers>>(PostRelativeUrl);

        public async Task AddGlobalUserAsync(GlobalAppUsers user) =>
            await this.PostAsync<GlobalAppUsers>(PostRelativeUrl, user);

        public async Task UpdateGlobalUserAsync(GlobalAppUsers user) =>
        await this.PostAsync<GlobalAppUsers>(PostRelativeUrl, user);

        public async Task DeleteGlobalUserAsync(string userName) =>
       await this.DeleteAsync(PostRelativeUrl + userName);

    }
}
