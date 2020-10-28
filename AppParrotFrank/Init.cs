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

namespace AppParrotFrank
{
    public partial class Init : Form
    {
        BackgroundWorker bgWorker = new BackgroundWorker();


        public Init()
        {
            InitializeComponent();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;
            txtNick.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            var url = ConfigurationManager.AppSettings.Get("apiServer").ToString() + $"api/token/login/";            
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
                {
                    var postObject = new 
                    {
                        Nick = this.txtNick.Text,
                        Secret = this.txtPass.Text
                    };

                    var myContent = JsonConvert.SerializeObject(postObject);                    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var builder = new UriBuilder(new Uri(url));;

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, builder.Uri);
                    request.Content = new StringContent(myContent, Encoding.UTF8, "application/json");//CONTENT-TYPE header

                    HttpResponseMessage response = await client.SendAsync(request);

                    if(Convert.ToInt32(response.StatusCode) == 200)
                    {
                        this.Hide();
                        var next = new Main();
                        next.Show();
                    }
                    else
                    {
                        MessageBox.Show(response.Content.ToString(), "UPS!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

            }
            catch (WebException ex)
            {
                // Handle error
            }

            //btnLogin.Enabled = false;
            //if (!bgWorker.IsBusy)
            //    bgWorker.RunWorkerAsync();
        }

        
              
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;

            int maxProgress = 100;
            prgProgressBar.Maximum = maxProgress;


            while (x < maxProgress)
            {
                System.Threading.Thread.Sleep(50);
                Invoke(new Action(() => { prgProgressBar.PerformStep(); }));
                x += 1;
            }
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //e.Error will contain any exceptions caught by the backgroundWorker
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                btnLogin.Enabled = true;
                MessageBox.Show("Task Complete!");
            }
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
