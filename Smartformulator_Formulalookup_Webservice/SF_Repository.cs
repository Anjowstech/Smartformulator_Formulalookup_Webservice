using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Smartformulator_Formulalookup_Webservice
{
    public class SF_Repository
    {
        public List<EntityClassList.Displaygrid> Displaygrid(string Formula)
        {
            Formula = "DISPERSION-2064.Ver 02";

            string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<EntityClassList.Displaygrid> loadformulagrid= new List<EntityClassList.Displaygrid> { };
                SqlCommand cmdFormulagrid = new SqlCommand("SELECT * FROM AerosolVOCDetail Where FormulaCode = '" + Formula + "'");
                cmdFormulagrid.Connection = con;
                con.Open();
                SqlDataReader rdr = cmdFormulagrid.ExecuteReader();
                while (rdr.Read())
                {
                    EntityClassList.Displaygrid displayformula = new EntityClassList.Displaygrid();
                    displayformula.Ingredients = rdr["Ingredients"].ToString();
                    displayformula.FillRatio = rdr["FillRatio"].ToString();
                    displayformula.VOCPercentage = rdr["VOCPercentage"].ToString();

                    loadformulagrid.Add(displayformula);
                }
                return loadformulagrid;
            }
        }
        public string SaveUpdateFormulation(string PDRNo, string FormulaCode, string FormulaName, string TotalVOCPercentage, string TotalPercentage,
            string AddedBy, string AddedDt, string operation)


        {
            string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                PDRNo = "2120";
                AddedDt = "2020";
                FormulaCode = "DISPERSION-2064.Ver 02";
                FormulaName = "FORMULANAMETEST";
                TotalVOCPercentage = "30";
                double newvoc = double.Parse(TotalVOCPercentage);
                TotalPercentage = "100";
                double newtotal = double.Parse(TotalPercentage);
                AddedBy = "NEWADD";
                int newDt = Convert.ToDateTime(AddedDt);
                operation = "Insert";

                switch (operation)
                {

                    case "Insert":
                        {

                            SqlCommand cmdinsert = new SqlCommand("Delete From AerosolVOCMain where FormulaCode = '" + FormulaCode + "'");
                            cmdinsert.CommandType = CommandType.StoredProcedure;
                            cmdinsert.CommandText = "sp_InsertAerosolVOCMain";
                            cmdinsert.Connection = con;
                            con.Open();
                            cmdinsert.Parameters.AddWithValue("@PDRNo", PDRNo);
                            cmdinsert.Parameters.AddWithValue("@FormulaCode", FormulaCode);
                            cmdinsert.Parameters.AddWithValue("@FormulaName", FormulaName);
                            cmdinsert.Parameters.AddWithValue("@TotalVOCPercentage", newvoc);
                            cmdinsert.Parameters.AddWithValue("@TotalPercentage", newtotal);
                            cmdinsert.Parameters.AddWithValue("@AddedBy", AddedBy);
                            cmdinsert.Parameters.AddWithValue("@AddedDt", newDt);
                            SqlParameter ProcedureStatus = new SqlParameter();



                            ProcedureStatus.DbType = DbType.String;
                            ProcedureStatus.ParameterName = "@ProcedureStatus";
                            ProcedureStatus.Size = 100;
                            ProcedureStatus.Direction = ParameterDirection.Output;
                            cmdinsert.Parameters.Add(ProcedureStatus);
                            cmdinsert.ExecuteNonQuery();
                            if (ProcedureStatus.Value.ToString() == "Inserted")
                            {
                                return "Inserted";
                            }
                            break;
                        }
                    case "Update":
                        {
                            SqlCommand cmdupdate = new SqlCommand("Delete From AerosolVOCMain where FormulaCode = '" + FormulaCode + "'");
                            cmdupdate.CommandType = CommandType.StoredProcedure;
                            cmdupdate.CommandText = "sp_InsertAerosolVOCMain";
                            cmdupdate.Connection = con;
                            con.Open();
                            cmdupdate.Parameters.AddWithValue("@PDRNo", PDRNo);
                            cmdupdate.Parameters.AddWithValue("@FormulaCode", FormulaCode);
                            cmdupdate.Parameters.AddWithValue("@FormulaName", FormulaName);
                            cmdupdate.Parameters.AddWithValue("@TotalVOCPercentage", newvoc);
                            cmdupdate.Parameters.AddWithValue("@TotalPercentage", newtotal);
                            cmdupdate.Parameters.AddWithValue("@AddedBy", AddedBy);
                            cmdupdate.Parameters.AddWithValue("@AddedDt", newDt);
                            SqlParameter ProcedureStatus = new SqlParameter();


                            ProcedureStatus.DbType = DbType.String;
                            ProcedureStatus.ParameterName = "@ProcedureStatus";
                            ProcedureStatus.Size = 100;
                            ProcedureStatus.Direction = ParameterDirection.Output;
                            cmdupdate.Parameters.Add(ProcedureStatus);
                            cmdupdate.ExecuteNonQuery();
                            if (ProcedureStatus.Value.ToString() == "Update")
                            {
                                return "Update";
                            }
                            break;

                        }



                }
                return null;
            }

        
        
        }

    }
  }