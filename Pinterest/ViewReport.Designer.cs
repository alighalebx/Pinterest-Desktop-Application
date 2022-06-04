
namespace Pinterest
{
    partial class ViewReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Categorybtn = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.UsercomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Categorybtn
            // 
            this.Categorybtn.BackColor = System.Drawing.Color.Transparent;
            this.Categorybtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Categorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.Categorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Categorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Categorybtn.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categorybtn.ForeColor = System.Drawing.Color.White;
            this.Categorybtn.Location = new System.Drawing.Point(327, 77);
            this.Categorybtn.Name = "Categorybtn";
            this.Categorybtn.Size = new System.Drawing.Size(161, 38);
            this.Categorybtn.TabIndex = 48;
            this.Categorybtn.Text = "Generate Report";
            this.Categorybtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Categorybtn.UseVisualStyleBackColor = false;
            this.Categorybtn.Click += new System.EventHandler(this.Categorybtn_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 135);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(776, 453);
            this.crystalReportViewer1.TabIndex = 49;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(771, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 28);
            this.button1.TabIndex = 50;
            this.button1.Text = "✕";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UsercomboBox
            // 
            this.UsercomboBox.FormattingEnabled = true;
            this.UsercomboBox.Location = new System.Drawing.Point(105, 12);
            this.UsercomboBox.Name = "UsercomboBox";
            this.UsercomboBox.Size = new System.Drawing.Size(174, 21);
            this.UsercomboBox.TabIndex = 51;
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(100)))), ((int)(((byte)(121)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.UsercomboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.Categorybtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewReport";
            this.Text = "ViewReport";
            this.Load += new System.EventHandler(this.ViewReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Categorybtn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox UsercomboBox;
    }
}