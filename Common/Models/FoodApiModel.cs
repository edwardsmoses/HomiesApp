using System;

namespace Common.Models
{
    public class FoodApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }
        public string CategoryName { get; set; }
        public string PicturePath { get; set; }
    }
}
