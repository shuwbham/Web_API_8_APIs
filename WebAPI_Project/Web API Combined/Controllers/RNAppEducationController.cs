using Education.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Combined.Models;

namespace WebAPI_Combined.Controllers
{
    public class RNAppEducationController : ApiController
    {
        [HttpGet]
        [Route("api/RNAppEducation/{id}")]
        public async Task<IHttpActionResult> GetEducationData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT TOP 100 
                        e.empcd,
                        q.name,
                        e.eduinst,
                        e.eduyear,
                        e.edumark
                    FROM 
                        pisempeducation AS e
                    JOIN 
                        mquali AS q ON q.code = e.eduid
                    WHERE 
                        e.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<RNAppEducationDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
