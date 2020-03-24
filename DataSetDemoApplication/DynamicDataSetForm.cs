using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetDemoApplication
{
    public partial class DynamicDataSetForm : Form
    {
        DataSet ds;

        public DynamicDataSetForm()
        {
            InitializeComponent();
        }

        private void DynamicDataSetForm_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataTable dt = new DataTable("Table");
            DataColumn dcNumber = new DataColumn("Number");
            dcNumber.DataType = typeof(int);
            DataColumn dcStar = new DataColumn("*");
            DataColumn dcCounter = new DataColumn("Counter");
            DataColumn dcEqual = new DataColumn("=");
            DataColumn dcValue = new DataColumn("Value");

            dcStar.DefaultValue = "*";
            dcEqual.DefaultValue = "=";
            dcValue.Expression = "Number * Counter";
            dcCounter.AutoIncrement = true;
            dcCounter.AutoIncrementSeed = 1;
            dcCounter.AutoIncrementStep = 1;

            dt.Columns.Add(dcNumber);
            dt.Columns.Add(dcStar);
            dt.Columns.Add(dcCounter);
            dt.Columns.Add(dcEqual);
            dt.Columns.Add(dcValue);

            ds.Tables.Add(dt);
            dgvEmployees.DataSource = ds.Tables[0];

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Number"] = 10;
                dt.Rows.Add(dr);
            }
        }
    }
}
