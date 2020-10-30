using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ParrotFrankEntities.parrot_frank;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using ParrotFrankEntities;
using System.Net;
using Newtonsoft.Json;

namespace AppParrotFrank
{
    public partial class Collapse : UserControl
    {
        private bool Expanded = false;
        private HttpResponseMessage responseResult;
        private const int ExpansionPerTick = 7;
        public Collapse(Categories product)
        {
            InitializeComponent();
            this.btnCollapse.Name = product.Id.ToString();            
            this.btnCollapse.Text = product.Name;
            
        } 
        private void tmrExpand_Tick(object sender, EventArgs e)
        {
            int new_height = pnlContent.Height + ExpansionPerTick;
            if (new_height >= pnlContent.MaximumSize.Height)
            {
                tmrExpand.Enabled = false;
                new_height = pnlContent.MaximumSize.Height;
            }

            pnlContent.Height = new_height;
        }

        private void tmrCollapse_Tick(object sender, EventArgs e)
        {
            int new_height = pnlContent.Height - ExpansionPerTick;
            if (new_height <= pnlContent.MinimumSize.Height)
            {
                tmrCollapse.Enabled = false;
                new_height = pnlContent.MinimumSize.Height;
            }

            pnlContent.Height = new_height;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Expanded)
            {
                btnCollapse.Image = Properties.Resources.expander_down;
                tmrCollapse.Enabled = true;
                tmrExpand.Enabled = false;
            }
            else
            {
                btnCollapse.Image = Properties.Resources.expander_up;
                tmrExpand.Enabled = true;
                tmrCollapse.Enabled = false;
            }
            Expanded = !Expanded;
        }
        
        private async void SubLoadProducts()
        {
            await Task.Run(() => {
                return GetSubProducts(this.btnCollapse.Name);
            }).ContinueWith(x => {
                responseResult = x.Result;
            });
            if (responseResult != null && Convert.ToInt32(responseResult.StatusCode) == 200)
            {
                var result = JsonConvert.DeserializeObject<List<Subcategories>>(responseResult.Content.ReadAsStringAsync().Result);
                if (result != null)
                {
                    foreach (var subproduct in result)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 250F));
                        tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
                        tableLayoutPanel1.Controls.Add(new SubProduct(subproduct, this.btnCollapse.Name), 1, tableLayoutPanel1.RowCount);                        
                    }
                    tableLayoutPanel1.MaximumSize = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
                    pnlContent.VerticalScroll.Visible = true;
                    pnlContent.HorizontalScroll.Visible = false;
                    tableLayoutPanel1.HorizontalScroll.Visible = false;
                }
            }
        }

        private async Task<HttpResponseMessage> GetSubProducts(string id)
        {
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + "api/SubCategories/GetByCategory/" + id;
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

        private void Collapse_Load(object sender, EventArgs e)
        {
            SubLoadProducts();
        }
    }
}
