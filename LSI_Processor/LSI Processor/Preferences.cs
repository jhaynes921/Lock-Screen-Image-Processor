using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Newtonsoft.Json;

namespace LSI_Processor
{
	internal class Preferences
	{
		public string SourceDirectory { get; set; }
		public string DestinationDirectory { get; set; }

		public Preferences() 
		{
			//OpenPreferencesDataFile();
		}



	}

	internal class PreferencesProcessor 
	{
		public Preferences PrefData { get; set; }
		string PreferencesFileName = "Preferences.dat";
		public string DefaultSourceLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
		public string DefaultDestinationLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\LSI";

		public void OpenPreferencesDataFile()
		{
			Preferences prefs = new Preferences();
			if (!File.Exists(PreferencesFileName))
			{
				File.Create(PreferencesFileName);
				prefs.SourceDirectory = DefaultSourceLocation;
				prefs.DestinationDirectory = DefaultDestinationLocation;

				string prefsJson = JsonConvert.SerializeObject(prefs);
				try
				{
					using (StreamWriter sw = new StreamWriter(PreferencesFileName))
					{
						sw.Write(prefsJson);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		public void SavePreferencesDataFile() { }

	}

}
