using Microsoft.AspNetCore.Http.HttpResults;
using SCMDWH.Shared.Models;
using System;

namespace SCMDWH.Server.Repository
{
	public interface IRepoGlobalAppUsers
	{
		IEnumerable<GlobalAppUsers> GetUsers();
		GlobalAppUsers GetUser(string userName);
		//Task<GlobalAppUsers> AddEmployee(GlobalAppUsers user);
		//Task<GlobalAppUsers> UpdateEmployee(GlobalAppUsers user);
		//void DeleteUser(string userName);
	}

	public class RepoGlobalAppUsers : IRepoGlobalAppUsers
	{
        public List<GlobalAppUsers> users = new List<GlobalAppUsers>()
            {
                new GlobalAppUsers {UserName = "Jarek" , Email = "qqqq@qqqqq" ,Mobile = "888 888 888", Active = true , CreatedBy ="Admin" },
                new GlobalAppUsers {UserName = "Tomasz" , Email = "qqqq@qqqqq" , Mobile = "888 888 888",Active = true , CreatedBy ="Admin"},
                new GlobalAppUsers {UserName = "Michal" , Email = "qqqq@qqqqq" ,Mobile = "888 888 888", Active = true , CreatedBy ="Admin" },
                new GlobalAppUsers {UserName = "External" , Email = "qqqq@qqqqq" ,Mobile = "888 888 888", Active = true ,External = true, CreatedBy ="Admin" }

            };


		public GlobalAppUsers GetUser(string userName)
		{
			return users.FirstOrDefault(c=>c.UserName == userName);
		}

        public  IEnumerable<GlobalAppUsers> GetUsers()
		{
			return users;
		}
	}

}
