using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Pinterest
{
    public partial class ViewReport : Form
    {
        PinterestReport CR;
        public ViewReport()
        {
            InitializeComponent();
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            CR = new PinterestReport();
            foreach(ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {
                UsercomboBox.Items.Add(v.Value);
            }
        }

        private void Categorybtn_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, UsercomboBox.Text);
            crystalReportViewer1.ReportSource = CR;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
