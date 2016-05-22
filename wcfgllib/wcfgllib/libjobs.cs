using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace wcfgllib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "libjobs" in both code and config file together.
    public class libjobs : Ilibjobs
    {
        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\mdfs\mdfs\pubs2015.mdf;Integrated Security=True;Connect Timeout=30";

        public DataSet GetJobs()
        {
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter("Select * from jobs", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public Job GetJobInfo(int jobid)
        {
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand
                ("Select * from jobs where job_id=" + jobid, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Job j = new Job();
            if (dr.Read())
            {
                j.Id = jobid;
                j.Description = dr["job_desc"].ToString();
                j.minlvl = Convert.ToInt32(dr["min_lvl"]);
                j.maxlvl = Convert.ToInt32(dr["max_lvl"]);
            }
            else
            {
                j.Id = -1;
            }
            cn.Close();
            return j;
        }

        public void AddJob(Job j)
        {
            throw new NotImplementedException();
        }
    }
}
