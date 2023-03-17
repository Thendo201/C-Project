using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projects
{
    public partial class frmViewStudents : Form
    {
        DataHandler handler = new DataHandler();
        CourseDataHandler courseDataHandler = new CourseDataHandler();
        BindingSource bs = new BindingSource(); 
        public frmViewStudents()
        {
            InitializeComponent();
        }
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            this.Close();
            frmHome.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg);*.jpg|*.jpeg", Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pbPic.Image = Image.FromFile(ofd.FileName);
                        pbPic.Text = ofd.FileName;
                        handler.AddStudent(tbxName.Text, tbxSurname.Text, DateTime.Parse(tbxDOB.Text), tbxGender.Text, int.Parse(tbxPhone.Text), tbxAddress.Text, handler.ConvertImageToBytes(pbPic.Image));


                        foreach (object item in checkedListBox1.CheckedItems)
                        {
                            DataRowView row = item as DataRowView;

                            string Code = row["ModuleCode"].ToString();
                            string Name = row["ModuleName"].ToString();

                            courseDataHandler.addStudentModules(int.Parse(tbxNumber.Text), Code, Name);                      
                        }


                        MessageBox.Show("Student Modules successfully added");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg);*.jpg|*.jpeg", Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pbPic.Image = Image.FromFile(ofd.FileName);
                        pbPic.Text = ofd.FileName;
                        handler.UpdateStudent(int.Parse(tbxNumber.Text), tbxName.Text, tbxSurname.Text, DateTime.Parse(tbxDOB.Text), tbxGender.Text, int.Parse(tbxPhone.Text), tbxAddress.Text, handler.ConvertImageToBytes(pbPic.Image));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmViewStudents_Load(object sender, EventArgs e)
        {
            courseDataHandler.displayinCheckedList(checkedListBox1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                courseDataHandler.deleteStudentModules(int.Parse(tbxNumber.Text));
                handler.DeleteStudent(int.Parse(tbxNumber.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
