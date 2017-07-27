using Nevron.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nevron.Examples.Chart
{
    public partial class frmChartWithSameValues : Form
    {
        public frmChartWithSameValues()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartData data = new ChartData();
           DataTable datat = data.GetDataTable(Application.StartupPath + "\\App_Data\\exported data.xml");
           //(chartControl.Charts[0].Series[0] as NSmoothLineSeries).UseXValues = true;
            chartControl.DataBindingManager.AddBinding(0,0, "XValues", datat, "TimeStamp");            
            chartControl.DataBindingManager.AddBinding(0, 0, "Values", datat, "Temperature");

        }
    }
}
