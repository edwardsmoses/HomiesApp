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
                return $"{this.CurrencySymbol} {string.Format("{0:n}", this.Price)}";
            }
        }

        public decimal Price { get; set; }
        public string CurrencySymbol
        {
            get
            {
                if (this.Currency == "Naira")
                    return "NGN";
                else
                    return "$";
            }
        }

        public string Currency { get; set; }
        public string CategoryName { get; set; }
        public string PictureUrl { get; set; }

        public string FullPictureUrl
        {
            get
            {
                return $"{Common.ApiConstants.OnlineHomiesUrl}/{Common.ApiConstants.HomiesPicturePath}/{this.PictureUrl}";
            }
        }

        public List<string> Pictures { get; set; }
    }
}
