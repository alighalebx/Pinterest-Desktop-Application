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
using System.IO;



namespace Pinterest
{
    public partial class SignIn : Form
    {
        internal static string usernamepub;
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        public SignIn()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void SignIn_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
            OracleDataAdapter adapter;
            OracleCommandBuilder builder;
            DataSet ds;

            UserUp.Hide();
            PassUp.Hide();  
            SignUpBtn.Hide();   
            SignInLink.Hide();
            
        }

        



        //UserIn
        //PassIn
        //SignInBtn
        //SignInLbl
        //SignUpBtn
        //UserUp
        //PassUp

        private void button1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Question.Text = "Already Have an Account?";
            SignInLbl.Text = "Sign Up";
            UserUp.Show();
            PassUp.Show();  
            SignUpBtn.Show();
            SignUpLink.Hide();
            SignInLink.Show();
        }

        private void SignInLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Question.Text = "Don't Have an Account?";
            SignInLbl.Text = "Sign In";
            SignInLink.Hide();
            SignUpLink.Show();
            UserUp.Hide();
            PassUp.Hide();
            SignUpBtn.Hide();
            SignInLink.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into users (username,passwords) values (:usern,:passw)";
            cmd.Parameters.Add("usern", UserUp.Text);
            cmd.Parameters.Add("passw", PassUp.Text);
            
            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                MessageBox.Show("User Added!");
            }

        }

        //private void SignInBtn_Click(object sender, EventArgs e)
        //{

            
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "Signin_check";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("userna", OracleDbType.Varchar2, UserIn.Text, ParameterDirection.Input);
        //    cmd.Parameters.Add("check", OracleDbType.Int32, ParameterDirection.Output);
        //    cmd.Parameters.Add("passwo", OracleDbType.Varchar2, PassIn.Text, ParameterDirection.Input);

            
        //        cmd.ExecuteNonQuery();
        //        string var = cmd.Parameters["check"].Value.ToString();
                
        //    if (var.Equals('0'))
        //        {
        //            MessageBox.Show("No Users Found!");
        //        }

        //    else
        //        {
        //            MessageBox.Show("Logged in");
        //        }

        //    MessageBox.Show("Ay 7aga");


        //}

        private void SignInBtn_Click_1(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "Signin_check";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("userna", OracleDbType.Varchar2, UserIn.Text, ParameterDirection.Input);
            cmd.Parameters.Add("check", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("passwo", OracleDbType.Varchar2, PassIn.Text, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
            string var = cmd.Parameters["check"].Value.ToString();

            if (var == "0")
            {
                MessageBox.Show("No Users Found!");
            }

            else
            {
                Homepage homepage = new Homepage(UserIn.Text);
                UploadImg uploadImg = new UploadImg(UserIn.Text);
                usernamepub = UserIn.Text;
                this.Hide();   
                homepage.Show();
                //Homepage home = new Homepage(UserIn.Text);  
            }

            


        }

       



        //private void button1_Click(object sender, EventArgs e)
        //{

        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = ("Select image from images where imgid = :idd");
        //    cmd.Parameters.Add("idd", textBox1.Text);
        //    cmd.CommandType = CommandType.Text;

        //    OracleDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        pictureBox1.ImageLocation = dr[0].ToString();
        //    }
        //    dr.Close();
        //OracleCommand cmd = new OracleCommand();
        //cmd.Connection = con;
        //cmd.CommandText = ("Select image from images where imgid = 1");
        //OracleDataAdapter da = new OracleDataAdapter(cmd);

        //DataSet ds = new DataSet();


        //da.Fill(ds);

        //if (ds.Tables[0].Rows.Count > 0)

        //{

        //    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["image"]);

        //    pictureBox1.Image = new Bitmap(ms);

        //}
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.Connection=con;
        //    cmd.CommandText = "insert into images (ImgID,ImgTitle,ImgDesc,ImgCategory,image,Uploader) values (:imgid,:imgtitle,:imgdesc,:imgcategory,:image,:uploader)";
        //    cmd.Parameters.Add("imgid", textBox1.Text);
        //    cmd.Parameters.Add("imgtitle", textBox2.Text);
        //    cmd.Parameters.Add("imgdesc", textBox3.Text);
        //    cmd.Parameters.Add("imgcategory", textBox4.Text);
        //    cmd.Parameters.Add("image", textBox5.Text);
        //    cmd.Parameters.Add("uploader", textBox6.Text);

        //   int r = cmd.ExecuteNonQuery();

        //    if (r != -1)
        //    {
        //        MessageBox.Show("iamge added");
        //    }



        //}
    }
}
