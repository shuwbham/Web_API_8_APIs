using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
namespace eManavSampada
{
    public class DALDB
    {
        //string st = Convert.ToString(HttpContext.Current.Session["SqlConn"]); //Convert.ToString(HttpContext.Current.Session["ConType"]);
        string st1 = "1"; //Convert.ToString(HttpContext.Current.Session["ConType"]);
        public string ReportPath = "", ReportServerUrl="", ReportServerCredentials="";
        public DALDB()
        {
            try
            {
                object sessionKey = eManavSampada.Models.CurrentSession.DeptID;
                if (sessionKey == null)
                {
                    ReportPath = ConfigurationManager.AppSettings["ReportPath"];
                    ReportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
                    ReportServerCredentials = ConfigurationManager.AppSettings["ReportServerCredentials"];
                }
                else if ((sessionKey.ToString().ToUpper() == "UPD0009") || (sessionKey.ToString().ToUpper() == "UPD0238") || (sessionKey.ToString().ToUpper() == "UPD0244") || (sessionKey.ToString().ToUpper() == "UPD0129") || (sessionKey.ToString().ToUpper() == "UPD0133") || (sessionKey.ToString().ToUpper() == "UPD0229") || (sessionKey.ToString().ToUpper() == "UPD0231") || (sessionKey.ToString().ToUpper() == "UPD0239") || (sessionKey.ToString().ToUpper() == "UPD0240") || (sessionKey.ToString().ToUpper() == "UPD0002") || (sessionKey.ToString().ToUpper() == "UPD0253") || (sessionKey.ToString().ToUpper() == "UPD0252") || (sessionKey.ToString().ToUpper() == "UPD0283") || (sessionKey.ToString().ToUpper() == "UPD0314") || (sessionKey.ToString().ToUpper() == "UPD0315") || (sessionKey.ToString().ToUpper() == "UPD0316") || (sessionKey.ToString().ToUpper() == "UPD0317") || (sessionKey.ToString().ToUpper() == "UPD0318") || (sessionKey.ToString().ToUpper() == "UPD0319") || (sessionKey.ToString().ToUpper() == "UPD0320") || (sessionKey.ToString().ToUpper() == "UPD0321") || (sessionKey.ToString().ToUpper() == "UPD0322") || (sessionKey.ToString().ToUpper() == "UPD0323") || (sessionKey.ToString().ToUpper() == "UPD0324") || (sessionKey.ToString().ToUpper() == "UPD0325") || (sessionKey.ToString().ToUpper() == "UPD0326") || (sessionKey.ToString().ToUpper() == "UPD0327") || (sessionKey.ToString().ToUpper() == "UPD0328") || (sessionKey.ToString().ToUpper() == "UPD0329"))
                {
                    ReportPath = ConfigurationManager.AppSettings["ReportPathNHM"];
                    ReportServerUrl = ConfigurationManager.AppSettings["ReportServerUrlNHM"];
                    ReportServerCredentials = ConfigurationManager.AppSettings["ReportServerCredentialsNHM"];
                }else if (sessionKey.ToString().Trim().ToUpper() == "UPD0003" || sessionKey.ToString().Trim().ToUpper() == "UPD0004")
                {
                    ReportPath = ConfigurationManager.AppSettings["ReportPathBasic"];
                    ReportServerUrl = ConfigurationManager.AppSettings["ReportServerUrlBasic"];
                    ReportServerCredentials = ConfigurationManager.AppSettings["ReportServerCredentialsBasic"];
                }
                else
                {
                    ReportPath = ConfigurationManager.AppSettings["ReportPath"];
                    ReportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
                    ReportServerCredentials = ConfigurationManager.AppSettings["ReportServerCredentials"];
                }
            }
            catch (Exception)
            {
                //ReportPath = ConfigurationManager.AppSettings["ReportPath"];
                //ReportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"];
                //ReportServerCredentials = ConfigurationManager.AppSettings["ReportServerCredentials"];
            }
        }
        public string GetConnection(string dept=null)
        {
            // return ConfigurationManager.ConnectionStrings[connectionId].ConnectionString;
            //Start:Added by Shahma on 29042020
            if (dept==null)
            {
                object sessionKey = eManavSampada.Models.CurrentSession.DeptID;
                if (sessionKey != null && sessionKey.ToString() != "" && sessionKey.ToString() != "0")
                {
                    //if (sessionKey == null || sessionKey.ToString() == "" || sessionKey.ToString() == "0" || sessionKey.ToString() != "UPD0003")
                    if (sessionKey.ToString().Trim().ToUpper() == "UPD0003" || sessionKey.ToString().Trim().ToUpper() == "UPD0004")
                    {
                        return ConfigurationManager.ConnectionStrings["PMISConnectionBasic"].ConnectionString;
                    }
                    else if ((sessionKey.ToString().ToUpper() == "UPD0009") || (sessionKey.ToString().ToUpper() == "UPD0238") || (sessionKey.ToString().ToUpper() == "UPD0244") || (sessionKey.ToString().ToUpper() == "UPD0129") || (sessionKey.ToString().ToUpper() == "UPD0133") || (sessionKey.ToString().ToUpper() == "UPD0229") || (sessionKey.ToString().ToUpper() == "UPD0231") || (sessionKey.ToString().ToUpper() == "UPD0239") || (sessionKey.ToString().ToUpper() == "UPD0240") || (sessionKey.ToString().ToUpper() == "UPD0002") || (sessionKey.ToString().ToUpper() == "UPD0253") || (sessionKey.ToString().ToUpper() == "UPD0252") || (sessionKey.ToString().ToUpper() == "UPD0283") || (sessionKey.ToString().ToUpper() == "UPD0314") || (sessionKey.ToString().ToUpper() == "UPD0315") || (sessionKey.ToString().ToUpper() == "UPD0316") || (sessionKey.ToString().ToUpper() == "UPD0317") || (sessionKey.ToString().ToUpper() == "UPD0318") || (sessionKey.ToString().ToUpper() == "UPD0319") || (sessionKey.ToString().ToUpper() == "UPD0320") || (sessionKey.ToString().ToUpper() == "UPD0321") || (sessionKey.ToString().ToUpper() == "UPD0322") || (sessionKey.ToString().ToUpper() == "UPD0323") || (sessionKey.ToString().ToUpper() == "UPD0324") || (sessionKey.ToString().ToUpper() == "UPD0325") || (sessionKey.ToString().ToUpper() == "UPD0326") || (sessionKey.ToString().ToUpper() == "UPD0327") || (sessionKey.ToString().ToUpper() == "UPD0328") || (sessionKey.ToString().ToUpper() == "UPD0329"))
                    {
                        return ConfigurationManager.ConnectionStrings["PMISConnectionNHM"].ConnectionString;
                    }
                    else
                    {
                        return ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString;
                    }
                }else
                {
                    return "";
                }
            }else
            {
                if (dept=="")
                {
                    return ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString;
                }else if (dept.ToString().Trim().ToUpper() == "UPD0003" || dept.ToString().Trim().ToUpper() == "UPD0004")
                {
                    return ConfigurationManager.ConnectionStrings["PMISConnectionBasic"].ConnectionString;
                }
                else if ((dept.Trim().ToUpper() == "UPD0009") || (dept.Trim().ToUpper() == "UPD0238") || (dept.Trim().ToUpper() == "UPD0244") || (dept.ToString().ToUpper() == "UPD0129") || (dept.ToString().ToUpper() == "UPD0133") || (dept.ToString().ToUpper() == "UPD0229") || (dept.ToString().ToUpper() == "UPD0231") || (dept.ToString().ToUpper() == "UPD0239") || (dept.ToString().ToUpper() == "UPD0240") || (dept.ToString().ToUpper() == "UPD0002") || (dept.ToString().ToUpper() == "UPD0253") || (dept.ToString().ToUpper() == "UPD0252") || (dept.ToString().ToUpper() == "UPD0283") || (dept.ToString().ToUpper() == "UPD0314") || (dept.ToString().ToUpper() == "UPD0315") || (dept.ToString().ToUpper() == "UPD0316") || (dept.ToString().ToUpper() == "UPD0317") || (dept.ToString().ToUpper() == "UPD0318") || (dept.ToString().ToUpper() == "UPD0319") || (dept.ToString().ToUpper() == "UPD0320") || (dept.ToString().ToUpper() == "UPD0321") || (dept.ToString().ToUpper() == "UPD0322") || (dept.ToString().ToUpper() == "UPD0323") || (dept.ToString().ToUpper() == "UPD0324") || (dept.ToString().ToUpper() == "UPD0325") || (dept.ToString().ToUpper() == "UPD0326") || (dept.ToString().ToUpper() == "UPD0327") || (dept.ToString().ToUpper() == "UPD0328") || (dept.ToString().ToUpper() == "UPD0329"))
                {
                    return ConfigurationManager.ConnectionStrings["PMISConnectionNHM"].ConnectionString;
                }
                else
                {
                    return ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString;
                }
            }
        }

