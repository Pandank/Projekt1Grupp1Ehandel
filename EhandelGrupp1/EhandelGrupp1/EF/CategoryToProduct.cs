namespace EhandelGrupp1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryToProduct")]
    public partial class CategoryToProduct
    {
        [Key]
        public int ctpId { get; set; }

        public int categoryId { get; set; }

        public int productId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
