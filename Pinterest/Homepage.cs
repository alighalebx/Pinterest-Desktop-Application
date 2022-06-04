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
using System.Runtime.InteropServices;

namespace Pinterest
{
    public partial class Homepage : Form
    {

        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );

        public Homepage()
        {
            InitializeComponent();


           
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Homepage_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

        }

        private void customizeDesing()
        {
            Categorypanel.Visible = false;
            ReportPanel.Visible = false;
        }
        private void hideSubMenu()
        {
            if (Categorypanel.Visible == true)
            {
                Categorypanel.Visible = false;
            }
            if (ReportPanel.Visible == true)
            {
                ReportPanel.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void Categorybtn_Click(object sender, EventArgs e)
        {
            showSubMenu(Categorypanel);
        }
        public Homepage(string str)
        {
            InitializeComponent();
            NameTxt.Text = str;
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();

            SignIn sign = new SignIn();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            UserImg.SizeMode = PictureBoxSizeMode.AutoSize;
            Comment.Hide();
            Comment_txt.Hide();
            Addcomment.Hide();
            customizeDesing();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            
            userProfile.Show();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            this.Hide();
            signin.Show();
        }
        int CurrentImg;
        List<string> UserImgList;
        int CurrentImg2;
        List<string> UserImgList2;

        void selectload()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Liked from likes where LikeImageId =:vari and LikeUsername =:vari2";
            cmd.Parameters.Add("vari", IDimg.Text);
            cmd.Parameters.Add("vari2", NameTxt.Text);
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                likebtn.Text = "♡";
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "insert into likes values (:likeimgid,:likeuserna,:likeo)";

                cmd2.Parameters.Add("likeimgid", IDimg.Text);
                cmd2.Parameters.Add("likeuserna", NameTxt.Text);
                cmd2.Parameters.Add("likeo", "n");
                cmd2.CommandType = CommandType.Text;
                int r = cmd2.ExecuteNonQuery();

                if (r == -1)
                {
                    MessageBox.Show("Error!");
                }

            }
            else
            {

                if (dr[0].Equals("n"))
                {
                    likebtn.Text = "♡";
                }
                else
                {
                    likebtn.Text = "♥";
                }

            }
        }
        bool chechempty = false;
        private bool checkboo(string category)
        {

            CurrentImg = 0;
            CurrentImg2 = 0;
            List<string> UserImgList5 = new List<string>();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select image from images where imgcategory =:catg");
            cmd.Parameters.Add("catg", category);
            cmd.CommandType = CommandType.Text;
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandText = ("Select imgid from images where imgcategory =:catg2");
            cmd2.Parameters.Add("catg2", category);
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr.Read())
            {
                UserImgList5.Add(dr[0].ToString());

            }
            dr.Close();
            if (UserImgList5.Count == 0)
            {
                MessageBox.Show("No Photos available in this Category");
                return false;
            }
            chechempty = true;
            return true;

        }
        private void Load_Category(string category)
        {
            CurrentImg = 0;
            CurrentImg2 = 0;
            UserImgList = new List<string>();
            UserImgList2 = new List<string>();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select image from images where imgcategory =:catg");
            cmd.Parameters.Add("catg", category);
            cmd.CommandType = CommandType.Text;
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandText = ("Select imgid from images where imgcategory =:catg2");
            cmd2.Parameters.Add("catg2", category);
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr.Read())
            {
                UserImgList.Add(dr[0].ToString());

            }
            dr.Close();
            if (UserImgList.Count == 0)
            {
                MessageBox.Show("No Photos available in this Category");
                return;
            }
            pictureBox1.ImageLocation = UserImgList[CurrentImg];


            while (dr2.Read())
            {
                UserImgList2.Add(dr2[0].ToString());

            }
            dr2.Close();
            IDimg.Text = UserImgList2[CurrentImg2];
            selectload();
        }

        private void CategBtn1_Click(object sender, EventArgs e)
        {
            if (checkboo("Dogs"))
            {
                Load_Category("Dogs");
            }

            hideSubMenu();

        }
        private void CategBtn2_Click(object sender, EventArgs e)
        {
            if (checkboo("Cartoon"))
            {
                Load_Category("Cartoon");
            }

            hideSubMenu();

        }
        private void CategBtn3_Click(object sender, EventArgs e)
        {
            if (checkboo("Art"))
            {
                Load_Category("Art");
            }
            hideSubMenu();

        }
        private void CategBtn4_Click(object sender, EventArgs e)
        {
            if (checkboo("Anime"))
            {
                Load_Category("Anime");
            }

            hideSubMenu();

        }
        private void CategBtn5_Click(object sender, EventArgs e)
        {
            if (checkboo("Cats"))
            {
                Load_Category("Cats");
            }
            hideSubMenu();

        }
        private void CategBtn6_Click(object sender, EventArgs e)
        {
            if (checkboo("Food"))
            {
                Load_Category("Food");
            }
            hideSubMenu();

        }
        private void CategBtn7_Click(object sender, EventArgs e)
        {
            if (checkboo("illustrated"))
            {
                Load_Category("illustrated");
            }
            hideSubMenu();

        }
        private void CategBtn8_Click(object sender, EventArgs e)
        {
            if (checkboo("Travel"))
            {
                Load_Category("Travel");
            }
            hideSubMenu();

        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (chechempty)
            {
                CurrentImg++;
                CurrentImg %= UserImgList.Count;
                pictureBox1.ImageLocation = UserImgList[CurrentImg];
                CurrentImg2++;
                CurrentImg2 %= UserImgList2.Count;
                IDimg.Text = UserImgList2[CurrentImg2];
                Comment_txt.Hide();
                Comment.Hide();
                selectload();
            }

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (chechempty)
            {
                CurrentImg--;
                if (CurrentImg < 0)
                {
                    CurrentImg = UserImgList.Count - 1;
                }
                pictureBox1.ImageLocation = UserImgList[CurrentImg];
                CurrentImg2--;
                if (CurrentImg2 < 0)
                {
                    CurrentImg2 = UserImgList2.Count - 1;
                }
                IDimg.Text = UserImgList2[CurrentImg2];
                Comment_txt.Hide();
                Comment.Hide();
                selectload();
            }
        }

        private void CommentsLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Comment_txt.Show();
            Comment.Show();
            Addcomment.Show();
            string constr = "Data Source=orcl; User Id=scott;Password=tiger;";

            string cmdstr = "select imageid,COMMENTS from REVIEWS where ImageId=:n";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", IDimg.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            // Comment.Items.Add ( ds.Tables["Players"]);
            // dataGridView1.DataSource = ds.Tables[0];
            //Comment.Items.Add(ds.Tables[0].Rows[0].Field<string>(0);
            Comment.DataSource = ds.Tables[0];
            Comment.DisplayMember = "Comments";
            //label1.Text = ds.Rows[0]["Comments"].ToString();
            //label1.Text = ds.Tables[0].Rows[0].Field<string>(0);
            //label1.Text = ds.Tables[0].Rows[1].Field<string>(0);
            //label1.Text = ds.Tables[0].Rows[2].Field<string>(0);
            //Comment.Items.Add(ds.Tables[0]);







        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Addcomment_Click(object sender, EventArgs e)
        {


            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
            ds.Tables[0].Rows.Add(IDimg.Text, Comment_txt.Text);

            adapter.Update(ds.Tables[0]);
        }


        private void likebtn_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Liked from likes where LikeImageId =:vari4 and LikeUsername =:vari5";
            cmd.Parameters.Add("vari4", IDimg.Text);
            cmd.Parameters.Add("vari5", NameTxt.Text);
            cmd.CommandType = CommandType.Text;
            OracleDataReader obm = cmd.ExecuteReader();

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "update likes SET Liked=:likeo where LikeImageId=:likeimgid and likeUsername=:likeuserna";
            if (obm.Read())
            {
                if (obm[0].Equals("n"))
                {
                    cmd2.Parameters.Add("likeo", 'y');
                    likebtn.Text = "♥";

                }
                else
                {
                    cmd2.Parameters.Add("likeo", "n");
                    likebtn.Text = "♡";
                }
            }

            cmd2.Parameters.Add("likeimgid", IDimg.Text);
            cmd2.Parameters.Add("likeuserna", NameTxt.Text);


            int r = cmd2.ExecuteNonQuery();

            if (r != -1)
            {

            }


        }

        private void Uploadbtn_Click(object sender, EventArgs e)
        {
            UploadImg img = new UploadImg();
            img.Show();
        }

        private void Reportbtn_Click(object sender, EventArgs e)
        {
            showSubMenu(ReportPanel);
        }
        
private void Report1_Click(object sender, EventArgs e)
        {
            ViewReport vr = new ViewReport();
            vr.Show();
        }

        private void Report2_Click(object sender, EventArgs e)
        {
            ViewReport2 vr = new ViewReport2();
            vr.Show();
        }
    }
}






