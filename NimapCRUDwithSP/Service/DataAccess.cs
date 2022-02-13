using NimapCRUDwithSP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NimapCRUDwithSP.Service
{
    public class DataAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public List<ProductModel> GetProducts()
        {
            cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            List<ProductModel> list = new List<ProductModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ProductModel
                {
                    CategoryID = Convert.ToInt32(dr["CategoryID"]),
                    CategoryName = dr["CategoryName"].ToString(),
                    ProductID = Convert.ToInt32(dr["ProductID"]),
                    ProductName = dr["ProductName"].ToString()
                   
                });
            }
            return list;


        }

        public bool InsertProd(ProductModel prod)
        {
            cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", prod.CategoryName);
            cmd.Parameters.AddWithValue("@ProductID", prod.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", prod.ProductName);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateProd(ProductModel prod)
        {
            cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", prod.CategoryName);
            cmd.Parameters.AddWithValue("@CategoryID", prod.CategoryID);
            cmd.Parameters.AddWithValue("@ProductID", prod.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", prod.ProductName);
            
            
            con.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int DeleteProd(int CategoryID)
        {
            cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}