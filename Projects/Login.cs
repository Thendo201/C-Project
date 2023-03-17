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
    public partial class Login : Form
    {
        FileHandler fileHandler = new FileHandler();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fileHandler.readFile(tbxUsername.Text, tbxPassword.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you would like to add new user";
            DialogResult dialogResult = MessageBox.Show(message, "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                fileHandler.writeData(tbxUsername.Text, tbxPassword.Text);                
            }
        }
    }
}
