using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;

namespace Pinterest
{
    public partial class UploadImg : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public UploadImg()
        {
            InitializeComponent();
        }
        string s;
        public UploadImg(string str)
        {
            InitializeComponent();
            label1.Text = str;
        }

        private void UploadImg_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
        }
        string path;
        private void UoloadImgbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Image Files(*.jpg;*.png;)| *.jpg;*.png";
            o.Multiselect = false;
            if (o.ShowDialog() == DialogResult.OK)
            {
                path = o.FileName;
            }
            
            
            

        }
        int x = 5;

        private void SaveUpload_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            Homepage home = new Homepage();
            
            cmd.CommandText = "insert into images values (ImgIdSeq.NEXTVAL,:titleimg,:descr,:categ,:pathimg,:uploaderimg)";
            
            cmd.Parameters.Add("titleimg",textBox2.Text);
            cmd.Parameters.Add("descr",textBox1.Text);
            cmd.Parameters.Add("categ",CateCombo.Text);
            cmd.Parameters.Add("pathimg", path);
            cmd.Parameters.Add("uploaderimg", SignIn.usernamepub);
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Added");
                this.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
