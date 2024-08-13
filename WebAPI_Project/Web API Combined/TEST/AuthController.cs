using Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Combined.Controllers
{
    public class AuthController : ApiController
    {
        private bool AuthoriseAPI(string empcd, string deptid, string AccessKey)
        {
            bool auth = false;
            // Decrypt the access key
            var dycaccesskey = RijndaelAlgorithm.Decrypt(
            AccessKey,
            CryptoSettings.PassPhrase,
            CryptoSettings.SaltValue,
            CryptoSettings.HashAlgorithm,
            CryptoSettings.PasswordIterations,
            CryptoSettings.InitVector,
            CryptoSettings.KeySize
            );

            // Prepare the parameters for the stored procedure
            var methodparameter = new List<KeyValuePair<string, string>>
            {
            new KeyValuePair<string, string>("@Empcd", empcd.Trim()),
            new KeyValuePair<string, string>("@StateId", StateID),
            new KeyValuePair<string, string>("@accesskey", dycaccesskey)
            };

            // Execute the stored procedure to validate the access key
            DataSet obj = objdal.SelectData("Android_ValidateAccessKey", methodparameter, deptid);

            // Check the result and set the authorization flag
            if (obj != null && obj.Tables.Count > 0 && obj.Tables[0].Rows[0][0].ToString().Trim() == "1")
            {
                auth = true;
            }

            return auth;
        }

    }
}
