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
			this.btnTest = new System.Windows.Forms.Button();
			this.btnSourceSelect = new System.Windows.Forms.Button();
			this.btnDestSelect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnChkForNew
			// 
			this.btnChkForNew.Location = new System.Drawing.Point(886, 9);
			this.btnChkForNew.Name = "btnChkForNew";
			this.btnChkForNew.Size = new System.Drawing.Size(150, 23);
			this.btnChkForNew.TabIndex = 0;
			this.btnChkForNew.Text = "Check For New";
			this.btnChkForNew.UseVisualStyleBackColor = true;
			this.btnChkForNew.Click += new System.EventHandler(this.btnChkForNew_Click);
			// 
			// tbSource
			// 
			this.tbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSource.Location = new System.Drawing.Point(104, 12);
			this.tbSource.Name = "tbSource";
			this.tbSource.ReadOnly = true;
			this.tbSource.Size = new System.Drawing.Size(500, 20);
			this.tbSource.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Source Directory";
			// 
			// tbDestination
			// 
			this.tbDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDestination.Location = new System.Drawing.Point(104, 38);
			this.tbDestination.Name = "tbDestination";
			this.tbDestination.ReadOnly = true;
			this.tbDestination.Size = new System.Drawing.Size(500, 20);
			this.tbDestination.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Output Directory";
			// 
			// tbDisplay
			// 
			this.tbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDisplay.Location = new System.Drawing.Point(15, 64);
			this.tbDisplay.Multiline = true;
			this.tbDisplay.Name = "tbDisplay";
			this.tbDisplay.Size = new System.Drawing.Size(500, 374);
			this.tbDisplay.TabIndex = 3;
			// 
			// btnOpenDest
			// 
			this.btnOpenDest.Location = new System.Drawing.Point(610, 35);
			this.btnOpenDest.Name = "btnOpenDest";
			this.btnOpenDest.Size = new System.Drawing.Size(75, 23);
			this.btnOpenDest.TabIndex = 4;
			this.btnOpenDest.Text = "Open";
			this.btnOpenDest.UseVisualStyleBackColor = true;
			// 
			// btnOpenSrc
			// 
			this.btnOpenSrc.Location = new System.Drawing.Point(610, 9);
			this.btnOpenSrc.Name = "btnOpenSrc";
			this.btnOpenSrc.Size = new System.Drawing.Size(75, 23);
			this.btnOpenSrc.TabIndex = 4;
			this.btnOpenSrc.Text = "Open";
			this.btnOpenSrc.UseVisualStyleBackColor = true;
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(521, 415);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 5;
			this.btnTest.Text = "TEST";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// btnSourceSelect
			// 
			this.btnSourceSelect.Location = new System.Drawing.Point(691, 9);
			this.btnSourceSelect.Name = "btnSourceSelect";
			this.btnSourceSelect.Size = new System.Drawing.Size(75, 23);
			this.btnSourceSelect.TabIndex = 6;
			this.btnSourceSelect.Text = "Select";
			this.btnSourceSelect.UseVisualStyleBackColor = true;
			// 
			// btnDestSelect
			// 
			this.btnDestSelect.Location = new System.Drawing.Point(691, 35);
			this.btnDestSelect.Name = "btnDestSelect";
			this.btnDestSelect.Size = new System.Drawing.Size(75, 23);
			this.btnDestSelect.TabIndex = 6;
			this.btnDestSelect.Text = "Select";
			this.btnDestSelect.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1048, 450);
			this.Controls.Add(this.btnDestSelect);
			this.Controls.Add(this.btnSourceSelect);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.btnOpenSrc);
			this.Controls.Add(this.btnOpenDest);
			this.Controls.Add(this.tbDisplay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbDestination);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSource);
			this.Controls.Add(this.btnChkForNew);
			this.Name = "frmMain";
			this.Text = "LSI Processor";
			this.Load += new System.EventHandler(this.frmMain_Load);
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
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Button btnSourceSelect;
		private System.Windows.Forms.Button btnDestSelect;
	}
}

