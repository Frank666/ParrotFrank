namespace AppParrotFrank
{
    partial class Collapse
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
            this.components = new System.ComponentModel.Container();
            this.tmrCollapse = new System.Windows.Forms.Timer(this.components);
            this.tmrExpand = new System.Windows.Forms.Timer(this.components);
            this.btnCollapse = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCollapse
            // 
            this.tmrCollapse.Tick += new System.EventHandler(this.tmrCollapse_Tick);
            // 
            // tmrExpand
            // 
            this.tmrExpand.Tick += new System.EventHandler(this.tmrExpand_Tick);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(13, 9);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(75, 23);
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.Location = new System.Drawing.Point(2, 33);
            this.pnlContent.MaximumSize = new System.Drawing.Size(600, 141);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(553, 141);
            this.pnlContent.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(550, 137);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 137);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Collapse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnCollapse);
            this.MaximumSize = new System.Drawing.Size(600, 175);
            this.Name = "Collapse";
            this.Size = new System.Drawing.Size(558, 175);
            this.Load += new System.EventHandler(this.Collapse_Load);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrCollapse;
        private System.Windows.Forms.Timer tmrExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
