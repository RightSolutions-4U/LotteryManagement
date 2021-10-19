using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            /*            string strurl = "http://localhost:8001/add_Number/";
                        WebRequest requestobject = WebRequest.Create(strurl);
                        requestobject.Method = "POST";
                        requestobject.ContentType = "application/json";
                        string postData = "{\"number\":\"9000\"}";
                        using (var streamwriter = new StreamWriter(requestobject.GetRequestStream()))
                        {
                            streamwriter.Write(postData);
                            streamwriter.Flush();
                            streamwriter.Close();
                        }
                        var httpResponse = (HttpWebResponse)requestobject.GetResponse();
                        using (var streamreader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamreader.ReadToEnd();
                        }
            */
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://tsampleb.herokuapp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("add_Number/"+ Convert.ToInt64(textBox1.Text));
                HttpResponseMessage response2 = await client.GetAsync("add_Number/" + Convert.ToInt64(textBox2.Text));
                HttpResponseMessage response3 = await client.GetAsync("add_Number/" + Convert.ToInt64(textBox3.Text));
                HttpResponseMessage response4 = await client.GetAsync("add_Number/" + Convert.ToInt64(textBox4.Text));
                if (response.IsSuccessStatusCode)
                {
                    lblmessage.Text =  "Numbers sent successfuly";
                }
                else
                {
                    lblmessage.Text = "Internal server Error";
                }
            }


        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.Width / 2) - 250;
            panel2.Left = (this.Width / 2) - 250;
        }
    }
}
