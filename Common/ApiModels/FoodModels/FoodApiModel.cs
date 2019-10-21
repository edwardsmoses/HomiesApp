using System;
using System.Collections.Generic;

namespace Common.ApiModels.FoodModels
{
    public class FoodApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string PriceInCurrency
        {
            get
            {
                return $"{this.Currency} {string.Format("N:0", this.Price)}";
            }
        }

        public decimal Price { get; set; }

        public string Currency { get; set; }
        public string CategoryName { get; set; }
        public string PicturePath { get; set; }
        public List<string> Pictures { get; set; }
    }
}
