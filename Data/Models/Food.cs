using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{

    public enum Currency
    {
        Dollars,
        Naira
    }

    public class Food : Base.BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Reciept { get; set; }

        public DateTime? LastDateSetAsMealOfTheDay { get; set; }

        public bool IsMealOfTheDay { get; set; }

        public bool CanFoodShowOnApp { get; set; }


        [Required]
        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<FoodPicture> Pictures { get; set; }
    }
}
