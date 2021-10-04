using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
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

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            displayData(sender, e);
        }

        private void displayData(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            if (txtLotteryNo.Text != "")
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                dataGridView1.DataSource = dbcontext.Customers.Where(r => (r.LotteryNo.Contains(txtLotteryNo.Text))).ToList();
            }

            int numRows = dataGridView1.Rows.Count;

            txtCount.Text = numRows.ToString();

            int sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }

            txtTotal.Text = sum.ToString();

        }
    }
}
