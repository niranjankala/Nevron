namespace Nevron.Examples.Chart
{
    partial class frmChartWithSameValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartWithSameValues));
            this.chartControl = new Nevron.Chart.WinForm.NChartControl();
            this.SuspendLayout();
            // 
            // chartControl
            // 
            this.chartControl.AutoRefresh = false;
            this.chartControl.BackColor = System.Drawing.SystemColors.Control;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.InputKeys = new System.Windows.Forms.Keys[0];
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(566, 395);
            this.chartControl.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("chartControl.State")));
            this.chartControl.TabIndex = 0;
            this.chartControl.Text = "nChartControl1";
            // 
            // frmChartWithSameValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 395);
            this.Controls.Add(this.chartControl);
            this.Name = "frmChartWithSameValues";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.Chart.WinForm.NChartControl chartControl;

    }
}

