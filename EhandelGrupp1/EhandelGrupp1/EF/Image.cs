namespace EhandelGrupp1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int imageId { get; set; }

        [Required]
        [StringLength(200)]
        public string url { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int productId { get; set; }

        public virtual Product Product { get; set; }
    }
}
