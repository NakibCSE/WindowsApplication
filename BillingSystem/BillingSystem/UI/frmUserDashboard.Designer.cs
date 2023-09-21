namespace BillingSystem
{
    partial class frmUserDashboard
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
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSubHead = new System.Windows.Forms.Label();
            this.lblAppLName = new System.Windows.Forms.Label();
            this.lblAppFName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblDevelopedBy = new System.Windows.Forms.Label();
            this.lblUserloggedin = new System.Windows.Forms.Label();
            this.menuStripTop.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.salesFormToolStripMenuItem,
            this.inventoryToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(941, 24);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.purchaseToolStripMenuItem.Text = "Purchase ";
            // 
            // salesFormToolStripMenuItem
            // 
            this.salesFormToolStripMenuItem.Name = "salesFormToolStripMenuItem";
            this.salesFormToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.salesFormToolStripMenuItem.Text = "Sales Form ";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // lblSubHead
            // 
            this.lblSubHead.AutoSize = true;
            this.lblSubHead.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubHead.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblSubHead.Location = new System.Drawing.Point(426, 367);
            this.lblSubHead.Name = "lblSubHead";
            this.lblSubHead.Size = new System.Drawing.Size(351, 30);
            this.lblSubHead.TabIndex = 12;
            this.lblSubHead.Text = "Billing and Inventory Management ";
            // 
            // lblAppLName
            // 
            this.lblAppLName.AutoSize = true;
            this.lblAppLName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppLName.Location = new System.Drawing.Point(581, 327);
            this.lblAppLName.Name = "lblAppLName";
            this.lblAppLName.Size = new System.Drawing.Size(105, 40);
            this.lblAppLName.TabIndex = 11;
            this.lblAppLName.Text = "STORE";
            // 
            // lblAppFName
            // 
            this.lblAppFName.AutoSize = true;
            this.lblAppFName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFName.Location = new System.Drawing.Point(511, 327);
            this.lblAppFName.Name = "lblAppFName";
            this.lblAppFName.Size = new System.Drawing.Size(74, 40);
            this.lblAppFName.TabIndex = 10;
            this.lblAppFName.Text = "ANY";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserName.Location = new System.Drawing.Point(48, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 17);
            this.lblUserName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "User:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.Teal;
            this.panelFooter.Controls.Add(this.lblDevelopedBy);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.ForeColor = System.Drawing.Color.White;
            this.panelFooter.Location = new System.Drawing.Point(0, 461);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(941, 28);
            this.panelFooter.TabIndex = 13;
            // 
            // lblDevelopedBy
            // 
            this.lblDevelopedBy.AutoSize = true;
            this.lblDevelopedBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevelopedBy.Location = new System.Drawing.Point(482, 0);
            this.lblDevelopedBy.Name = "lblDevelopedBy";
            this.lblDevelopedBy.Size = new System.Drawing.Size(209, 17);
            this.lblDevelopedBy.TabIndex = 0;
            this.lblDevelopedBy.Text = "Developed By: Nazim Uddin Nakib";
            this.lblDevelopedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserloggedin
            // 
            this.lblUserloggedin.AutoSize = true;
            this.lblUserloggedin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserloggedin.ForeColor = System.Drawing.Color.Lime;
            this.lblUserloggedin.Location = new System.Drawing.Point(54, 46);
            this.lblUserloggedin.Name = "lblUserloggedin";
            this.lblUserloggedin.Size = new System.Drawing.Size(0, 17);
            this.lblUserloggedin.TabIndex = 14;
            // 
            // frmUserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 489);
            this.Controls.Add(this.lblUserloggedin);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.lblSubHead);
            this.Controls.Add(this.lblAppLName);
            this.Controls.Add(this.lblAppFName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "frmUserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserDashboard_FormClosed);
            this.Load += new System.EventHandler(this.frmUserDashboard_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Label lblSubHead;
        private System.Windows.Forms.Label lblAppLName;
        private System.Windows.Forms.Label lblAppFName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblDevelopedBy;
        private System.Windows.Forms.Label lblUserloggedin;
    }
}