using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Combined.Models;
using Leaves.DTO;

namespace WebAPI_Combined.Controllers
{
    public class RNAppLeavesController : ApiController
    {
        [HttpGet]
        [Route("api/RNAppLeaves/{id}")]
        public async Task<IHttpActionResult> GetLeaveData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT 
                        e.empcd,
                        l.LeaveTypeName,
                        e.fromdt,
                        e.todt,
                        e.totalNoOfDays,
                        e.leavbal
                    FROM pisempleave AS e
                    JOIN mLeaveTypes AS l on e.leavetype = l.LeaveTypeID
                    WHERE e.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<RNAppLeavesDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
