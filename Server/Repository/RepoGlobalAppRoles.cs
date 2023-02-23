using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Repository
{

    public interface IRepoGlobalAppRoles
    {
        IEnumerable<GlobalAppRoles> GetRoles();
        //Task<GlobalAppUsers> GetEmployee(int userId);
        //Task<GlobalAppUsers> AddEmployee(GlobalAppUsers user);
        //Task<GlobalAppUsers> UpdateEmployee(GlobalAppUsers user);
        //void DeleteEmployee(int userId);
    }

    public class RepoGlobalAppRoles: IRepoGlobalAppRoles
    {
        public IEnumerable<GlobalAppRoles> GetRoles()
        {
            IEnumerable<GlobalAppRoles> roleList = new List<GlobalAppRoles>()
            {
                new GlobalAppRoles { RoleName = "Administrator" , Remarks = " Rola Administratora" },
                new GlobalAppRoles {RoleName = "Operator" , Remarks = "Rola operatora "},
                new GlobalAppRoles {RoleName = "Manager" , Remarks = "Rola Managera " }

            };

            return roleList;
        }
    }
}
