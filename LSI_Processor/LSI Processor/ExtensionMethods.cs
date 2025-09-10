using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;

namespace LSI_Processor
{

	public static class PictureBoxExtensions
	{
		// Internal storage for the Notes property
		private static readonly ConditionalWeakTable<PictureBox, PictureBoxData> _data =
			new ConditionalWeakTable<PictureBox, PictureBoxData>();

		// Class to hold additional data
		private class PictureBoxData
		{
			public string Notes { get; set; }
			public ImageOrientation Orientation { get; set; }
			public string OriginalFilePath { get; set; }
		}

		// Extension method to set Notes
		public static void SetNotes(this PictureBox pictureBox, string notes)
		{
			var data = _data.GetOrCreateValue(pictureBox);
			data.Notes = notes;
		}

		// Extension method to get Notes
		public static string GetNotes(this PictureBox pictureBox)
		{
			return _data.TryGetValue(pictureBox, out var data) ? data.Notes : null;
		}


		public static void SetOriginalFilePath(this PictureBox pictureBox, string FilePath) 
		{
			var data = _data.GetOrCreateValue(pictureBox);
			data.OriginalFilePath = FilePath;
		}

		public static string GetOriginalFilePath(this PictureBox pictureBox) 
		{
			return _data.TryGetValue(pictureBox, out var data) ? data.OriginalFilePath : null;
		}

		public static void SetImageOrientation(this PictureBox pictureBox, ImageOrientation orientation) 
		{
			var data = _data.GetOrCreateValue(pictureBox);
			data.Orientation = orientation;
		}

		public static string GetOriginalOrientation(this PictureBox pictureBox)
		{
			return _data.TryGetValue(pictureBox, out var data) ? data.Orientation.ToString() : null;
		}




	}



}
