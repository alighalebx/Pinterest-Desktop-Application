using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinterest
{
    public partial class ViewReport2 : Form
    {
        PinterestReport2 CR;
        public ViewReport2()
        {
            InitializeComponent();
        }
        private void ViewReport2_Load(object sender, EventArgs e)
        {
            CR = new PinterestReport2();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Categorybtn_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }
    }
}
