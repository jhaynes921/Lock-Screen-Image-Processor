using Microsoft.WindowsAPICodePack.Dialogs;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shell;

using PDQ = Microsoft.WindowsAPICodePack.Dialogs;

namespace LSI_Processor
{
	public partial class frmMain : Form
	{
		#region Ap Variables


		internal string SourceDir;
		internal string DestinationDir;
		internal string[] ImageFileTypes = new string[] { ".jpg", ".jpeg", ".png" };
		internal int PortraitCount = 0;
		internal int LandscapeCount = 0;
		internal int TooSmallCount = 0;
		internal int ErrorCount = 0;
		internal int thumbSize = 100;
		internal int thumbnailStart = 10;
		internal int thumbnailXSpacing = 24;
		internal int thumbnailYSpacing = 24;

		internal string DefaultSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
		internal string DefaultDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\LSI\\Incoming";

		internal Preferences Prefs;

		#endregion Ap Variables

		#region Instantiation and Initial Methods


		public frmMain()
		{
			InitializeComponent();

			SourceDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
			DestinationDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\LSI\\Incoming";

			string portraitDir = Path.Combine(DestinationDir) + "\\Portrait\\";
			if (!Directory.Exists(portraitDir)) { Directory.CreateDirectory(portraitDir); }
			string landscapeDir = Path.Combine(DestinationDir) + "\\Landscape\\";
			if (!Directory.Exists(landscapeDir)) { Directory.CreateDirectory(landscapeDir); }


			tbSource.Text = SourceDir;
			tbDestination.Text = DestinationDir;
			Application.DoEvents();
		}
		private void frmMain_Load(object sender, EventArgs e)
		{
			//tbDisplay.Text = sourceDir;

		}



		#endregion Instantiation and Initial Methods

		#region Configuration Methods

		private void ReadConfigFile() 
		{
			string configSourceDir = "DEFAULT";
			string configDestDir = "DEFAULT";

			try
			{
				configSourceDir = ConfigurationManager.AppSettings["SourceDirectory"];
				switch (configSourceDir)
				{
					case "DEFAULT":
						configSourceDir = DefaultSource;
						break;
					case null:
						configSourceDir = DefaultSource;
						break;
					case "":
						configSourceDir = DefaultSource;
						break;
					default:

						if (!Directory.Exists(configSourceDir))
						{
							WriteToDisplay("Source directory \"" + configSourceDir + "\" from the config file is in valid, using default source directory instead.");
							configSourceDir = DefaultSource;
						}
						break;
				}
			}
			catch (Exception ex)
			{
				WriteToDisplay("There was a problem attempting to retrieve the source directory location from the config file, using default instead.\r\nError Message: " + ex.Message);
				configSourceDir = DefaultSource;
			}
			tbSource.Text = configSourceDir;


			try
			{
				configDestDir = ConfigurationManager.AppSettings["DestinationDirectory"];
				switch (configDestDir)
				{
					case "DEFAULT":
						configDestDir = DefaultDestination;
						break;
					case null:
						configDestDir = DefaultDestination;
						break;
					case "":
						configDestDir = DefaultDestination;
						break;
					default:

						if (!Directory.Exists(configDestDir))
						{
							WriteToDisplay("Destination directory \"" + configDestDir + "\" from the config file is in valid, using default destination directory instead.");
							configDestDir = DefaultDestination;
						}
						break;
				}
			}
			catch (Exception ex)
			{
				WriteToDisplay("There was a problem attempting to retrieve the source directory location from the config file, using default instead.\r\nError Message: " + ex.Message);
				configDestDir = DefaultDestination;
			}
			tbDestination.Text = configDestDir;

		}

