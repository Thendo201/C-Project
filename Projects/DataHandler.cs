using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;

namespace Projects
{
    internal class DataHandler
    {
        //string conn = $"Data Source=DESKTOP-TVQQ8OC;Initial Catalog=StudentInformation;Integrated Security=True";
        string conn = @"Data Source=LAPTOP-ACDKIHL9\SQLEXPRESS02;Initial Catalog=StudentInformation;Integrated Security=True";

        public DataTable Display()
        {
            //Code to Display data onto a datagridview
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter("Display", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void AddStudent(string name, string surname, DateTime dateOfbirth, string gender, int phone, string address, byte[] image)
        {
            try
            {
                //Adding a student to the database
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("AddStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", name);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    cmd.Parameters.AddWithValue("@StudentImage", image);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfbirth);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Address", address);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Added");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        public void UpdateStudent(int id, string name, string surname, DateTime dateOfbirth, string gender, int phone, string address, byte[] image)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("UpdateStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@FirstName", name);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    cmd.Parameters.AddWithValue("@StudentImage", image);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfbirth);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                    cmd.Parameters.AddWithValue("@Address", address);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Updated");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("DeleteStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Deleted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public DataTable SearchStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SearchStudent", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }
        public DataTable displayCourses()
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter("spDisplayCourse", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);   
            return dt;
        }
    }
}
