using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_Combined.Models;
using RNAppAddress.DTO;

namespace WebAPI_Combined.Controllers
{
    public class RNAppAddressController : ApiController
    {
        [HttpGet]
        [Route("api/RNAppAddress/{id}")]
        public async Task<IHttpActionResult> GetAddressData(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                // Set the command timeout to 120 seconds (2 minutes)
                dbContext.Database.CommandTimeout = 120;

                string query = @"
                    SELECT DISTINCT
                        a.empcd,
                        -- Present address
                        a.preHouseNumber,
                        fwb.blk_name AS preBlockName,
                        fwd.dis_name AS preDistrictName,
                        fwd.StateAbbr AS preStateAbbr,
                        a.preMh_Vill AS preVillage,
                        a.prepin AS prePinCode,
                        a.premobile AS preMobile,
                        a.prephone AS prePhone,
                        -- Permanent address
                        a.perHouseNumber,
                        fwb.blk_name AS permBlockName,
                        fwd.dis_name AS permDistrictName,
                        fwd.StateAbbr AS permStateAbbr,
                        a.perMh_Vill AS permVillage,
                        a.permpin AS permPinCode,
                        a.permobile AS permMobile,
                        a.permphone AS permPhone,
                        a.email
                    FROM pisempaddress AS a
                    JOIN mFWdismas AS fwd 
                        ON a.predistt = fwd.dis_code 
                        AND a.permdistt = fwd.dis_code
                        AND a.prestate = fwd.StateId 
                        AND a.permstate = fwd.StateId
                    JOIN mFWblkmas AS fwb 
                        ON a.preblock = fwb.blk_code 
                        AND a.permblock = fwb.blk_code
                    WHERE a.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = await dbContext.Database.SqlQuery<RNAppAddressDTO>(query, parameters).ToListAsync();

                if (result == null || !result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
