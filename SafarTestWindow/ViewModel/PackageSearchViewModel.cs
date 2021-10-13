using SafarTestWindow.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SafarTestWindow.Model.PackageSearchModel;

namespace SafarTestWindow.ViewModel
{
    public class PackageSearchViewModel : ViewModelBaseClass
    {
        public PackageSearchModel Model;
        public ObservableCollection<string> Source { get; set; }
        public ObservableCollection<string> Destination { get; set; }
        public ObservableCollection<Country> Country { get; set; }

        public PackageSearchViewModel()
        {
            Model = new PackageSearchModel();
            LoadCountryCollection();
        }

        public void LoadSourceCollection()
        {
            Source.Add("Delhi");
            Source.Add("Mumbai");
        }

        public void LoadDestinationCollection()
        {
            Destination.Add("Delhi");
            Destination.Add("Mumbai");
        }

        public void LoadCountryCollection()
        {
            Country = new ObservableCollection<Country>();
            Country.Add(new PackageSearchModel.Country
            {
                Name = "India",
                States = new List<State>()
                {
                    new State
                    {
                        Name = "Delhi",
                        Cities = new List<City>()
                        {
                            new City
                            {
                                Name = "New Delhi",
                                Pincode = "110094"
                            },
                            new City
                            {
                                Name = "Chadani Chauk",
                                Pincode = "110008"
                            }
                        }
                    },
                    new State
                    {
                        Name = "Chennai",
                        Cities = new List<City>()
                        {
                            new City
                            {
                                Name = "Ambattur",
                                Pincode = "600053"
                            },
                            new City
                            {
                                Name = "Triplicane",
                                Pincode = "600005"
                            }
                        }
                    }
                }
            });
        }
    }
}
