using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PDQ = Microsoft.WindowsAPICodePack.Dialogs;

namespace LSI_Processor
{
	public partial class frmMain : Form
	{

		internal string SourceDir;
		internal string DestinationDir;
		internal string[] ImageFileTypes = new string[] { ".jpg", ".jpeg", ".png" };
		internal int PortraitCount = 0;
		internal int LandscapeCount = 0;
		internal int TooSmallCount = 0;
		internal int ErrorCount = 0;

		internal Preferences Prefs;

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

		private void btnChkForNew_Click(object sender, EventArgs e)
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
				if (!ImageFileTypes.Contains(fi.Extension))	{ continue; }
				destinationFiles.Add(existingNameOnly);
			}

			foreach (string lFile in lsiFiles)
			{
				FileInfo fi = new FileInfo(lFile);
				string newName = fi.Name + ".jpg";
				string newFullPath = Path.Combine(DestinationDir, newName);




				FileType type = GetFileType(lFile);

				if (type == FileType.TooSmall) 
				{
					TooSmallCount++;
					continue; 
				}

				if (type == FileType.Error)
				{
					ErrorCount++;
					continue;
				}

				if (type == FileType.Portrait) 
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
				if (type == FileType.Landscape)
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

		FileType GetFileType(string FileName)
		{
			FileType output = FileType.Error;

			using (Bitmap img = new Bitmap(FileName))
			{
				int xPixels = img.Height;
				int yPixels = img.Width;
				if (xPixels < 500 && xPixels < 500) { return FileType.TooSmall; }
				if(xPixels == yPixels) { return FileType.Square; }
				if(xPixels > yPixels) { return FileType.Portrait; }
				if(xPixels < yPixels) { return FileType.Landscape; }
				

			}

			return output;
		}


		internal void WriteToDisplay(string MsgText) 
		{
			string dispText = DateTime.Now.ToString("HH:mm:ss") + " -\t" + MsgText + "\r\n\r\n" ;
			tbDisplay.AppendText(dispText);
			tbDisplay.ScrollToCaret();
			Application.DoEvents();
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			PDQ.CommonOpenFileDialog ofd = new PDQ.CommonOpenFileDialog();
			ofd.IsFolderPicker = true;
			
			
		}
		//%appdata%\Local\packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets
		//C:\Users\henry\AppData\Local\packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets
	}

	internal enum FileType
	{ 
		Portrait,
		Landscape,
		Square,
		TooSmall,
		Error
	}

}
