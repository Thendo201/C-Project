using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Projects
{
    internal class FileHandler
    {
        string filePath = @"C:\Users\Thendo Ndhlovu\OneDrive - belgiumcampus.ac.za\Desktop\Programming 282\Projects\Admin.txt.txt";
        public void writeData(string username, string password)
        {
            List<Admin> MyAdminlist = new List<Admin>();
            string admin = $"{username},{password}";

            try
            {
                string fileContents = File.ReadAllText(filePath);
                //checking to see if an inserted user exists or not
                if (fileContents.Contains(username))
                {
                    MessageBox.Show("Username already exists");
                }
                else
                {
                    //if a user doesn't exists it is going to get added to the text file
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(admin);
                            Admin MyAdmin = new Admin(username, password);
                            MyAdminlist.Add(MyAdmin);
                            MessageBox.Show($"Username {username} and Password {password} has been successfully added");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
        }
        public void readFile(string username, string password)
        {
            string[] arrAdmin;
            int FoundCount = 0;
            List<Admin> MyAdminlist = new List<Admin>();
            try
            {
                //code to read all the data in the text file
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        //code to read each line seperately and
                        //then splitting it where there is a comma
                        //then saving the the first two splits into an array then adding that into a list
                        string Line;
                        while ((Line = sr.ReadLine()) != null)
                        {
                            arrAdmin = Line.Split(',');
                            Admin MyAdmin = new Admin(arrAdmin[0], arrAdmin[1]);
                            MyAdminlist.Add(MyAdmin);                  
                        }
                    }
                }
                foreach (var item in MyAdminlist)
                {
                    if ((item.Username == username && item.Password == password))
                    {
                        System.Windows.Forms.MessageBox.Show($"Welcome back {username}");
                        frmHome home = new frmHome();
                        home.Show();
                        FoundCount++;
                    }
                }
                if (FoundCount <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("Incorrect username or password. \n Please try again or register");
                }

            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(error.Message);
            }
        }
    }
}