		private void UpdateConfigFile(string DirectoryType) 
		{
			if (DirectoryType == "SOURCE") 
			{
				try
				{
					Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

					if (Directory.Exists(tbSource.Text))
					{
						config.AppSettings.Settings.Remove("SourceDirectory");
						config.AppSettings.Settings.Add("SourceDirectory", tbSource.Text);
					}
					config.Save(ConfigurationSaveMode.Modified);
				}
				catch (Exception ex)
				{
					WriteToDisplay("There were problems updating the source directory in the config file. Changes were not saved.\r\nError Message: " + ex.Message);
				}

			}
			if (DirectoryType == "DESTINATION")
			{
				try
				{
					Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

					if (Directory.Exists(tbDestination.Text))
					{
						config.AppSettings.Settings.Remove("DestinationDirectory");
						config.AppSettings.Settings.Add("DestinationDirectory", tbDestination.Text);
					}

					config.Save(ConfigurationSaveMode.Modified);
				}
				catch (Exception ex)
				{
					WriteToDisplay("There were problems updating destination directory in the config file. Changes were not saved.\r\nError Message: " + ex.Message);
				}

			}

		}

		#endregion Configuration Methods

		#region Control Interactions

		private void btnChkForNew_Click(object sender, EventArgs e)
		{
			MainProcess();
		}

		private void btnOpenSrc_Click(object sender, EventArgs e)
		{
			string sourceDir = tbSource.Text;
			if (!Directory.Exists(sourceDir))
			{
				WriteToDisplay("Source directory does not exist.  Aborting.");
				return;
			}
			Process.Start(sourceDir);
		}

		private void btnOpenDest_Click(object sender, EventArgs e)
		{
			string destinationDir = tbDestination.Text;
			if (!Directory.Exists(destinationDir))
			{
				WriteToDisplay("Destination directory does not exist.  Aborting.");
				return;
			}
			Process.Start(destinationDir);
		}

		private void btnSourceSelect_Click(object sender, EventArgs e)
		{
			string currentSource = tbSource.Text;
			if (!Directory.Exists(currentSource))
			{
				currentSource = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			}
			CommonOpenFileDialog ofd = new CommonOpenFileDialog();
			ofd.IsFolderPicker = true;
			ofd.InitialDirectory = currentSource;
			CommonFileDialogResult result = ofd.ShowDialog();
			if (result != CommonFileDialogResult.Ok) { return; }
			if (!Directory.Exists(ofd.FileName)) { return; }
			tbSource.Text = ofd.FileName;
		}

		private void btnDestSelect_Click(object sender, EventArgs e)
		{
			string currentDestination = tbDestination.Text;
			if (!Directory.Exists(currentDestination))
			{
				currentDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			}
			CommonOpenFileDialog ofd = new CommonOpenFileDialog();
			ofd.IsFolderPicker = true;
			ofd.InitialDirectory = currentDestination;
			CommonFileDialogResult result = ofd.ShowDialog();
			if (result != CommonFileDialogResult.Ok) { return; }
			if (!Directory.Exists(ofd.FileName)) { return; }
			tbDestination.Text = ofd.FileName;
		}

		private void btnSetSourceDefault_Click(object sender, EventArgs e)
		{
			tbSource.Text = DefaultSource;
		}

		private void btnSetDestinationDefault_Click(object sender, EventArgs e)
		{
			tbDestination.Text = DefaultDestination;
		}

		private void btnSaveSourceConfig_Click(object sender, EventArgs e)
		{
			UpdateConfigFile("SOURCE");
		}

		private void btnSaveDestinationConfig_Click(object sender, EventArgs e)
		{
			UpdateConfigFile("DESTINATION");
		}

		#endregion Control Interactions

		#region Main Methods