        //   public DataSet SelectData(string MethodName, XmlNodeList objeParameter)
        public DataSet SelectData(string MethodName, List<KeyValuePair<string, string>> methodPara,string dept=null)
         {
            //Modified by Shahma on 29042020
            //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString);
            SqlConnection sqlConnection = new SqlConnection(GetConnection(dept));
            DataSet dataSet = new DataSet();
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                SqlCommand sqlCommand = new SqlCommand(MethodName, sqlConnection);
                sqlCommand.CommandTimeout = 3600;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ////foreach (XmlElement xn in objeParameter)
                ////{
                ////    if (XmlUtility.GetStringAttribute(xn, "Value") == "")
                ////    {
                ////        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), DBNull.Value);
                ////    }
                ////    else if (XmlUtility.GetStringAttribute(xn, "Value") == "EmptyString")
                ////    {
                ////        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), "");
                ////    }
                ////    else
                ////    {
                ////        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), XmlUtility.GetStringAttribute(xn, "Value"));
                ////    }
                ////}

                if (methodPara != null)
                {
                    foreach (var element in methodPara)
                    {
                       if (element.Value == "")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, DBNull.Value);
                        }
                        else if (element.Value == "EmptyString")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, "");
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, element.Value);
                        }
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                 if(sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                // Comment By Vivek on 07-Nov-2019
                ////EncryptionHelper xmlencrypt = new EncryptionHelper();
                ////string xmlString = XmlUtility.DatasetToXml(dataSet);
                ////xmlByte = xmlencrypt.Encrypt(xmlString);
                ////return xmlByte;
                // End By Vivek on 07-Nov-2019
                return dataSet;
            }
            catch (Exception ex)
            {
                //EncryptionHelper xmlencrypt = new EncryptionHelper();
                //xmlByte = xmlencrypt.Encrypt(ex.Message);
                //return xmlByte;
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return dataSet;
            }
            finally
            {

                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();
                dataSet.Dispose();
            }
            
        }

        //****** Insert Details Query.....
       // public byte[] Insert(string MethodName, XmlNodeList objeParameter, string connectionString)
        public string InsertData(string MethodName, List<KeyValuePair<string, string>> methodPara)
        {
            //Modified by Shahma on 29042020
            //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString);
            SqlConnection sqlConnection = new SqlConnection(GetConnection());

            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                SqlCommand sqlCommand = new SqlCommand(MethodName, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                //foreach (XmlElement xn in objeParameter)
                //{
                //    if (XmlUtility.GetStringAttribute(xn, "Value") == "")
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), DBNull.Value);
                //    }
                //    else if (XmlUtility.GetStringAttribute(xn, "Value") == "EmptyString")
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), "");
                //    }
                //    else
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), XmlUtility.GetStringAttribute(xn, "Value"));
                //    }
                //}
                if (methodPara != null)
                {
                    foreach (var element in methodPara)
                    {
                        if (element.Value == "")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, DBNull.Value);
                        }
                        else if (element.Value == "EmptyString")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, "");
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, element.Value);
                        }
                    }
                }
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

              //  byte[] xmlByte = xmlencrypt.Encrypt("True");
                return "True";

            }
            catch (Exception ex)
            {
                // byte[] xmlByte = xmlencrypt.Encrypt(ex.Message);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return ex.Message.ToString();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();
            }

        }

        //***************Update Details Query
        // public byte[] Update(string MethodName, XmlNodeList objeParameter, string connectionString)
        public string UpdateData(string MethodName, List<KeyValuePair<string, string>> methodPara, string dept = null)
        {
            //Modified by Shahma on 29042020
            //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMISConnection"].ConnectionString);
            SqlConnection sqlConnection = new SqlConnection(GetConnection(dept));
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                SqlCommand sqlCommand = new SqlCommand(MethodName, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                //foreach (XmlElement xn in objeParameter)
                //{

                //    if (XmlUtility.GetStringAttribute(xn, "Value") == "")
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), DBNull.Value);
                //    }
                //    else if (XmlUtility.GetStringAttribute(xn, "Value") == "EmptyString")
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), "");
                //    }
                //    else
                //    {
                //        sqlCommand.Parameters.AddWithValue(XmlUtility.GetStringAttribute(xn, "Name"), XmlUtility.GetStringAttribute(xn, "Value"));
                //    }
                //}
                if (methodPara != null)
                {
                    foreach (var element in methodPara)
                    {
                        if (element.Value == "")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, DBNull.Value);
                        }
                        else if (element.Value == "EmptyString")
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, "");
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue(element.Key, element.Value);
                        }
                    }
                }
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
               // byte[] xmlByte = xmlencrypt.Encrypt("True");
                return "True";
            }
            catch (Exception ex)
            {
                // byte[] xmlByte = xmlencrypt.Encrypt(ex.Message);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return ex.Message.ToString();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();
            }
        }
    }
}