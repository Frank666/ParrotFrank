namespace AppParrotFrank
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.accordion1 = new Opulos.Core.UI.Accordion();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(502, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 37);
            this.lblTitle.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUser.Location = new System.Drawing.Point(26, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(221, 37);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Welcome @User!";
            this.lblUser.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblToken.Location = new System.Drawing.Point(621, 59);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(225, 74);
            this.lblToken.TabIndex = 0;
            this.lblToken.Text = "Expiration Token: \r\n@Time min";
            this.lblToken.Click += new System.EventHandler(this.label3_Click);
            // 
            // accordion1
            // 
            this.accordion1.AddResizeBars = true;
            this.accordion1.AllowMouseResize = true;
            this.accordion1.AnimateCloseEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalNegative | Opulos.Core.UI.AnimateWindowFlags.Hide) 
            | Opulos.Core.UI.AnimateWindowFlags.Slide)));
            this.accordion1.AnimateCloseMillis = 300;
            this.accordion1.AnimateOpenEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalPositive | Opulos.Core.UI.AnimateWindowFlags.Show) 
            | Opulos.Core.UI.AnimateWindowFlags.Slide)));
            this.accordion1.AnimateOpenMillis = 300;
            this.accordion1.AutoFixDockStyle = true;
            this.accordion1.AutoScroll = true;
            this.accordion1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.accordion1.CheckBoxFactory = null;
            this.accordion1.CheckBoxMargin = new System.Windows.Forms.Padding(0);
            this.accordion1.ContentBackColor = null;
            this.accordion1.ContentMargin = null;
            this.accordion1.ContentPadding = new System.Windows.Forms.Padding(5);
            this.accordion1.ControlBackColor = null;
            this.accordion1.ControlMinimumHeightIsItsPreferredHeight = true;
            this.accordion1.ControlMinimumWidthIsItsPreferredWidth = true;
            this.accordion1.DownArrow = null;
            this.accordion1.FillHeight = true;
            this.accordion1.FillLastOpened = false;
            this.accordion1.FillModeGrowOnly = false;
            this.accordion1.FillResetOnCollapse = false;
            this.accordion1.FillWidth = true;
            this.accordion1.GrabCursor = System.Windows.Forms.Cursors.SizeNS;
            this.accordion1.GrabRequiresPositiveFillWeight = true;
            this.accordion1.GrabWidth = 6;
            this.accordion1.GrowAndShrink = true;
            this.accordion1.Insets = new System.Windows.Forms.Padding(0);
            this.accordion1.Location = new System.Drawing.Point(7, 59);
            this.accordion1.Name = "accordion1";
            this.accordion1.OpenOnAdd = false;
            this.accordion1.OpenOneOnly = false;
            this.accordion1.ResizeBarFactory = null;
            this.accordion1.ResizeBarsAlign = 0.5D;
            this.accordion1.ResizeBarsArrowKeyDelta = 10;
            this.accordion1.ResizeBarsFadeInMillis = 800;
            this.accordion1.ResizeBarsFadeOutMillis = 800;
            this.accordion1.ResizeBarsFadeProximity = 24;
            this.accordion1.ResizeBarsFill = 1D;
            this.accordion1.ResizeBarsKeepFocusAfterMouseDrag = false;
            this.accordion1.ResizeBarsKeepFocusIfControlOutOfView = true;
            this.accordion1.ResizeBarsKeepFocusOnClick = true;
            this.accordion1.ResizeBarsMargin = null;
            this.accordion1.ResizeBarsMinimumLength = 50;
            this.accordion1.ResizeBarsStayInViewOnArrowKey = true;
            this.accordion1.ResizeBarsStayInViewOnMouseDrag = true;
            this.accordion1.ResizeBarsStayVisibleIfFocused = true;
            this.accordion1.ResizeBarsTabStop = true;
            this.accordion1.ShowPartiallyVisibleResizeBars = false;
            this.accordion1.ShowToolMenu = true;
            this.accordion1.ShowToolMenuOnHoverWhenClosed = false;
            this.accordion1.ShowToolMenuOnRightClick = true;
            this.accordion1.ShowToolMenuRequiresPositiveFillWeight = false;
            this.accordion1.Size = new System.Drawing.Size(868, 537);
            this.accordion1.TabIndex = 1;
            this.accordion1.UpArrow = null;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(887, 608);
            this.Controls.Add(this.accordion1);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitle);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblToken;
        private Opulos.Core.UI.Accordion accordion1;
    }
}