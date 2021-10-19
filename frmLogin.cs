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


namespace LotteryManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            User usr = new User();
            LotteryManagementEntities dbcontext = new LotteryManagementEntities();

            if ( dbcontext.Users.Where(r=>(r.UserName==txtUserName.Text) && r.Pwd == txtPassword.Text).Count()>0)
            {
                this.Hide();
                lblError.Visible = true;
                lblError.Text = "Login";
                frmMain dlr = new frmMain();
                dlr.Show();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Wrong User Name or Password";
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.Width / 2) - 250;
        }
    }

}
