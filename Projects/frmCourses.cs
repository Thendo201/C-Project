using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public partial class frmCourses : Form
    {
        CourseDataHandler handler = new CourseDataHandler();
        BindingSource bs = new BindingSource(); 
        public frmCourses()
        {
            InitializeComponent();
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            handler.displayCourse();
            bs.DataSource = handler.Course;
            dataGridView1.DataSource = bs;
        }
        public void refreshDataTable()
        {
            handler.Course.Clear();
            handler.displayCourse();
            bs.DataSource = handler.Course;
        }
        private void gbPersonalInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCode = tbxCode.Text;
                string selectedName = tbxName.Text;

                string message = $"Are you sure you would like to delete this course \nCourse: {selectedCode} Course Name: {selectedName}";
                DialogResult dialogResult = MessageBox.Show(message, "Add Course", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    handler.insertCourse(tbxCode.Text, tbxName.Text, tbxDescription.Text, tbxLink.Text);
                    refreshDataTable();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCode = tbxCode.Text;
                string selectedName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                string message = $"Are you sure you would like to delete this course \nCourse: {selectedCode} Course Name: {selectedName}";
                DialogResult dialogResult = MessageBox.Show(message, "Delete Course", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    handler.deleteCourse(tbxCode.Text);
                    refreshDataTable();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string selectedName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                string message = $"Are you sure you would like to update this course \nCourse: {selectedCode} Course Name: {selectedName}";
                DialogResult dialogResult = MessageBox.Show(message, "Update Course", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    handler.updateCourse(tbxCode.Text, tbxName.Text, tbxDescription.Text, tbxLink.Text);
                    refreshDataTable();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                handler.searchCourse(dataGridView1, tbxSearch.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbxCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tbxName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbxDescription.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tbxLink.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string url = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                Process.Start(url);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            this.Close();
            frmHome.Show();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            handler.searchCourse(dataGridView1, tbxSearch.Text);
        }
    }
}
