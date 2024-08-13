

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI_Combined.Models;
using TransferPosting.DTO;

namespace WebAPI_Combined.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RNAppTransfersController : ApiController
    {
        [HttpGet]
        [Route("api/Transfer/{id}")]
        public async Task<IHttpActionResult> GetTrainingData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT DISTINCT
                        jr.empcd,
                        jr.joindt,
                        jr.relievedt,
                        fwdist.dis_name,
                        desig.designame,
                        om.officename 
                    FROM 
                        pisempjoinrelievedetail AS jr
                    JOIN 
                        mofficemaster AS om ON jr.joinofficeid = om.officeid
                    JOIN 
                        mFWdismas AS fwdist ON om.distcd = fwdist.dis_code
                    JOIN 
                        mdesigmast AS desig ON jr.joindesig = desig.desigcode
                    WHERE 
                        jr.empcd = @Empcd
                    ORDER BY 
                        jr.empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<TransfersDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
