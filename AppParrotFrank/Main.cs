using Newtonsoft.Json;
using ParrotFrankEntities;
using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppParrotFrank
{
    public partial class Main : Form
    {
        private HttpResponseMessage responseResult;
        public Main()
        {
            InitializeComponent();
            this.lblUser.Text = lblUser.Text.Replace("@User", GlobalUser.CurrentUser.Nick);
            this.lblTitle.Text = $"{GlobalUser.CurrentUser.Nick} Store";
            this.lblToken.Text = lblToken.Text.Replace("@Time", SessionTime(DateTime.Now, (DateTime)GlobalUser.CurrentUser.RefreshTime).ToString());

        }

        public double SessionTime(DateTime init, DateTime end)
        {
            TimeSpan ts = end - init;
            return Math.Round(ts.TotalMinutes);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadProducts();            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void LoadProducts()
        {
            await Task.Run(() => {
                return GetProducts();
            }).ContinueWith(x => {
                responseResult = x.Result;
            });
            if (responseResult != null)
            {
                var result = JsonConvert.DeserializeObject<List<Categories>>(responseResult.Content.ReadAsStringAsync().Result);
                if(result != null)
                {
                    foreach (var product in result)
                    {
                        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250F));
                        tableLayoutPanel2.RowCount = tableLayoutPanel2.RowCount + 1;
                        tableLayoutPanel2.Controls.Add(new Collapse(product), 1, tableLayoutPanel2.RowCount);
                    }
                    tableLayoutPanel2.MaximumSize = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
                    panel1.VerticalScroll.Visible = true;
                }                
            }
        }

        private async Task<HttpResponseMessage> GetProducts()
        {
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + "api/Categories";
            try
            {
                return await new ParrotFrankHelpers.APIConsume().APICall(HttpMethod.Get, url, null, GlobalUser.CurrentUser.Token);
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return null;
        }
    }
}
