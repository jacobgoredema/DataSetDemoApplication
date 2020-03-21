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

            //fetch id from the database once inserted
            daEmp.RowUpdated += DaEmp_RowUpdated;
            daEmp.RowUpdating += DaEmp_RowUpdating;
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
            //cmdInsert = new SqlCommand("Insert into Employee(Empname,Salary)VALUES(@name,@salary); SELECT @Id=@@Identity", connection);
            cmdInsert = new SqlCommand("Insert into Employee(Empname,Salary)VALUES(@name,@salary)", connection);
        
            SqlParameter ParameterName = cmdInsert.Parameters.Add("@name", SqlDbType.VarChar, 50);
            SqlParameter parameterSalary = cmdInsert.Parameters.Add("@salary", SqlDbType.Money);
            //SqlParameter parameterId = cmdInsert.Parameters.Add("@Id", SqlDbType.Int);
            ParameterName.SourceColumn = "EmpName";
            parameterSalary.SourceColumn = "Salary";
            //parameterId.SourceColumn = "EmpId";
            //parameterId.SourceVersion = DataRowVersion.Current;
            //parameterId.Direction = ParameterDirection.Output;

            //Update
            cmdUpdate = new SqlCommand("UPDATE Employee SET EmpName=@name,Salary=@salary where EmpId=@id", connection);
            SqlParameter updateName = cmdUpdate.Parameters.Add("@name", SqlDbType.VarChar, 50);
            SqlParameter updateSalary = cmdUpdate.Parameters.Add("@salary", SqlDbType.Money);
            SqlParameter parameterIds = cmdUpdate.Parameters.Add("@Id", SqlDbType.Int);
            updateName.SourceColumn = "empName";
            updateSalary.SourceColumn = "Salary";
            parameterIds.SourceColumn = "EmpId";
            parameterIds.SourceVersion = DataRowVersion.Original;

            //Delete
            cmdDelete = new SqlCommand("DELETE FROM Employee WHERE EmpId=@Id", connection);
            SqlParameter deleteId = cmdDelete.Parameters.Add("@Id", SqlDbType.Int);
            deleteId.SourceColumn = "EmpId";
            deleteId.SourceVersion = DataRowVersion.Original;

            daEmp.InsertCommand = cmdInsert;
            daEmp.UpdateCommand = cmdUpdate;
            daEmp.DeleteCommand = cmdDelete;
        }

        private void DaEmp_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            // validate if new salary is greater than 1000
            if(e.StatementType==StatementType.Update)
            {
                decimal newSalary = Convert.ToDecimal(e.Row["Salary", DataRowVersion.Current]);
                decimal oldSalary = Convert.ToDecimal(e.Row["Salary", DataRowVersion.Original]);
                if (newSalary-oldSalary>1000)
                {
                    e.Status = UpdateStatus.SkipCurrentRow;
                    MessageBox.Show("Validation failed...");
                    e.Row.RejectChanges();
                }
            }
        }

        private void DaEmp_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if(e.StatementType==StatementType.Insert)
            {
                SqlCommand command = new SqlCommand("SELECT @@Identity", e.Command.Connection);
                e.Row["EmpId"]=command.ExecuteScalar();
                cboEmpId.Items.Add(e.Row["EmpId"]);
            }
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
            dataRow["Salary"] = txtSalary.Text;
            dtEmp.Rows.Add(dataRow);
            daEmp.Update(dtEmp);
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            DataRow drSelected;
            drSelected = dtEmp.Rows[cboEmpId.SelectedIndex];
            drSelected["EmpName"] = txtName.Text;
            drSelected["Salary"] = txtSalary.Text;
            daEmp.Update(dtEmp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow drSelected;
            drSelected = dtEmp.Rows[cboEmpId.SelectedIndex];
            drSelected.Delete();
            daEmp.Update(dtEmp);
        }
    }
}
