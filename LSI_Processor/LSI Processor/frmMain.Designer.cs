namespace LSI_Processor
{
	partial class frmMain
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
			this.btnChkForNew = new System.Windows.Forms.Button();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbDestination = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbDisplay = new System.Windows.Forms.TextBox();
			this.btnOpenDest = new System.Windows.Forms.Button();
			this.btnOpenSrc = new System.Windows.Forms.Button();
			this.btnSourceSelect = new System.Windows.Forms.Button();
			this.btnDestSelect = new System.Windows.Forms.Button();
			this.btnSetSourceDefault = new System.Windows.Forms.Button();
			this.btnSaveSourceConfig = new System.Windows.Forms.Button();
			this.btnSetDestinationDefault = new System.Windows.Forms.Button();
			this.btnSaveDestinationConfig = new System.Windows.Forms.Button();
			this.imgPanel = new System.Windows.Forms.Panel();
			this.pbSample = new System.Windows.Forms.PictureBox();
			this.btnPopulateImages = new System.Windows.Forms.Button();
			this.imgPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).BeginInit();
			this.SuspendLayout();
			// 
			// btnChkForNew
			// 
			this.btnChkForNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChkForNew.Location = new System.Drawing.Point(1540, 14);
			this.btnChkForNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnChkForNew.Name = "btnChkForNew";
			this.btnChkForNew.Size = new System.Drawing.Size(225, 35);
			this.btnChkForNew.TabIndex = 0;
			this.btnChkForNew.Text = "Check For New Images";
			this.btnChkForNew.UseVisualStyleBackColor = true;
			this.btnChkForNew.Click += new System.EventHandler(this.btnChkForNew_Click);
			// 
			// tbSource
			// 
			this.tbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSource.Location = new System.Drawing.Point(156, 18);
			this.tbSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbSource.Name = "tbSource";
			this.tbSource.ReadOnly = true;
			this.tbSource.Size = new System.Drawing.Size(749, 26);
			this.tbSource.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 22);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Source Directory";
			// 
			// tbDestination
			// 
			this.tbDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDestination.Location = new System.Drawing.Point(156, 58);
			this.tbDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbDestination.Name = "tbDestination";
			this.tbDestination.ReadOnly = true;
			this.tbDestination.Size = new System.Drawing.Size(749, 26);
			this.tbDestination.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 62);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Output Directory";
			// 
			// tbDisplay
			// 
			this.tbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDisplay.Location = new System.Drawing.Point(22, 98);
			this.tbDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tbDisplay.Multiline = true;
			this.tbDisplay.Name = "tbDisplay";
			this.tbDisplay.Size = new System.Drawing.Size(749, 574);
			this.tbDisplay.TabIndex = 3;
			// 
			// btnOpenDest
			// 
			this.btnOpenDest.Location = new System.Drawing.Point(915, 54);
			this.btnOpenDest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnOpenDest.Name = "btnOpenDest";
			this.btnOpenDest.Size = new System.Drawing.Size(112, 35);
			this.btnOpenDest.TabIndex = 4;
			this.btnOpenDest.Text = "Open";
			this.btnOpenDest.UseVisualStyleBackColor = true;
			this.btnOpenDest.Click += new System.EventHandler(this.btnOpenDest_Click);
			// 
			// btnOpenSrc
			// 
			this.btnOpenSrc.Location = new System.Drawing.Point(915, 14);
			this.btnOpenSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnOpenSrc.Name = "btnOpenSrc";
			this.btnOpenSrc.Size = new System.Drawing.Size(112, 35);
			this.btnOpenSrc.TabIndex = 4;
			this.btnOpenSrc.Text = "Open";
			this.btnOpenSrc.UseVisualStyleBackColor = true;
			this.btnOpenSrc.Click += new System.EventHandler(this.btnOpenSrc_Click);
			// 
			// btnSourceSelect
			// 
			this.btnSourceSelect.Location = new System.Drawing.Point(1036, 14);
			this.btnSourceSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSourceSelect.Name = "btnSourceSelect";
			this.btnSourceSelect.Size = new System.Drawing.Size(112, 35);
			this.btnSourceSelect.TabIndex = 6;
			this.btnSourceSelect.Text = "Select";
			this.btnSourceSelect.UseVisualStyleBackColor = true;
			this.btnSourceSelect.Click += new System.EventHandler(this.btnSourceSelect_Click);
			// 
			// btnDestSelect
			// 
			this.btnDestSelect.Location = new System.Drawing.Point(1036, 54);
			this.btnDestSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnDestSelect.Name = "btnDestSelect";
			this.btnDestSelect.Size = new System.Drawing.Size(112, 35);
			this.btnDestSelect.TabIndex = 6;
			this.btnDestSelect.Text = "Select";
			this.btnDestSelect.UseVisualStyleBackColor = true;
			this.btnDestSelect.Click += new System.EventHandler(this.btnDestSelect_Click);
			// 
			// btnSetSourceDefault
			// 
			this.btnSetSourceDefault.Location = new System.Drawing.Point(1155, 14);
			this.btnSetSourceDefault.Name = "btnSetSourceDefault";
			this.btnSetSourceDefault.Size = new System.Drawing.Size(112, 35);
			this.btnSetSourceDefault.TabIndex = 7;
			this.btnSetSourceDefault.Text = "Use Default";
			this.btnSetSourceDefault.UseVisualStyleBackColor = true;
			this.btnSetSourceDefault.Click += new System.EventHandler(this.btnSetSourceDefault_Click);
			// 
			// btnSaveSourceConfig
			// 
			this.btnSaveSourceConfig.Location = new System.Drawing.Point(1273, 14);
			this.btnSaveSourceConfig.Name = "btnSaveSourceConfig";
			this.btnSaveSourceConfig.Size = new System.Drawing.Size(175, 35);
			this.btnSaveSourceConfig.TabIndex = 7;
			this.btnSaveSourceConfig.Text = "Save To Configuration";
			this.btnSaveSourceConfig.UseVisualStyleBackColor = true;
			this.btnSaveSourceConfig.Click += new System.EventHandler(this.btnSaveSourceConfig_Click);
			// 
			// btnSetDestinationDefault
			// 
			this.btnSetDestinationDefault.Location = new System.Drawing.Point(1155, 54);
			this.btnSetDestinationDefault.Name = "btnSetDestinationDefault";
			this.btnSetDestinationDefault.Size = new System.Drawing.Size(112, 35);
			this.btnSetDestinationDefault.TabIndex = 7;
			this.btnSetDestinationDefault.Text = "Use Default";
			this.btnSetDestinationDefault.UseVisualStyleBackColor = true;
			this.btnSetDestinationDefault.Click += new System.EventHandler(this.btnSetDestinationDefault_Click);
			// 
			// btnSaveDestinationConfig
			// 
			this.btnSaveDestinationConfig.Location = new System.Drawing.Point(1273, 55);
			this.btnSaveDestinationConfig.Name = "btnSaveDestinationConfig";
			this.btnSaveDestinationConfig.Size = new System.Drawing.Size(175, 35);
			this.btnSaveDestinationConfig.TabIndex = 7;
			this.btnSaveDestinationConfig.Text = "Save To Configuration";
			this.btnSaveDestinationConfig.UseVisualStyleBackColor = true;
			this.btnSaveDestinationConfig.Click += new System.EventHandler(this.btnSaveDestinationConfig_Click);
			// 
			// imgPanel
			// 
			this.imgPanel.AutoScroll = true;
			this.imgPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgPanel.Controls.Add(this.pbSample);
			this.imgPanel.Location = new System.Drawing.Point(914, 256);
			this.imgPanel.Name = "imgPanel";
			this.imgPanel.Size = new System.Drawing.Size(822, 543);
			this.imgPanel.TabIndex = 8;
			// 
			// pbSample
			// 
			this.pbSample.Location = new System.Drawing.Point(96, 78);
			this.pbSample.Name = "pbSample";
			this.pbSample.Size = new System.Drawing.Size(100, 100);
			this.pbSample.TabIndex = 0;
			this.pbSample.TabStop = false;
			this.pbSample.Click += new System.EventHandler(this.pbSample_Click);
			// 
			// btnPopulateImages
			// 
			this.btnPopulateImages.Location = new System.Drawing.Point(1586, 184);
			this.btnPopulateImages.Name = "btnPopulateImages";
			this.btnPopulateImages.Size = new System.Drawing.Size(150, 35);
			this.btnPopulateImages.TabIndex = 9;
			this.btnPopulateImages.Text = "Get Images";
			this.btnPopulateImages.UseVisualStyleBackColor = true;
			this.btnPopulateImages.Click += new System.EventHandler(this.btnPopulateImages_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1778, 844);
			this.Controls.Add(this.btnPopulateImages);
			this.Controls.Add(this.imgPanel);
			this.Controls.Add(this.btnSaveDestinationConfig);
			this.Controls.Add(this.btnSaveSourceConfig);
			this.Controls.Add(this.btnSetDestinationDefault);
			this.Controls.Add(this.btnSetSourceDefault);
			this.Controls.Add(this.btnDestSelect);
			this.Controls.Add(this.btnSourceSelect);
			this.Controls.Add(this.btnOpenSrc);
			this.Controls.Add(this.btnOpenDest);
			this.Controls.Add(this.tbDisplay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbDestination);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSource);
			this.Controls.Add(this.btnChkForNew);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmMain";
			this.Text = "LSI Processor";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.imgPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSample)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnChkForNew;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbDestination;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbDisplay;
		private System.Windows.Forms.Button btnOpenDest;
		private System.Windows.Forms.Button btnOpenSrc;
		private System.Windows.Forms.Button btnSourceSelect;
		private System.Windows.Forms.Button btnDestSelect;
		private System.Windows.Forms.Button btnSetSourceDefault;
		private System.Windows.Forms.Button btnSaveSourceConfig;
		private System.Windows.Forms.Button btnSetDestinationDefault;
		private System.Windows.Forms.Button btnSaveDestinationConfig;
		private System.Windows.Forms.Panel imgPanel;
		private System.Windows.Forms.PictureBox pbSample;
		private System.Windows.Forms.Button btnPopulateImages;
	}
}

