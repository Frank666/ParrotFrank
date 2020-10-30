namespace AppParrotFrank
{
    partial class SubProduct
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkAction = new System.Windows.Forms.CheckBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAction
            // 
            this.chkAction.AutoSize = true;
            this.chkAction.Location = new System.Drawing.Point(300, 31);
            this.chkAction.Name = "chkAction";
            this.chkAction.Size = new System.Drawing.Size(74, 19);
            this.chkAction.TabIndex = 3;
            this.chkAction.Text = "Available";
            this.chkAction.UseVisualStyleBackColor = true;
            this.chkAction.CheckedChanged += new System.EventHandler(this.chkAvailable_CheckedChanged);
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(117, 92);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(173, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 15);
            this.lblName.TabIndex = 1;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(173, 57);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(0, 15);
            this.lblCost.TabIndex = 2;
            // 
            // SubProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.chkAction);
            this.Name = "SubProduct";
            this.Size = new System.Drawing.Size(373, 91);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAction;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCost;
    }
}
