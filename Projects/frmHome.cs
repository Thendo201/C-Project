using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public partial class frmHome : Form
    {
        DataHandler handler = new DataHandler();
        BindingSource bindingSource = new BindingSource();
        public frmHome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = handler.Display();
            dataGridView1.DataSource = bindingSource;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = handler.SearchStudent(int.Parse(tbxSearch.Text));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            frmViewStudents view = new frmViewStudents();
            this.Hide();
            view.Show();
        }

        private void btnViewCourse_Click(object sender, EventArgs e)
        {
            frmCourses View = new frmCourses();
            this.Close();
            View.Show();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
        }
    }
}
