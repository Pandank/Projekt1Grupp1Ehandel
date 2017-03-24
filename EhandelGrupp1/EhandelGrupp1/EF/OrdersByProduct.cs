namespace EhandelGrupp1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersByProduct")]
    public partial class OrdersByProduct
    {
        [Key]
        public int obpId { get; set; }

        public int orderId { get; set; }

        public int productId { get; set; }

        public int count { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Product Product { get; set; }
    }
}
