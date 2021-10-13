using SafarTestWindow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafarTestWindow.Model
{
    public class PackageSearchModel:ViewModelBaseClass
    {
        private string source;

        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        private string destination;

        public string Destination
        {
            get { return destination; }
            set
            {
                destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        private bool isSearchButtonEnable;

        public bool IsSearchButtonEnable
        {
            get { return isSearchButtonEnable; }
            set
            {
                isSearchButtonEnable = value;
                OnPropertyChanged(nameof(IsSearchButtonEnable));
            }
        }

        public class City
        {
            public string Name;
            public string Pincode;
        }

        public class State
        {
            public string Name;
            public List<City> Cities;       
        }

        public class Country
        {
            public string Name;
            public List<State> States;
        }
    }
}
