using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using ParrotFrankEntities;
using System.Net;
using ParrotFrankEntities.parrot_frank;

namespace AppParrotFrank
{
    public partial class SubProduct : UserControl
    {
        public SubProduct()
        {
            InitializeComponent();
        }

        #region "Events"
        private void chkAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkAction.Focused)
                return;
            var chk = (CheckBox)sender;
            var update = new Subcategories()
            {
                Id = Convert.ToInt32(this.chkAction.Name),
                CategoryId = Convert.ToInt32(this.lblName.Name),
                Name = this.lblName.Text,
                Status = chk.Checked ? 1 : 0,
                Price = Convert.ToDecimal(this.lblCost.Text),
                ImageUrl = new ParrotFrankHelpers.Utilities().CategoryImage(Convert.ToInt32(this.lblName.Name))
            };
            setProduct(update);
        }
        #endregion

        #region "Methods"
        public SubProduct(Subcategories subcategories, string productId)
        {
            InitializeComponent();
            this.lblCost.Text = subcategories.Price.ToString();
            this.lblName.Text = subcategories.Name;
            this.lblName.Name = productId;
            this.chkAction.Name = subcategories.Id.ToString();
            if (subcategories.Status == 1)
                chkAction.Checked = true;
            switch (subcategories.CategoryId)
            {
                case 1:
                    this.picImage.Image = Properties.Resources.beer_mug_21_609139;
                    break;
                case 2:
                    this.picImage.Image = Properties.Resources.food_823_756232;
                    break;
                case 3:
                    this.picImage.Image = Properties.Resources.dessert_1466876_1240028;
                    break;
            }
        }
        private async void setProduct(Subcategories subProduct)
        {
            await Task.Run(() =>
            {
                return PutProduct(subProduct);
            }).ContinueWith(x =>
            {
                if (Convert.ToInt32(x.Result.StatusCode) == 204)
                {
                    MessageBox.Show("Status was updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Something is wrong...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
        private async Task<HttpResponseMessage> PutProduct(Subcategories subProduct)
        {
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + "api/SubCategories/" + subProduct.Id;
            try
            {
                var product = new
                {
                    Id = subProduct.Id,
                    CategoryId = subProduct.CategoryId,
                    Name = subProduct.Name,
                    Status = subProduct.Status,
                    Price = subProduct.Price,
                    ImageUrl = subProduct.ImageUrl
                };
                return await new ParrotFrankHelpers.APIConsume().APICall(HttpMethod.Put, url, product, GlobalUser.CurrentUser.Token);
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
