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
    public partial class frmDealer : Form
    {
        public frmDealer()
        {
            InitializeComponent();
        }

        private void frmDealer_Load(object sender, EventArgs e)
        {
            /*LotteryManagementEntities dbcontext = new LotteryManagementEntities();
            dataGridView1.DataSource = dbcontext.Dealers;*/
            displayData(sender, e);
        }

        private void displayData(object sender, EventArgs e)
        {

            LotteryManagementEntities dbcontext = new LotteryManagementEntities();
            dataGridView1.DataSource = dbcontext.Dealers.ToList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDealerName.Text = "";
            txtCellNo.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtDealerName.Text=="" || txtCellNo.Text=="")
            {
                MessageBox.Show("Please enter both values");
            }
            else
            { 
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Dealer dl = new Dealer();
                dl.DealerName = txtDealerName.Text;
                dl.DealerCellNo = txtCellNo.Text;
                dbcontext.Dealers.Add(dl);
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
                txtDealerId.Text = row.Cells[0].Value.ToString();
                txtDealerName.Text = row.Cells[1].Value.ToString();
                txtCellNo.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDealerName.Text == "" || txtCellNo.Text == "")
            {
                MessageBox.Show("Both values should be there");
            }
            else
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Int32 DId = Convert.ToInt32(txtDealerId.Text);
                var Dealer = dbcontext.Dealers.First(a => a.DealerId == DId);
                Dealer.DealerName = txtDealerName.Text;
                Dealer.DealerCellNo = txtCellNo.Text;
                dbcontext.SaveChanges();
                displayData(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDealerName.Text == "" || txtCellNo.Text == "")
            {
                MessageBox.Show("Both values should be there");
            }
            else
            {
                LotteryManagementEntities dbcontext = new LotteryManagementEntities();
                Int32 DId = Convert.ToInt32(txtDealerId.Text);
                dbcontext.Dealers.Remove(dbcontext.Dealers.Single(a => a.DealerId == DId));
                dbcontext.SaveChanges();
                displayData(sender, e);
            }
        }
    }
}
