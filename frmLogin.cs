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
                lblError.Visible = true;
                lblError.Text = "Login";
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Wrong User Name or Password";
            }

        }

    }

}
