using ITunesConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ITunesConverterDesktop
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string sourceDir;
        private string destDir;

        public string SourceDir
        {
            get { return this.sourceDir; }
            set { if (this.sourceDir != value) { this.sourceDir = value; OnPropertyChanged("SourceDir"); } }
        }        

        public string DestDir
        {
            get { return this.destDir; }
            set { if (this.destDir != value) { this.destDir = value; OnPropertyChanged("DestDir"); } }
        }                

        public RelayCommand SourceDirBrowse { get; private set; }
        public RelayCommand DestDirBrowse { get; private set; }
        public RelayCommand ProcessImages { get; private set; }

        public VM()
        {
            this.SourceDirBrowse = new RelayCommand(OnBrowseForSourceDirectory);
            this.DestDirBrowse = new RelayCommand(OnBrowseForDestDirectory);
            this.ProcessImages = new RelayCommand(OnProcessImages);

            this.PropertyChanged += VM_PropertyChanged;
        }

        void VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "SourceDir":
                    if (!string.IsNullOrWhiteSpace(this.SourceDir) && string.IsNullOrWhiteSpace(this.DestDir))
                        this.DestDir = Path.Combine(this.SourceDir, "Output"); 
                    break;
                case "DestDir":
                    break;
            }
        }

        private void OnProcessImages(object obj)
        {
            try
            {
                Converter converter = new Converter();
                converter.SourceDir = this.SourceDir;
                converter.DestDir = this.DestDir;
                converter.Convert();
                System.Windows.MessageBox.Show("Conversion Complete!", "Finished");
                Process.Start(this.DestDir); 
            }
            catch (ArgumentException aex)
            {
                System.Windows.MessageBox.Show(string.Format("Missing Information: {0}", aex.Message), "Error"); 
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(string.Format("Unknown Error: {0}", ex.Message), "Error");
            }
        }

        private void OnBrowseForDestDirectory(object obj)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.DestDir = dlg.SelectedPath; 
                }
            }
        }

        private void OnBrowseForSourceDirectory(object obj)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.SourceDir = dlg.SelectedPath;
                    if (string.IsNullOrWhiteSpace(this.DestDir))
                        this.DestDir = Path.Combine(this.SourceDir, "Output"); 
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(name));
        }
    }
}
