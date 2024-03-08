using Q1.DAL;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            cboPosition.Text = "All positions";
                        
            dataGridView1.DataSource = DBContext.Instance.GetEmployees();
            dataGridView1.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.AutoResizeColumns();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            if (name.Length == 0)
            {
                Load();
            }
            else
            {
                dataGridView1.DataSource = DBContext.Instance.GetEmployeesByName(name);
            }
        }

        private void radioBtnMF_CheckedChanged(object sender, EventArgs e)
        {
            txtName_TextChanged(sender, e);
        }

        private void radioBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            string gender = radioBtnMale.Text.ToString();
            dataGridView1.DataSource = DBContext.Instance.GetEmployeesByGender(gender);
        }

        private void radioBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            string gender = radioBtnFemale.Text.ToString();
            dataGridView1.DataSource = DBContext.Instance.GetEmployeesByGender(gender);
        }

        private void cboPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string position = cboPosition.Text.ToString();
            if (position.Equals("All positions"))
            {
                Load();
            }
            else
            {
                dataGridView1.DataSource = DBContext.Instance.GetEmployeesByPOs(position);
            }
        }
    }
}