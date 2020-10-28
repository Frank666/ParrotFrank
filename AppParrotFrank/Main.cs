using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppParrotFrank
{
    public partial class Main : Form
    {
        public Main(string user)
        {
            InitializeComponent();
            this.lblUser.Text = lblUser.Text.Replace("@User", user);
            this.lblTitle.Text = $"{user} Store";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
