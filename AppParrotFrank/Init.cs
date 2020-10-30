using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Nancy.Json;
using System.Threading.Tasks;
using ParrotFrankEntities.parrot_frank;
using System.Threading;
using ParrotFrankEntities;

namespace AppParrotFrank
{
    public partial class Init : Form
    {
        private HttpResponseMessage responseResult;

        public Init()
        {
            InitializeComponent();
            txtNick.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtNick.Text = "Fideo";
            this.txtPass.Text = "Fideo123";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Login();
            }
        }

        private async void Login()
        {
            btnLogin.Enabled = false;
            picLoading.Show();
            await Task.Run(() => {
                return CheckUser();
            }).ContinueWith(x => {
                responseResult = x.Result;
            });
            btnLogin.Enabled = true;
            if (responseResult != null)
            {
                picLoading.Hide();
                if (Convert.ToInt32(this.responseResult.StatusCode) == 200)
                {
                    GlobalUser.CurrentUser = JsonConvert.DeserializeObject<Users>(responseResult.Content.ReadAsStringAsync().Result);
                    GlobalUser.CurrentUser.Nick = this.txtNick.Text;
                    this.Hide();
                    new Main().Show();
                }
                else
                {
                    MessageBox.Show(responseResult.StatusCode.ToString());
                }
            }
        }        
         

        private async Task<HttpResponseMessage> CheckUser()
        {
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + "api/token/login/";
            try
            {
                var postObject = new
                {
                    Nick = this.txtNick.Text,
                    Secret = this.txtPass.Text
                };
                return await new ParrotFrankHelpers.APIConsume().APICall(HttpMethod.Post, url, postObject);
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return null;
        } 

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtNick.Text))
            {
                MessageBox.Show("Please type a nick", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNick.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Please type a password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return false;
            }
            return true;
        }
    }
}
