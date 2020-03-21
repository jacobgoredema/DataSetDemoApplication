using DataSetDemoApplication.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetDemoApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet dataSet;
        DataTable dtEmp;
        SqlDataAdapter daEmp;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            daEmp = new SqlDataAdapter("SELECT EmpId,EmpName,Salary FROM Employee", DatabaseHelper.ConnectionString);
            daEmp.Fill(dataSet, "Employee");
            dtEmp = dataSet.Tables["Employee"];
            dgvEmployees.DataSource = dtEmp;

            //load Ids into the combobox
            foreach(DataRow dr in dtEmp.Rows)
            {
                cboEmpId.Items.Add(dr["EmpId"].ToString());
            }

            SqlCommand cmdInsert, cmdUpdate, cmdDelete;
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);

            //Insert
            cmdInsert = new SqlCommand("Insert into Employee(Empname,Salary)VALUES(@name,@salary)", connection);
            SqlParameter ParameterName = cmdInsert.Parameters.Add("@name", SqlDbType.VarChar, 50);
            SqlParameter parameterSalary = cmdInsert.Parameters.Add("@salary", SqlDbType.Money);
            ParameterName.SourceColumn = "EmpName";
            parameterSalary.SourceColumn = "Salary";

            //Update
            cmdUpdate = new SqlCommand("UPDATE Employee SET EmpName=@name,Salary=@salary where EmpId=@id", connection);
            SqlParameter updateName = cmdUpdate.Parameters.Add("@name", SqlDbType.VarChar, 50);
            SqlParameter updateSalary = cmdUpdate.Parameters.Add("@salary", SqlDbType.Money);
            SqlParameter parameterId = cmdUpdate.Parameters.Add("@Id", SqlDbType.Int);
            updateName.SourceColumn = "empName";
            updateSalary.SourceColumn = "Salary";
            parameterId.SourceColumn = "EmpId";
            parameterId.SourceVersion = DataRowVersion.Original;

            //Delete
            cmdDelete = new SqlCommand("DELETE FROM Employee WHERE EmpId=@Id", connection);
            SqlParameter deleteId = cmdDelete.Parameters.Add("@Id", SqlDbType.Int);
            deleteId.SourceColumn = "EmpId";
            deleteId.SourceVersion = DataRowVersion.Original;

            daEmp.InsertCommand = cmdInsert;
            daEmp.UpdateCommand = cmdUpdate;
            daEmp.DeleteCommand = cmdDelete;
        }

        private void cboEmpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow drSelected;
            drSelected = dtEmp.Rows[cboEmpId.SelectedIndex];
            txtName.Text = drSelected["EmpName"].ToString();

            if (drSelected.IsNull("Salary"))
                txtSalary.Text = "0";
            else
                txtSalary.Text = drSelected["Salary"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            daEmp.Update(dtEmp);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dtEmp.NewRow();
            //dataRow.RowState.
            dataRow["EmpName"] = txtName.Text;
            dataRow["Salary"] = txtName.Text;
            dtEmp.Rows.Add(dataRow);
            dgvEmployees.Refresh();
            daEmp.Update(dtEmp);
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            DataRow drSelected;
            drSelected = dtEmp.Rows[cboEmpId.SelectedIndex];
            drSelected["EmpName"] = txtName.Text;
            drSelected["Salary"] = txtSalary.Text;
            daEmp.Update(dtEmp);
            dgvEmployees.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow drSelected;
            drSelected = dtEmp.Rows[cboEmpId.SelectedIndex];
            drSelected.Delete();
            daEmp.Update(dtEmp);
            dgvEmployees.Refresh();
        }
    }
}
