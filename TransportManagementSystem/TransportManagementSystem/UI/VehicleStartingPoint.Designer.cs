namespace TransportManagementSystem.UI
{
    partial class VehicleStartingPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleStartingPoint));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSectorId = new System.Windows.Forms.Label();
            this.lblVecileID = new System.Windows.Forms.Label();
            this.lblRouteID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboBoxSectorID = new System.Windows.Forms.ComboBox();
            this.comboBoxVehicleID = new System.Windows.Forms.ComboBox();
            this.comboBoxRouteID = new System.Windows.Forms.ComboBox();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoInActive = new System.Windows.Forms.RadioButton();
            this.dataGridViewStartingPoint = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStartingPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(188, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(18, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(118, 218);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(133, 22);
            this.textBoxName.TabIndex = 13;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(118, 57);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(133, 22);
            this.textBoxId.TabIndex = 12;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(30, 221);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 16);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(30, 65);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 16);
            this.lblID.TabIndex = 9;
            this.lblID.Text = "ID";
            // 
            // lblSectorId
            // 
            this.lblSectorId.AutoSize = true;
            this.lblSectorId.BackColor = System.Drawing.Color.Transparent;
            this.lblSectorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectorId.Location = new System.Drawing.Point(28, 99);
            this.lblSectorId.Name = "lblSectorId";
            this.lblSectorId.Size = new System.Drawing.Size(57, 16);
            this.lblSectorId.TabIndex = 17;
            this.lblSectorId.Text = "Sector ";
            // 
            // lblVecileID
            // 
            this.lblVecileID.AutoSize = true;
            this.lblVecileID.BackColor = System.Drawing.Color.Transparent;
            this.lblVecileID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVecileID.Location = new System.Drawing.Point(27, 134);
            this.lblVecileID.Name = "lblVecileID";
            this.lblVecileID.Size = new System.Drawing.Size(64, 16);
            this.lblVecileID.TabIndex = 19;
            this.lblVecileID.Text = "Vehicle ";
            // 
            // lblRouteID
            // 
            this.lblRouteID.AutoSize = true;
            this.lblRouteID.BackColor = System.Drawing.Color.Transparent;
            this.lblRouteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRouteID.Location = new System.Drawing.Point(28, 172);
            this.lblRouteID.Name = "lblRouteID";
            this.lblRouteID.Size = new System.Drawing.Size(49, 16);
            this.lblRouteID.TabIndex = 21;
            this.lblRouteID.Text = "Route";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(99, 351);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 37);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // comboBoxSectorID
            // 
            this.comboBoxSectorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSectorID.FormattingEnabled = true;
            this.comboBoxSectorID.Location = new System.Drawing.Point(118, 99);
            this.comboBoxSectorID.Name = "comboBoxSectorID";
            this.comboBoxSectorID.Size = new System.Drawing.Size(133, 24);
            this.comboBoxSectorID.TabIndex = 24;
            this.comboBoxSectorID.SelectedIndexChanged += new System.EventHandler(this.comboBoxSectorID_SelectedIndexChanged);
            // 
            // comboBoxVehicleID
            // 
            this.comboBoxVehicleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVehicleID.FormattingEnabled = true;
            this.comboBoxVehicleID.Location = new System.Drawing.Point(118, 136);
            this.comboBoxVehicleID.Name = "comboBoxVehicleID";
            this.comboBoxVehicleID.Size = new System.Drawing.Size(133, 24);
            this.comboBoxVehicleID.TabIndex = 26;
            this.comboBoxVehicleID.SelectedIndexChanged += new System.EventHandler(this.comboBoxVehicleID_SelectedIndexChanged);
            // 
            // comboBoxRouteID
            // 
            this.comboBoxRouteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRouteID.FormattingEnabled = true;
            this.comboBoxRouteID.Location = new System.Drawing.Point(118, 175);
            this.comboBoxRouteID.Name = "comboBoxRouteID";
            this.comboBoxRouteID.Size = new System.Drawing.Size(133, 24);
            this.comboBoxRouteID.TabIndex = 27;
            this.comboBoxRouteID.SelectedIndexChanged += new System.EventHandler(this.comboBoxRouteID_SelectedIndexChanged);
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActive.Location = new System.Drawing.Point(33, 279);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(69, 20);
            this.rdoActive.TabIndex = 28;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoInActive
            // 
            this.rdoInActive.AutoSize = true;
            this.rdoInActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInActive.Location = new System.Drawing.Point(162, 280);
            this.rdoInActive.Name = "rdoInActive";
            this.rdoInActive.Size = new System.Drawing.Size(85, 20);
            this.rdoInActive.TabIndex = 29;
            this.rdoInActive.TabStop = true;
            this.rdoInActive.Text = "In Active";
            this.rdoInActive.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStartingPoint
            // 
            this.dataGridViewStartingPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStartingPoint.Location = new System.Drawing.Point(307, 90);
            this.dataGridViewStartingPoint.Name = "dataGridViewStartingPoint";
            this.dataGridViewStartingPoint.Size = new System.Drawing.Size(613, 261);
            this.dataGridViewStartingPoint.TabIndex = 30;
            this.dataGridViewStartingPoint.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewStartingPoint_RowHeaderMouseClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(304, 57);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 16);
            this.lblSearch.TabIndex = 31;
            this.lblSearch.Text = "Search";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(367, 54);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(203, 22);
            this.textBoxSearch.TabIndex = 32;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // VehicleStartingPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 400);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dataGridViewStartingPoint);
            this.Controls.Add(this.rdoInActive);
            this.Controls.Add(this.rdoActive);
            this.Controls.Add(this.comboBoxRouteID);
            this.Controls.Add(this.comboBoxVehicleID);
            this.Controls.Add(this.comboBoxSectorID);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblRouteID);
            this.Controls.Add(this.lblVecileID);
            this.Controls.Add(this.lblSectorId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VehicleStartingPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VehicleStartingPoint";
            this.Load += new System.EventHandler(this.VehicleStartingPoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStartingPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSectorId;
        private System.Windows.Forms.Label lblVecileID;
        private System.Windows.Forms.Label lblRouteID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboBoxSectorID;
        private System.Windows.Forms.ComboBox comboBoxVehicleID;
        private System.Windows.Forms.ComboBox comboBoxRouteID;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoInActive;
        private System.Windows.Forms.DataGridView dataGridViewStartingPoint;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}