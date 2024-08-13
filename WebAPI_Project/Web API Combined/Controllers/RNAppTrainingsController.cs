using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Trainings.DTO;
using WebAPI_Combined.Models;

namespace WebAPI_Combined.Controllers
{
    public class RNAppTrainingsController : ApiController
    {
        [HttpGet]
        [Route("api/RNAppTrainings/{id}")]
        public async Task<IHttpActionResult> GetTrainingData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT DISTINCT
                        t.empcd,
                        t.trngtopic,
                        t.trnginstitute,
                        t.trngdtfrom,
                        t.trngdtto
                    FROM 
                        pisemptraining AS t
                    WHERE 
                        t.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<RNAppTrainingsDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
