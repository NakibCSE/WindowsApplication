namespace TransportManagementSystem
{
    partial class Transport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transport));
            this.VehicleSector = new System.Windows.Forms.Button();
            this.btnVehicleType = new System.Windows.Forms.Button();
            this.btnTransportRoute = new System.Windows.Forms.Button();
            this.btnStartingPoint = new System.Windows.Forms.Button();
            this.textBoxBanner = new System.Windows.Forms.TextBox();
            this.btnPickUpPoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VehicleSector
            // 
            this.VehicleSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleSector.Location = new System.Drawing.Point(41, 102);
            this.VehicleSector.Name = "VehicleSector";
            this.VehicleSector.Size = new System.Drawing.Size(133, 40);
            this.VehicleSector.TabIndex = 0;
            this.VehicleSector.Text = "Vechicle Sector";
            this.VehicleSector.UseVisualStyleBackColor = true;
            this.VehicleSector.Click += new System.EventHandler(this.VehicleSector_Click);
            // 
            // btnVehicleType
            // 
            this.btnVehicleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleType.Location = new System.Drawing.Point(180, 102);
            this.btnVehicleType.Name = "btnVehicleType";
            this.btnVehicleType.Size = new System.Drawing.Size(128, 40);
            this.btnVehicleType.TabIndex = 1;
            this.btnVehicleType.Text = "Vehicle Type";
            this.btnVehicleType.UseVisualStyleBackColor = true;
            this.btnVehicleType.Click += new System.EventHandler(this.btnVehicleType_Click);
            // 
            // btnTransportRoute
            // 
            this.btnTransportRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransportRoute.Location = new System.Drawing.Point(314, 102);
            this.btnTransportRoute.Name = "btnTransportRoute";
            this.btnTransportRoute.Size = new System.Drawing.Size(119, 40);
            this.btnTransportRoute.TabIndex = 2;
            this.btnTransportRoute.Text = "Transport Route";
            this.btnTransportRoute.UseVisualStyleBackColor = true;
            this.btnTransportRoute.Click += new System.EventHandler(this.btnTransportRoute_Click);
            // 
            // btnStartingPoint
            // 
            this.btnStartingPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartingPoint.Location = new System.Drawing.Point(449, 102);
            this.btnStartingPoint.Name = "btnStartingPoint";
            this.btnStartingPoint.Size = new System.Drawing.Size(132, 40);
            this.btnStartingPoint.TabIndex = 3;
            this.btnStartingPoint.Text = "Starting Point";
            this.btnStartingPoint.UseVisualStyleBackColor = true;
            this.btnStartingPoint.Click += new System.EventHandler(this.btnStartingPoint_Click);
            // 
            // textBoxBanner
            // 
            this.textBoxBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBanner.Location = new System.Drawing.Point(247, 25);
            this.textBoxBanner.Name = "textBoxBanner";
            this.textBoxBanner.Size = new System.Drawing.Size(334, 31);
            this.textBoxBanner.TabIndex = 4;
            this.textBoxBanner.Text = "Welcome To Transport Section";
            // 
            // btnPickUpPoint
            // 
            this.btnPickUpPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickUpPoint.Location = new System.Drawing.Point(598, 102);
            this.btnPickUpPoint.Name = "btnPickUpPoint";
            this.btnPickUpPoint.Size = new System.Drawing.Size(132, 40);
            this.btnPickUpPoint.TabIndex = 5;
            this.btnPickUpPoint.Text = "Pickup Point";
            this.btnPickUpPoint.UseVisualStyleBackColor = true;
            this.btnPickUpPoint.Click += new System.EventHandler(this.btnPickUpPoint_Click);
            // 
            // Transport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 296);
            this.Controls.Add(this.btnPickUpPoint);
            this.Controls.Add(this.textBoxBanner);
            this.Controls.Add(this.btnStartingPoint);
            this.Controls.Add(this.btnTransportRoute);
            this.Controls.Add(this.btnVehicleType);
            this.Controls.Add(this.VehicleSector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VehicleSector;
        private System.Windows.Forms.Button btnVehicleType;
        private System.Windows.Forms.Button btnTransportRoute;
        private System.Windows.Forms.Button btnStartingPoint;
        private System.Windows.Forms.TextBox textBoxBanner;
        private System.Windows.Forms.Button btnPickUpPoint;
    }
}

