using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Combined.Models;
using Promotions.DTO;

namespace WebAPI_Combined.Controllers
{
    public class RNAppPromotionsController : ApiController
    {
        [HttpGet]
        [Route("api/Promotions/{id}")]
        public async Task<IHttpActionResult> GetPromotionData(string id)
        {

            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT DISTINCT
                        prom.empcd AS Empcd,
                        prom.PromotionDate AS PromotionDate,
                        serMas.ServiceName AS ServiceName,
                        desig.designame AS Designame
                    FROM 
                        PromotionDetails AS prom
                    JOIN 
                        mdesigmast AS desig ON prom.desigcode = desig.desigcode
                    JOIN 
                        mStateServiceMaster AS serMAS ON prom.ServiceCd = serMAS.ServiceCd
                    WHERE
                        prom.empcd = @Empcd
                    ORDER BY 
                        prom.empcd, prom.PromotionDate";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<PromotionsDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
