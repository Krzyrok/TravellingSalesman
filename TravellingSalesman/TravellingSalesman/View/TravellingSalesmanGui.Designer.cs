namespace TravellingSalesman
{
    partial class TravellingSalesmanGui
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumberOfRoutes = new System.Windows.Forms.TextBox();
            this.textBoxLengthOfRoute = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumberOfCities = new System.Windows.Forms.TextBox();
            this.textBoxFactorK = new System.Windows.Forms.TextBox();
            this.buttonSearchRoutes = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem.Text = "Open";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Number of routes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Length of route:";
            // 
            // textBoxNumberOfRoutes
            // 
            this.textBoxNumberOfRoutes.Enabled = false;
            this.textBoxNumberOfRoutes.Location = new System.Drawing.Point(106, 164);
            this.textBoxNumberOfRoutes.Name = "textBoxNumberOfRoutes";
            this.textBoxNumberOfRoutes.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfRoutes.TabIndex = 17;
            // 
            // textBoxLengthOfRoute
            // 
            this.textBoxLengthOfRoute.Enabled = false;
            this.textBoxLengthOfRoute.Location = new System.Drawing.Point(106, 138);
            this.textBoxLengthOfRoute.Name = "textBoxLengthOfRoute";
            this.textBoxLengthOfRoute.Size = new System.Drawing.Size(100, 20);
            this.textBoxLengthOfRoute.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "k:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Number of cities:";
            // 
            // textBoxNumberOfCities
            // 
            this.textBoxNumberOfCities.Enabled = false;
            this.textBoxNumberOfCities.Location = new System.Drawing.Point(106, 27);
            this.textBoxNumberOfCities.Name = "textBoxNumberOfCities";
            this.textBoxNumberOfCities.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfCities.TabIndex = 13;
            // 
            // textBoxFactorK
            // 
            this.textBoxFactorK.Enabled = false;
            this.textBoxFactorK.Location = new System.Drawing.Point(106, 53);
            this.textBoxFactorK.Name = "textBoxFactorK";
            this.textBoxFactorK.Size = new System.Drawing.Size(100, 20);
            this.textBoxFactorK.TabIndex = 12;
            // 
            // buttonSearchRoutes
            // 
            this.buttonSearchRoutes.Enabled = false;
            this.buttonSearchRoutes.Location = new System.Drawing.Point(9, 79);
            this.buttonSearchRoutes.Name = "buttonSearchRoutes";
            this.buttonSearchRoutes.Size = new System.Drawing.Size(104, 23);
            this.buttonSearchRoutes.TabIndex = 11;
            this.buttonSearchRoutes.Text = "Search routes";
            this.buttonSearchRoutes.UseVisualStyleBackColor = true;
            this.buttonSearchRoutes.Click += new System.EventHandler(this.buttonSearchRoutes_Click);
            // 
            // TravellingSalesmanGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumberOfRoutes);
            this.Controls.Add(this.textBoxLengthOfRoute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNumberOfCities);
            this.Controls.Add(this.textBoxFactorK);
            this.Controls.Add(this.buttonSearchRoutes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TravellingSalesmanGui";
            this.Text = "TravellingSalesmanGui";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumberOfRoutes;
        private System.Windows.Forms.TextBox textBoxLengthOfRoute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumberOfCities;
        private System.Windows.Forms.TextBox textBoxFactorK;
        private System.Windows.Forms.Button buttonSearchRoutes;
    }
}