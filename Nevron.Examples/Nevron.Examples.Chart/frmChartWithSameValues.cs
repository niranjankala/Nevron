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
            DataTable seriesDataTable = data.GetDataTable(Application.StartupPath + "\\App_Data\\data.xml");

            //chartControl.DataBindingManager.AddBinding(0,0, "XValues", datat, "TimeStamp");
            NSmoothLineSeries series = chartControl.Charts[0].Series[0] as NSmoothLineSeries;
            series.InflateMargins = true;
            series.UseXValues = true;
            foreach (DataRow row in seriesDataTable.Rows)
            {
                series.XValues.Add(Convert.ToDateTime(row["TimeStamp"]));
            }
            chartControl.DataBindingManager.AddBinding(0, 0, "Values", seriesDataTable, "Temperature");

            NDateTimeScaleConfigurator dateTimeScale = chartControl.Charts[0].Axis(StandardAxis.PrimaryX).ScaleConfigurator as NDateTimeScaleConfigurator;
            dateTimeScale.DateTimeUnitFormatterPairs.MonthFormatter.FormatSpecifier = "MMM";
            dateTimeScale.DateTimeUnitFormatterPairs.DayFormatter.FormatSpecifier = "MMM d";
            dateTimeScale.DateTimeUnitFormatterPairs.HourFormatter.FormatSpecifier = "MMM d HH:mm";
            //Avoid added next or previous year date label by disabling round to tick max or min
            dateTimeScale.EnableUnitSensitiveFormatting = true;
            dateTimeScale.RoundToTickMax = false;
            dateTimeScale.RoundToTickMin = false;


        }
    }
}
