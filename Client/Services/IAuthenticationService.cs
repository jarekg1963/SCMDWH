using SCMDWH.Shared.DTO;

namespace SCMDWH.Client.Services
{
	public interface IAuthenticationService
	{
		Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
		Task Logout();
    }
}
