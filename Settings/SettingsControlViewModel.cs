using System;

namespace GitHistory.Settings
{
    public class SettingsControlViewModel
    {
        public delegate void SaveClicked(object sender, EventArgs e);
        public event SaveClicked Saved;

        public SettingsControlViewModel()
        {
            Local = Properties.Settings.Default.LocalGit;
            Web = Properties.Settings.Default.WebLocation;
        }

        public string Web { get; set; }

        public string Local { get; set; }

        public void Save()
        {
            Properties.Settings.Default.LocalGit = Local ?? " " ;
            Properties.Settings.Default.WebLocation = Web ?? " ";
            Properties.Settings.Default.Save();
            if(Saved != null)
            {
                Saved(this, new EventArgs());
            }
           
        }

    }
}
