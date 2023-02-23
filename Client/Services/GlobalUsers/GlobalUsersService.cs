using SCMDWH.Client.Brokers.Api;
using SCMDWH.Shared.Models;
using SCMDWH.Shared.Tools;

namespace SCMDWH.Client.Services.GlobalUsers
{
    public class GlobalUsersService: IGlobalUsersService
    {
        private readonly IApiBroker apiBroker;
    
        public GlobalUsersService(IApiBroker apiBroker) 
        {
        
            this.apiBroker = apiBroker;

        }

        public async Task<List<GlobalAppUsers>> GetAllUsersAsync()
        {

            try
            {
                return await apiBroker.GetAllGlobalUsersAsync();
            }
            catch (Exception ex)
            {

                throw new PostBadRequestException(ex);
            }

            

        }

        public async Task AddUsersAsync(GlobalAppUsers user)
        {
            // ValidatePost(user);
            try
            {
                await apiBroker.AddGlobalUserAsync(user);
            }
            catch (Exception ex)
            {

                throw new PostBadRequestException(ex);
            }
        }


        public async Task DeleteUsersAsync(GlobalAppUsers user)
        {
            // ValidatePost(user);
            try
            {
                await apiBroker.DeleteGlobalUserAsync(user.UserName);
            }
            catch (Exception ex)
            {

                throw new PostBadRequestException(ex);
            }
        }


    }
}
