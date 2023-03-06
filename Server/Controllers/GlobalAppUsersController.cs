using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Server.Data;
using SCMDWH.Server.Repository;
using SCMDWH.Shared.Models;
using SCMDWH.Shared.Tools;

namespace SCMDWH.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalAppUsersController : ControllerBase
    {
        private readonly PurchasingContext _context;
		private readonly IRepoGlobalAppUsers _usersRepo;

		public GlobalAppUsersController(PurchasingContext context,   IRepoGlobalAppUsers usersRepo)
        {
            _context = context;
            _usersRepo = usersRepo;
        }

        [HttpGet("RepoGlobalAppUsers")]
        public async Task<ActionResult<IEnumerable<GlobalAppUsers>>> RepoUsers()
        {

            return Ok(_usersRepo.GetUsers());
        }


        [HttpGet("RepoGlobalAppUsers{userName}")]
        public async Task<ActionResult<GlobalAppUsers>> RepoGetGlobalAppUsers(string userName)
        {
            return _usersRepo.GetUser(userName);
        }





        // GET: api/GlobalAppUsers
        [HttpGet]
        public async Task<ActionResult<List<GlobalAppUsers>>> GetGlobalAppUsers()
        {
            //throw new Exception("A custom message for an application specific exception");
            //return StatusCode(400, "Brak danych na liscie uzytkownikow ");


         

            if (_context.GlobalAppUsers == null)
            {
                return NotFound("App users context not found ");
            }

            try
            {
                 return await _context.GlobalAppUsers.ToListAsync();
            }
            catch (Exception ex) 
            {
                return StatusCode(400, ex.Message);
            }

          
        }
     
            // GET: api/GlobalAppUsers/5
            [HttpGet("{userName}")]
        public async Task<ActionResult<GlobalAppUsers>> GetGlobalAppUsers(string userName)
        {
            var globalAppUser = await _context.GlobalAppUsers.Include(UR => UR.GlobalAppUserRoles).FirstOrDefaultAsync(I => I.UserName == userName);
            if (globalAppUser == null)
            {
                return NotFound();
            }

            return globalAppUser;
        }

        // PUT: api/GlobalAppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlobalAppUsers(string id, GlobalAppUsers globalAppUsers)
        {
            if (id != globalAppUsers.UserName)
            {
                return BadRequest();
            }
            _context.Entry(globalAppUsers).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GlobalAppUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }

            return NoContent();
        }

        // POST: api/GlobalAppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GlobalAppUsers>> PostGlobalAppUsers(GlobalAppUsers globalAppUsers)
        {
          if (_context.GlobalAppUsers == null)
          {
              return Problem("Entity set 'PurchasingContext.GlobalAppUsers'  is null.");
          }

          

            var userExist = await _context.GlobalAppUsers.FirstOrDefaultAsync(c=>c.UserName == globalAppUsers.UserName);

            if (userExist != null) 
            {
                // return Problem("User already exist !!!");
                return StatusCode(400, "User already exists !!!");
            }

           ;

            _context.GlobalAppUsers.Add(globalAppUsers);

            List<CarAdviceMainPlanColumn> rcisColumnList = new List<CarAdviceMainPlanColumn>();

            rcisColumnList = _context.CarAdviceMainPlanComum.Where(c => c.UserName == "rcis").ToList();
           


            // usuwamy kolumny jezeli przez przypadek istnieją dla tego uzytkownia 


           await _context.CarAdviceMainPlanComum.Where(e=>e.UserName == globalAppUsers.UserName).ExecuteDeleteAsync();

            await Task.Delay(100);

            foreach (var c in rcisColumnList)
            {
                CarAdviceMainPlanColumn columnRecordAdd = new CarAdviceMainPlanColumn();


                columnRecordAdd.UserName = globalAppUsers.UserName;
                columnRecordAdd.MainScreenColumn = c.MainScreenColumn;
                columnRecordAdd.OrderColumn = c.OrderColumn;
                columnRecordAdd.Hidden= c.Hidden;
                columnRecordAdd.plHeader = c.plHeader;

                await _context.CarAdviceMainPlanComum.AddAsync(columnRecordAdd);
                
            }

            GlobalAppUserRoles basicRole = new GlobalAppUserRoles();

            basicRole.UserName = globalAppUsers.UserName;
            basicRole.RoleName = "Operator";
            basicRole.AddByUser = "System";
            basicRole.AddTime = DateTime.Now;

            _context.GlobalAppUserRoles.Add(basicRole);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GlobalAppUsersExists(globalAppUsers.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGlobalAppUsers", new { id = globalAppUsers.UserName }, globalAppUsers);
        }

        // DELETE: api/GlobalAppUsers/5
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteGlobalAppUsers(string userName)
        {
          

            if (_context.GlobalAppUsers == null)
            {
                return NotFound("App users context not foud ");
            }

            var globalAppUsers = await _context.GlobalAppUsers.FirstOrDefaultAsync(c=> c.UserName == userName);
            if (globalAppUsers == null)
            {
                return NotFound("User already deleted ");
            }

            try
            {
                var columnsForDelete = _context.CarAdviceMainPlanComum.Where(c => c.UserName == userName).ToList();
                _context.CarAdviceMainPlanComum.RemoveRange(columnsForDelete);
                _context.GlobalAppUsers.Remove(globalAppUsers);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception ex) 
            {
                return StatusCode(400, ex.Message);
            }
            
        }

        private bool GlobalAppUsersExists(string id)
        {
            return (_context.GlobalAppUsers?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