		private void MainProcess() 
		{
			PortraitCount = 0;
			LandscapeCount = 0;
			TooSmallCount = 0;
			ErrorCount = 0;

			List<string> lsiFiles = Directory.GetFiles(SourceDir).ToList<string>();
			List<string> existingFiles = Directory.GetFiles(DestinationDir).ToList<string>();
			List<string> destinationFiles = new List<string>();

			foreach (string existing in existingFiles)
			{
				FileInfo fi = new FileInfo(existing);
				string existingNameOnly = fi.Name;
				if (!ImageFileTypes.Contains(fi.Extension)) { continue; }
				destinationFiles.Add(existingNameOnly);
			}

			foreach (string lFile in lsiFiles)
			{
				FileInfo fi = new FileInfo(lFile);
				string newName = fi.Name + ".jpg";
				string newFullPath = Path.Combine(DestinationDir, newName);




				ImageOrientation type = GetImageOrientation(lFile);

				if (type == ImageOrientation.TooSmall)
				{
					TooSmallCount++;
					continue;
				}

				if (type == ImageOrientation.Error)
				{
					ErrorCount++;
					continue;
				}

				if (type == ImageOrientation.Portrait)
				{
					string portraitName = Path.Combine(DestinationDir) + "\\Portrait\\" + newName;
					try
					{
						File.Copy(lFile, portraitName);
						PortraitCount++;
					}
					catch (Exception ex)
					{
						ErrorCount++;
						WriteToDisplay(ex.Message);
					}
				}
				if (type == ImageOrientation.Landscape)
				{
					string landscapeName = Path.Combine(DestinationDir) + "\\Landscape\\" + newName;
					try
					{
						File.Copy(lFile, landscapeName);
						LandscapeCount++;
					}
					catch (Exception ex)
					{
						ErrorCount++;
						WriteToDisplay(ex.Message);
					}
				}


			}


			string report = string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Total Landscape Images Found:\t" + LandscapeCount.ToString());
			sb.AppendLine("Total Portrait Images Found:\t" + PortraitCount.ToString());
			sb.AppendLine("Total Images found that were too small:\t" + TooSmallCount.ToString());
			sb.AppendLine("Total Errors:\t" + ErrorCount.ToString());
			report = sb.ToString();
			WriteToDisplay(report);



		}
		ImageOrientation GetImageOrientation(string FileName)
		{
			ImageOrientation output = ImageOrientation.Error;

			using (Bitmap img = new Bitmap(FileName))
			{
				int xPixels = img.Height;
				int yPixels = img.Width;
				if (xPixels < 500 && xPixels < 500) { return ImageOrientation.TooSmall; }
				if (xPixels == yPixels) { return ImageOrientation.Square; }
				if (xPixels > yPixels) { return ImageOrientation.Portrait; }
				if (xPixels < yPixels) { return ImageOrientation.Landscape; }


			}

			return output;
		}


		#endregion Main Methods

		#region Display Methods

		internal void WriteToDisplay(string MsgText)
		{
			string dispText = DateTime.Now.ToString("HH:mm:ss") + " -\t" + MsgText + "\r\n\r\n";
			tbDisplay.AppendText(dispText);
			tbDisplay.ScrollToCaret();
			Application.DoEvents();
		}

		#endregion

		#region Other Methods

		internal bool TestFile(string FileName)
		{
			bool output = false;

			using (Bitmap img = new Bitmap(FileName))
			{
				int xPixels = img.Height;
				int yPixels = img.Width;

				if (yPixels > 500 && yPixels > 500) { output = true; }

			}


			return output;
		}

		#endregion

