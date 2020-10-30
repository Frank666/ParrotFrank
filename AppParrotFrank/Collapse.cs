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
        private const int ExpansionPerTick = 70;
        private readonly string ProductId;
        public Collapse(Categories product)
        {
            InitializeComponent();
            ProductId = product.Id.ToString();            
        }

        #region "Events"
        private void Collapse_Load(object sender, EventArgs e)
        {
            SubLoadProducts();
        }
        #endregion

        #region "Methods"
        private async void SubLoadProducts()
        {
            await Task.Run(() => {
                return GetSubProducts(this.ProductId);
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
                        tableLayoutPanel1.Controls.Add(new SubProduct(subproduct, ProductId), 1, tableLayoutPanel1.RowCount);
                    }
                    tableLayoutPanel1.MaximumSize = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
                    int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
                    tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
                    tableLayoutPanel1.HorizontalScroll.Visible = false;
                }
            }
        }

        private async Task<HttpResponseMessage> GetSubProducts(string id)
        {
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + ConfigurationManager.AppSettings.Get("subProductEndpoint").ToString() + id;
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
        #endregion



       
    }
}
