using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WebAPI_Combined.Models;
using Personal.DTO;

namespace WebAPI_Combined.Controllers
{
    public class RNAppPersonalController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            using (ehrmsupLocalEntities dbContext = new ehrmsupLocalEntities())
            {
                string query = @"
                    SELECT DISTINCT
                        e.empcd,
                        e.empfname,
                        e.empmname,
                        e.emplname,
                        e.empfmhname,
                        e.empfhm_mname,
                        e.empfhm_lname,
                        dist.StateAbbr,
                        dist.dis_name,
                        rel.ReligionName,
                        e.empgender,
                        mar.MaritalName,
                        bld.Name AS BloodGroupName,
                        ser.ServiceName,
                        e.dofjoin,
                        e.dofretirecurr,
                        e.empidmasrk,
                        e.empheight
                    FROM 
                        emppersonal AS e 
                    JOIN 
                        mFWdismas AS dist 
                        ON e.StateID = dist.StateId 
                        AND e.distcd = dist.dis_code
                    JOIN 
                        mReligionmaster AS rel 
                        ON e.empreligion = rel.ReligionId
                    JOIN 
                        mMaritalStatus AS mar 
                        ON e.empmarst = mar.MaritalId
                    JOIN 
                        mBloodGroup AS bld 
                        ON e.empblood = bld.Id
                    JOIN 
                        mStateServiceMaster AS ser 
                        ON e.ServiceCd = ser.ServiceCd
                    WHERE 
                        e.empcd = @Empcd";

                var parameters = new SqlParameter[] {
                    new SqlParameter("@Empcd", id)
                };

                var result = dbContext.Database.SqlQuery<EmpPersonalDTO>(query, parameters).ToList();
                return Ok(result);
            }
        }
    }
}
