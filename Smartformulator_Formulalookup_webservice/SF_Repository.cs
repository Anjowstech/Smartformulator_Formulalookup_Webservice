using System;
using System.Collections.Generic;\
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class SF_Repository
    {
        public List<EntityClassList.BindFormulation> BindFormulation()
        {
            string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<EntityClassList.SearchCAS> loadCASdatasearch = new List<EntityClassList.SearchCAS> { };
                SqlCommand cmdsearchlCAS = new SqlCommand("SELECT CASNo,Description,Classification FROM CAS");
                cmdsearchlCAS.Connection = con;
                con.Open();
                SqlDataReader rdr = cmdsearchlCAS.ExecuteReader();
                while (rdr.Read())
                {
                    EntityClassList.SearchCAS CASdatasearch = new EntityClassList.SearchCAS();
                    CASdatasearch.CASNo = rdr["CASNo"].ToString();
                    CASdatasearch.Description = rdr["Description"].ToString();
                    CASdatasearch.Classification = rdr["Classification"].ToString();

                    loadCASdatasearch.Add(CASdatasearch);
                }
                return loadCASdatasearch;
            }
        }

    }
}