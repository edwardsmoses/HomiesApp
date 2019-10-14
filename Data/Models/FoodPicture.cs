using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class FoodPicture : Base.BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string OriginalFileName { get; set; }

        public long Length { get; set; }

        public string ContentType { get; set; }

        public Guid FoodId { get; set; }

        public virtual Food Food { get; set; }
    }
}