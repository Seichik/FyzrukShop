namespace WebApplication2.Models.DOMAINModel.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public byte[] MainImage { get; set; }

        public byte[] ListImage { get; set; }

        public byte[] CartImage { get; set; }

        [StringLength(20)]
        public string ImageType { get; set; }

        public virtual Item Item { get; set; }
    }

    public partial class Image
    {
        public enum ImageKind { Main = 1, List, Cart }

        public byte[] Get(ImageKind imageKind)
        {
            switch(imageKind)
            {
                case ImageKind.Main:
                    return MainImage;
                case ImageKind.List:
                    return ListImage;
                case ImageKind.Cart:
                    return CartImage;
                default:
                    return null;
            }
        }
    }
}
