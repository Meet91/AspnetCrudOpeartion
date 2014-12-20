using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class BALCountryMaster
{
    public void Insert(BOLCountryMaster Obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPCountryMaster";

        cmd.Parameters.Add(new SqlParameter("@Spara", 1));
        cmd.Parameters.Add(new SqlParameter("@Id",Obj.Id));
        cmd.Parameters.Add(new SqlParameter("@Country", Obj.Country));

        Demo_DAL dal = new Demo_DAL();
        dal.InsertOnly(cmd);
    }

    public void Update(BOLCountryMaster Obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPCountryMaster";

        cmd.Parameters.Add(new SqlParameter("@Spara", 2));
        cmd.Parameters.Add(new SqlParameter("@Id", Obj.Id));
        cmd.Parameters.Add(new SqlParameter("@Country", Obj.Country));

        Demo_DAL dal = new Demo_DAL();
        dal.UpdateOnly(cmd);
    }

    public DataTable Select(BOLCountryMaster Obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPCountryMaster";

        cmd.Parameters.Add(new SqlParameter("@Spara", 3));
        cmd.Parameters.Add(new SqlParameter("@Id", Obj.Id));
        cmd.Parameters.Add(new SqlParameter("@Country", Obj.Country));

        Demo_DAL dal = new Demo_DAL();
        DataTable dt = dal.SelectOnly(cmd);
        return dt;
    }

    public DataTable SelectMaxId(BOLCountryMaster Obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPCountryMaster";

        cmd.Parameters.Add(new SqlParameter("@Spara", 4));
        cmd.Parameters.Add(new SqlParameter("@Id", Obj.Id));
        cmd.Parameters.Add(new SqlParameter("@Country", Obj.Country));

        Demo_DAL dal = new Demo_DAL();
        DataTable dt = dal.SelectOnly(cmd);
        return dt;
    }

    public void Delete(BOLCountryMaster Obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SPCountryMaster";

        cmd.Parameters.Add(new SqlParameter("@Spara", 5));
        cmd.Parameters.Add(new SqlParameter("@Id", Obj.Id));

        Demo_DAL dal = new Demo_DAL();
        dal.DeleteOnly(cmd);
    }

}
