using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Projects
{
    internal class CourseDataHandler
    {
        static string ConnString = @"Data Source=LAPTOP-ACDKIHL9\SQLEXPRESS02;Initial Catalog=StudentInformation;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        public DataTable Course = new DataTable();
        SqlCommand cmd;

        public void displayCourse()
        {
            conn = new SqlConnection(ConnString);
            SqlDataAdapter adapter = new SqlDataAdapter("spDisplayCourse", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(Course);
        }
        public void insertCourse(string code, string name, string descption, string link)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand cmd = new SqlCommand("spAddModules", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", descption);
                    cmd.Parameters.AddWithValue("@Link", link);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully added");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void deleteCourse(string code)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteModules", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", code);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Deleted");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void updateCourse(string code, string name, string description, string link)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateModules", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Link", link);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully updated");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void displayinCheckedList(CheckedListBox checkedListBox1)
        {
            string constr = @"Data Source=LAPTOP-ACDKIHL9\SQLEXPRESS02;Initial Catalog=StudentInformation;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT ModuleCode, ModuleName FROM Modules", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //Assign DataTable as DataSource.
                    checkedListBox1.DataSource = dt;
                    checkedListBox1.DisplayMember = "ModuleName";
                    checkedListBox1.ValueMember = "ModuleCode";
                }
            }
        }
        public void addStudentModules(int stNumber, string MdCode, string name)
        {
            try
            {
                //Adding modules to the database
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand cmd = new SqlCommand("spAddStudentModules", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Number", stNumber);
                    cmd.Parameters.AddWithValue("@Code", MdCode);
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public void deleteStudentModules(int id)
        {
            try
            {
                //Deleting Modules from the database
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteStudentModules", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Student Modules also Successfully Deleted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void searchCourse(DataGridView dataGridView1, string searchValue)
        {
            //Code to search the datagridview for a specif module code
            conn = new SqlConnection(ConnString);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Modules where [ModuleCode] like '" + searchValue + "%'", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        } 
        
    }
}
