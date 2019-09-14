namespace WebApplication2.Models.DOMAINModel.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        [StringLength(50)]
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public virtual Image Image { get; set; }
    }
}
