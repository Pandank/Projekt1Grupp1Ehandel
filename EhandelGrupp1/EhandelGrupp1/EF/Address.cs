namespace EhandelGrupp1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        public int addressId { get; set; }

        [Required]
        [StringLength(50)]
        public string street { get; set; }

        [Required]
        [StringLength(50)]
        public string zip { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        public int userId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
