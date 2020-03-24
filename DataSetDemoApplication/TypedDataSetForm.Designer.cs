namespace DataSetDemoApplication
{
    partial class TypedDataSetForm
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
            this.organisationDataSet1 = new DataSetDemoApplication.OrganisationDataSet();
            this.departmentTableAdapter1 = new DataSetDemoApplication.OrganisationDataSetTableAdapters.DepartmentTableAdapter();
            this.employeeTableAdapter1 = new DataSetDemoApplication.OrganisationDataSetTableAdapters.EmployeeTableAdapter();
            this.btnGetAllEmployees = new System.Windows.Forms.Button();
            this.btnAddNewEmployee = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.empIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.versionDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.photoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.organisationDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // organisationDataSet1
            // 
            this.organisationDataSet1.DataSetName = "OrganisationDataSet";
            this.organisationDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentTableAdapter1
            // 
            this.departmentTableAdapter1.ClearBeforeFill = true;
            // 
            // employeeTableAdapter1
            // 
            this.employeeTableAdapter1.ClearBeforeFill = true;
            // 
            // btnGetAllEmployees
            // 
            this.btnGetAllEmployees.Location = new System.Drawing.Point(12, 12);
            this.btnGetAllEmployees.Name = "btnGetAllEmployees";
            this.btnGetAllEmployees.Size = new System.Drawing.Size(112, 23);
            this.btnGetAllEmployees.TabIndex = 0;
            this.btnGetAllEmployees.Text = "Get All Employees";
            this.btnGetAllEmployees.UseVisualStyleBackColor = true;
            this.btnGetAllEmployees.Click += new System.EventHandler(this.btnGetAllEmployees_Click);
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.Location = new System.Drawing.Point(12, 41);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(112, 23);
            this.btnAddNewEmployee.TabIndex = 1;
            this.btnAddNewEmployee.Text = "Add New Employee";
            this.btnAddNewEmployee.UseVisualStyleBackColor = true;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empIdDataGridViewTextBoxColumn,
            this.deptIdDataGridViewTextBoxColumn,
            this.empNameDataGridViewTextBoxColumn,
            this.salaryDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.versionDataGridViewImageColumn,
            this.photoDataGridViewImageColumn});
            this.dataGridView1.DataMember = "Employee";
            this.dataGridView1.DataSource = this.organisationDataSet1;
            this.dataGridView1.Location = new System.Drawing.Point(130, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(751, 427);
            this.dataGridView1.TabIndex = 2;
            // 
            // empIdDataGridViewTextBoxColumn
            // 
            this.empIdDataGridViewTextBoxColumn.DataPropertyName = "EmpId";
            this.empIdDataGridViewTextBoxColumn.HeaderText = "EmpId";
            this.empIdDataGridViewTextBoxColumn.Name = "empIdDataGridViewTextBoxColumn";
            this.empIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deptIdDataGridViewTextBoxColumn
            // 
            this.deptIdDataGridViewTextBoxColumn.DataPropertyName = "DeptId";
            this.deptIdDataGridViewTextBoxColumn.HeaderText = "DeptId";
            this.deptIdDataGridViewTextBoxColumn.Name = "deptIdDataGridViewTextBoxColumn";
            // 
            // empNameDataGridViewTextBoxColumn
            // 
            this.empNameDataGridViewTextBoxColumn.DataPropertyName = "EmpName";
            this.empNameDataGridViewTextBoxColumn.HeaderText = "EmpName";
            this.empNameDataGridViewTextBoxColumn.Name = "empNameDataGridViewTextBoxColumn";
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            this.salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            // 
            // versionDataGridViewImageColumn
            // 
            this.versionDataGridViewImageColumn.DataPropertyName = "Version";
            this.versionDataGridViewImageColumn.HeaderText = "Version";
            this.versionDataGridViewImageColumn.Name = "versionDataGridViewImageColumn";
            this.versionDataGridViewImageColumn.ReadOnly = true;
            // 
            // photoDataGridViewImageColumn
            // 
            this.photoDataGridViewImageColumn.DataPropertyName = "Photo";
            this.photoDataGridViewImageColumn.HeaderText = "Photo";
            this.photoDataGridViewImageColumn.Name = "photoDataGridViewImageColumn";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.organisationDataSet1;
            this.comboBox1.DisplayMember = "Department.DeptName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(130, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "Department.PKDeptId";
            // 
            // TypedDataSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 502);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddNewEmployee);
            this.Controls.Add(this.btnGetAllEmployees);
            this.Name = "TypedDataSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typed DataSet Form";
            this.Load += new System.EventHandler(this.TypedDataSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.organisationDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OrganisationDataSet organisationDataSet1;
        private OrganisationDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter1;
        private OrganisationDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter1;
        private System.Windows.Forms.Button btnGetAllEmployees;
        private System.Windows.Forms.Button btnAddNewEmployee;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn versionDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn photoDataGridViewImageColumn;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}