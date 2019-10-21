using Homies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Homies.ViewModels.MainModels
{
    public class HomePageModel : PageModelBase
    {
        public HomePageModel()
        {
            this.Foods = new ObservableCollection<Common.ApiModels.FoodModels.FoodApiModel>();

        }
        public ObservableCollection<Common.ApiModels.FoodModels.FoodApiModel> Foods { get; set; }
    }
}
