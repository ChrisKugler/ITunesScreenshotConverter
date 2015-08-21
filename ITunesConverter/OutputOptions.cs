using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITunesConverter
{
    public class OutputOptions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool includeStatusBarArea;
        private bool hq;
        private bool landscape;
        private bool include35;
        private bool include4;
        private bool include47;
        private bool include55;
        private bool includeIPad;
        private bool includeMac;

        public bool IncludeStatusBarArea
        {
            get { return this.includeStatusBarArea; }
            set { if (this.includeStatusBarArea != value) { this.includeStatusBarArea = value; OnPropertyChanged("IncludeStatusBarArea"); } }
        }

        public bool HQ
        {
            get { return this.hq; }
            set { if (this.hq != value) { this.hq = value; OnPropertyChanged("HQ"); } }
        }

        public bool Landscape
        {
            get { return this.landscape; }
            set { if (this.landscape != value) { this.landscape = value; OnPropertyChanged("Landscape"); } }
        }
        
        public bool Include35
        {
            get { return this.include35; }
            set { if (this.include35 != value) { this.include35 = value; OnPropertyChanged("Include35"); } }
        }
        
        public bool Include4
        {
            get { return this.include4; }
            set { if (this.include4 != value) { this.include4 = value; OnPropertyChanged("Include4"); } }
        }      
  
        public bool Include47
        {
            get { return this.include47; }
            set { if (this.include47 != value) { this.include47 = value; OnPropertyChanged("Include47"); } }
        }
        
        public bool Include55
        {
            get { return this.include55; }
            set { if (this.include55 != value) { this.include55 = value; OnPropertyChanged("Include55"); } }
        }
        
        public bool IncludeIPad
        {
            get { return this.includeIPad; }
            set { if (this.includeIPad != value) { this.includeIPad = value; OnPropertyChanged("IncludeIPad"); } }
        }        

        public bool IncludeMac
        {
            get { return this.includeMac; }
            set { if (this.includeMac != value) { this.includeMac = value; OnPropertyChanged("IncludeMac"); } }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler h = this.PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(name));
        }
    }
}
