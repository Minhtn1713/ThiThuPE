using Q2.BaseDAO;
using Q2.DataAccess;
using System.ComponentModel;
using System.Web;

namespace Q2
{
    public partial class frmEmpl : Form
    {
        private EmployeeDAO employeeDAO = new EmployeeDAO();

        public frmEmpl()
        {
            InitializeComponent();
        }

        private void frmEmpl_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns["id"].DataPropertyName = "Id";

            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns["name"].DataPropertyName = "Name";

            dataGridView1.Columns.Add("sex", "Sex");
            dataGridView1.Columns["sex"].DataPropertyName = "Sex";

            dataGridView1.Columns.Add("dob", "Dob");
            dataGridView1.Columns["dob"].DataPropertyName = "Dob";
            dataGridView1.Columns["dob"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridView1.Columns.Add("pos", "Position");
            dataGridView1.Columns["pos"].DataPropertyName = "Position";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.DataSource = employeeDAO.GetEmployees();

            cboPosition.DataSource = employeeDAO.GetPositions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            var sex = groupBox2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            DateTime dob = dateDob.Value;
            string position = cboPosition.Text.ToString();
            if (name.Length == 0 && sex.Checked == false && position.Contains(""))
            {
                MessageBox.Show("Enter fields!");
            }
            else
            {
                Employee employee = new Employee
                {
                    Name = name,
                    Sex = sex.Text,
                    Dob = dob,
                    Position = position
                };
                employeeDAO.AddEmployee(employee);
                dataGridView1.DataSource = employeeDAO.GetEmployees();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells[0].Value);
                Employee employee = employeeDAO.GetEmployeeById(id);
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                string sex = employee.Sex;
                if (sex.Equals("Male"))
                {
                    radMale.Checked = true;
                }
                else
                {
                    radFemale.Checked = true;
                }
                dateDob.Text = employee.Dob.ToString();
                cboPosition.SelectedItem = employee.Position;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text.ToString();
            string sex = "";
            if (radMale.Checked)
            {
                sex = radMale.Text.ToString();
            }
            else
            {
                sex = radFemale.Text.ToString();    
            }
            DateTime dob = dateDob.Value;
            string position = cboPosition.Text.ToString();
            Employee employee = employeeDAO.GetEmployeeById(id);
            employee.Name = name;
            employee.Sex = sex;
            employee.Dob = dob;
            employee.Position = position;
            employeeDAO.UpdateEmployee(employee);
            dataGridView1.DataSource = employeeDAO.GetEmployees();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtId.Text = String.Empty;
            txtName.Text = String.Empty;
            foreach (RadioButton radioButton in groupBox2.Controls.OfType<RadioButton>())
            {
                radioButton.Checked = false;
            }
            dateDob.Value = DateTime.Now;
            cboPosition.Text = String.Empty;
        }
    }
}