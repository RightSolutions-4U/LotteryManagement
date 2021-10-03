using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            /*this.Hide();*/
            frmDealer dlr = new frmDealer();
            dlr.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            /*this.Hide();*/
            FrmCustomer dlr = new FrmCustomer();
            dlr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSearch dlr = new frmSearch();
            dlr.Show();
        }
    }
}