		private void btnPopulateImages_Click(object sender, EventArgs e)
		{
			string[] images = Directory.GetFiles(tbDestination.Text,"*.*",SearchOption.AllDirectories);

			int imgLocationX = thumbnailStart;
			int imgLocationY = thumbnailStart;
			int tabIndex = 1;
			int imgNbr = 0;
			int panelWidth = imgPanel.Width;
			foreach (string img in images)
			{
				imgNbr++;
				PictureBox pb = new PictureBox();
				Label lb = new Label();

				FileInfo fi = new FileInfo(img);

				StringBuilder sb = new StringBuilder();
				sb.Append(Path.GetFileName(img));
				var pdq = fi.Length.ToString("N0");

				switch (fi.Length)
				{
					case long l when (l >= 0 && l < 999): //Bytes
						pdq = fi.Length.ToString() + " B";
						break;
					case long l when (l >= 1000 && l < 999999): //KiloBytes
						double kb = Convert.ToDouble(fi.Length / 1000);
						kb = Math.Round(kb, 1);
						pdq = kb.ToString() + " KB";
						break;
					case long l when (l >= 1000000 && l < 999999999): //MegaBytes
						double mb = Convert.ToDouble(fi.Length / 1000000);
						mb = Math.Round(mb, 1);
						pdq = mb.ToString() + " MB";
						break;
					case long l when (l >= 1000000000 && l < 999999999999): //GigaBytes
						double gb = Convert.ToDouble(fi.Length / 1000000000);
						gb = Math.Round(gb, 1);
						pdq = gb.ToString() + " GB";
						break;
					default:
						string fileSize = fi.Length.ToString("N0") + " B";
						break;
				}

				sb.Append(" " + pdq);

				lb.Text = sb.ToString();


				Bitmap bmImg = new Bitmap(img);



				int currentWidth = bmImg.Width;
				int currentHeight = bmImg.Height;

				double ratio = bmImg.Width / bmImg.Height;

				ImageOrientation orientation = GetImageOrientation(img);

				int newWidth = 0;
				int newHeight = 0;

				switch (orientation)
				{
					case ImageOrientation.Landscape:
						newWidth = thumbSize;
						newHeight = Convert.ToInt32(Math.Round(newWidth / ratio, 0));
						break;
					case ImageOrientation.Portrait:
						newWidth = thumbSize;
						newHeight = thumbSize;
						/*
						newHeight = thumbSize;
						newWidth = Convert.ToInt32(Math.Round(newHeight * ratio, 0));
						*/
						break;
					case ImageOrientation.Square:
						newWidth = thumbSize;
						newHeight = thumbSize;
						break;
					default:
						break;
				}

				//bmImg.Size = new Size(newWidth, newHeight);


				
				

				pb.Size = new Size(newWidth, newHeight);
				//pb.Image = bmImg.GetThumbnailImage(newWidth, newHeight
				pb.Image = bmImg;
				pb.SizeMode = PictureBoxSizeMode.StretchImage;

				WriteToDisplay("Adding " + Path.GetFileName(img));

				pb.SetOriginalFilePath(img);
				pb.SetImageOrientation(orientation);
				pb.SetNotes("");
				pb.BorderStyle = BorderStyle.FixedSingle;
				
				pb.Location = new Point(imgLocationX, imgLocationY);

				foreach (Control ctrl in this.Controls) 
				{
					try
					{
						int thisTabIndex = ctrl.TabIndex;
						if (thisTabIndex > tabIndex) { tabIndex = thisTabIndex + 1; }
					}
					catch (Exception ex)
					{
						WriteToDisplay("Error geting tab index on " + ctrl.Name + ": " + ex.Message);
					}
				}
				pb.Name = "pb" + imgNbr.ToString();
				pb.TabIndex = tabIndex;
				pb.TabStop = true;

				ToolTip tt = new ToolTip();
				tt.SetToolTip(pb, Path.GetFileName(img));

				pb.Click += new EventHandler(this.pb_Click);
				//pb.MouseHover += new System.EventHandler(this.pb_MouseHover);




				imgPanel.Controls.Add(pb);

				imgLocationX = imgLocationX + thumbSize + thumbnailXSpacing;
				if (imgLocationX > imgLocationX + thumbSize + thumbnailXSpacing) 
				{
					imgLocationX = thumbnailStart;
					imgLocationY = imgLocationY + thumbSize + thumbnailYSpacing;
				}




				/*


			this.pbSample.Location = new System.Drawing.Point(96, 78);
			this.pbSample.Name = "pbSample";
			this.pbSample.Size = new System.Drawing.Size(100, 100);
			this.pbSample.TabIndex = 0;
			this.pbSample.TabStop = false;



				*/





			}

			imgPanel.Refresh();
			Application.DoEvents();
		}


		private void pb_Click(object sender,EventArgs e) 
		{
			

			//string fileName = e
			//var pdq = sender.ToString();
			//WriteToDisplay("Sender: ");
			

		}


	}

	public enum ImageOrientation
	{ 
		Portrait,
		Landscape,
		Square,
		TooSmall,
		Error
	}

}
