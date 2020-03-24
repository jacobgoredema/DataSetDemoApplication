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
    public partial class TypedDataSetForm : Form
    {
        public TypedDataSetForm()
        {
            InitializeComponent();
        }

        private void btnGetAllEmployees_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            OrganisationDataSet.EmployeeDataTable dtEmp = employeeTableAdapter1.GetData();
            foreach (OrganisationDataSet.EmployeeRow drEmp in dtEmp.Rows)
            {
                str += drEmp.EmpId + "\t" + drEmp.Salary + "\n";
                
            }

            MessageBox.Show(str);
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            OrganisationDataSet ds = new OrganisationDataSet();
            departmentTableAdapter1.Fill(ds.Department);
            employeeTableAdapter1.Fill(ds.Employee);

            string str = string.Empty;

            foreach (OrganisationDataSet.EmployeeRow drEmp in ds.Employee.Rows)
            {
                str += drEmp.EmpId + "\t" + drEmp.EmpName + "\t" + drEmp.Salary + "\n";
            }

            MessageBox.Show(str);

            OrganisationDataSet.EmployeeRow dr = ds.Employee.NewEmployeeRow();
            dr.EmpName = "Jat";
            dr.Salary = 2300;
            dr.DeptId = 1;
            ds.Employee.AddEmployeeRow(dr);
            employeeTableAdapter1.Update(ds);
        }

        private void TypedDataSetForm_Load(object sender, EventArgs e)
        {
            departmentTableAdapter1.Fill(organisationDataSet1.Department);
            employeeTableAdapter1.Fill(organisationDataSet1.Employee);
        }
    }
}
