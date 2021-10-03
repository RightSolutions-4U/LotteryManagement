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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            LotteryManagementEntities dbcontext = new LotteryManagementEntities();
            Int32 price = Convert.ToInt32(txtPrice.Text);
            if (dbcontext.Customers.Where(r => (r.Price == price)).Count() > 0)
            {
                dataGridView1.DataSource = dbcontext.Customers.ToList();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text="No Records found for this price";
            }
        }
    }
}
