using Common.ApiModels.FoodModels;
using Homies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homies.ViewModels.FoodModels
{
    public class FoodDetailModel : PageModelBase
    {
        private FoodApiModel food;
        public FoodApiModel Food
        {
            get { return food; }
            set
            {
                food = value;
                OnPropertyChanged();
            }
        }



    }
}
