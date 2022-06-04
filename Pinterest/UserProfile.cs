using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Pinterest
{
    public partial class UserProfile : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
        }

        private void UserInfo_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "uploaderinfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username", SignIn.usernamepub);
            cmd.Parameters.Add("o", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                imgtitle.Items.Add(dr[0]);
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void imgtitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select image from images where IMGTITLE =:imgtit");
            cmd.Parameters.Add("imgtit", imgtitle.SelectedItem);
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                pictureBox1.ImageLocation = dr[0].ToString();

            }
            dr.Close();
        }
    }
}
