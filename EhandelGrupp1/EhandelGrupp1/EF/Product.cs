namespace EhandelGrupp1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CategoryToProduct = new HashSet<CategoryToProduct>();
            Image = new HashSet<Image>();
            OrdersByProduct = new HashSet<OrdersByProduct>();
        }

        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int stock { get; set; }

        public DateTime date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryToProduct> CategoryToProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersByProduct> OrdersByProduct { get; set; }
    }
}
