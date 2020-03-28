using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ScoreShop.Data.Entyties
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public string ParentId { get; set; }
        public int Status { get; set; }
    }
}
