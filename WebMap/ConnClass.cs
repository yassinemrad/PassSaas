using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using System.Data.SqlClient;

namespace WebMap
{
    //public class ConnClass
    //{
    //    public SqlCommand cmd = new SqlCommand();
    //    public MySqlDataAdapter sda;
    //    public SqlDataReader sdr;
    //    public DataSet ds = new DataSet();
    //    public MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);


    //    public bool IsExist(string Query)
    //    {
    //        bool check = false;
    //        using (MySqlCommand cmd = new MySqlCommand(Query))
    //        {
    //            cmd.Connection = con;
    //            con.Open();
    //            MySqlDataReader sdr = cmd.ExecuteReader();
    //            if (sdr.HasRows)
    //                check = true;
    //        }
    //        //    sdr.Close();
    //        con.Close();
    //        return check;

    //    }

    //    public bool ExecuteQuery(string Query)
    //    {
    //        int j = 0;
    //        using (MySqlCommand cmd = new MySqlCommand(Query))
    //        {
    //            cmd.Connection = con;
    //            con.Open();
    //            j = cmd.ExecuteNonQuery();
    //            con.Close();
    //        }

    //        if (j > 0)
    //            return true;
    //        else
    //            return false;

    //    }

    //    public string GetColumnVal(string Query, string ColumnName)
    //    {
    //        string RetVal = "";
    //        using (MySqlCommand cmd = new MySqlCommand(Query))
    //        {
    //            cmd.Connection = con;
    //            con.Open();
    //            MySqlDataReader sdr = cmd.ExecuteReader();
    //            while (sdr.Read())
    //            {
    //                RetVal = sdr[ColumnName].ToString();
    //                break;
    //            }
    //            //     sdr.Close();
    //            con.Close();
    //        }

    //        return RetVal;
    //    }



    //}
    public class ConnClass
    {
        public static int iu { get; set; }
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter sda;
        public SqlDataReader sdr;
        public DataSet ds = new DataSet();
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MapDb"].ToString());
        
        public bool IsExist(string Query)
        {
            bool check = false;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    check = true;
            }
            sdr.Close();
            con.Close();
            return check;

        }

        public bool ExecuteQuery(string Query)
        {
            int j = 0;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                j = cmd.ExecuteNonQuery();
                con.Close();
            }

            if (j > 0)
                return true;
            else
                return false;

        }

        public string GetColumnVal(string Query, string ColumnName)
        {
            string RetVal = "";
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    RetVal = sdr[ColumnName].ToString();
                    break;
                }
                sdr.Close();
                con.Close();
            }

            return RetVal;


        }

    }
}