using System;
using LibGit2Sharp;
using System.ComponentModel;

namespace GitHistory.Settings
{
    public class SettingsControlViewModel : IDataErrorInfo
    {
        public delegate void SaveClicked(object sender, EventArgs e);
        public event SaveClicked Saved;

        public SettingsControlViewModel()
        {
            local = Properties.Settings.Default.LocalGit;
            Web = Properties.Settings.Default.WebLocation;
        }

        public string Web { get; set; }


        private string local;
        public string Local { 
            get{return local;} 
            set{

           
               

                
         local = value; }
        }

        public void Save()
        {
            Properties.Settings.Default.LocalGit = Local ?? " " ;
            Properties.Settings.Default.WebLocation = Web ?? " ";
            Properties.Settings.Default.Save();

            var repo = Repository.Init(Local ?? " ");
            if (!repo.Info.IsEmpty)
            {
                if(Saved != null)
                            {
                                Saved(this, new EventArgs());
                            }
            }
            
           
        }


        public string Error
        {
            get { return null; }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "Local")
                {
                    var repo = Repository.Init(Local ?? " ");
                    if (repo.Info.IsEmpty)
                    {
                        result = "Not a valid repository";

                    }
                }
                return result;
            }
        }
    }
}
