using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class Demo_DAL
    {
        public string GetConnectionString()
        {
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            return constr;
        }

        internal void InsertOnly(SqlCommand cmd)
        {
            string constr = GetConnectionString();
            SqlConnection con = new SqlConnection(constr);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void UpdateOnly(SqlCommand cmd)
        {
            string constr = GetConnectionString();
            SqlConnection con = new SqlConnection(constr);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal DataTable SelectOnly(SqlCommand cmd)
        {
            string constr = GetConnectionString();
            SqlConnection con = new SqlConnection(constr);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataReader sdr;
            con.Open();
            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            return dt;
        }

        internal void DeleteOnly(SqlCommand cmd)
        {
            string constr = GetConnectionString();
            SqlConnection con = new SqlConnection(constr);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
