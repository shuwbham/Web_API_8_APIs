using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Combined.Models;
using RNAppFamily.DTO;

namespace WebAPI_Combined.Controllers
{
    public class RNAppFamilyController : ApiController
    {
        [HttpGet]
        [Route("api/RNAppFamily/{id}")]
        public async Task<IHttpActionResult> GetFamilyData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT DISTINCT
                        f.empcd,
                        f.memname,
                        r.RelationName_eng AS RelationNameEng,
                        f.memdob,
                        f.memdepend
                    FROM 
                        pisempfamily AS f
                    JOIN 
                        mRelationMaster AS r ON f.memrelation = r.RelationId
                    WHERE
                        f.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<RNAppFamilyDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
