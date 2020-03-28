using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreShop.Data.Entyties
{
    [Table("Products")]
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCout { get; set; }
        public DateTime DateCreated { get; set; }
        public int SeoAlias { get; set; }
    }
}
