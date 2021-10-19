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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.Width / 2) - 500;
            FillcmbDealer(sender, e);
            displayData(sender, e);
        }

        private void FillcmbDealer(object sender, EventArgs e)
        {
            cmbDealer.DataSource = null;
            LotteryManagementEntities dbcontext = new LotteryManagementEntities();
            var Dealers = (from c in dbcontext.Dealers
                             select new { c.DealerId, c.DealerName}).Distinct().ToList();

            cmbDealer.DataSource = Dealers;
            cmbDealer.ValueMember = "DealerId";
            cmbDealer.DisplayMember = "DealerName";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtLotteryNo.Text = "";
            txtPrice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtLotteryNo.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please enter all values");
            }
            else
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Customer dl = new Customer();
                dl.CustomerName = txtCustomerName.Text;
                dl.LotteryNo = txtLotteryNo.Text;
                dl.Price = Convert.ToInt32(txtPrice.Text);
                dl.DealerId = Convert.ToInt32(cmbDealer.SelectedValue);
                dbcontext.Customers.Add(dl);
                dbcontext.SaveChanges();
                displayData(sender, e);
            }
        }
        private void displayData(object sender, EventArgs e)
        {

            LotteryManagementEntities dbcontext = new LotteryManagementEntities();
            dataGridView1.DataSource = dbcontext.Customers.ToList();
            
            int numRows = dataGridView1.Rows.Count;

            txtCount.Text = numRows.ToString();

            int sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)

            {

                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);

            }

            txtTotal.Text = sum.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtLotteryNo.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("All values should be there");
            }
            else
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Int32 DId = Convert.ToInt32(cmbDealer.SelectedValue);
                Int32 CId = Convert.ToInt32(txtCustomerId.Text);
                var Customer = dbcontext.Customers.First(a => a.DealerId == DId && a.CustomerId == CId);
                Customer.CustomerName = txtCustomerName.Text;
                Customer.LotteryNo = txtLotteryNo.Text;
                Customer.Price = Convert.ToInt32(txtPrice.Text);
                dbcontext.SaveChanges();
                displayData(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "" || txtLotteryNo.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("All values should be there");
            }
            else
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Int32 DId = Convert.ToInt32(cmbDealer.SelectedValue);
                Int32 CId = Convert.ToInt32(txtCustomerId.Text);
                dbcontext.Customers.Remove(dbcontext.Customers.Single(a => a.DealerId == DId && a.CustomerId == CId));
                dbcontext.SaveChanges();
                displayData(sender, e);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtCustomerId.Text = row.Cells[0].Value.ToString();
                txtCustomerName.Text = row.Cells[1].Value.ToString();
                txtLotteryNo.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
