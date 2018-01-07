namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.REGIONS")]
    public partial class REGION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REGION()
        {
            COUNTRIES = new HashSet<COUNTRy>();
        }

        [Key]
        public decimal REGION_ID { get; set; }

        [StringLength(25)]
        public string REGION_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COUNTRy> COUNTRIES { get; set; }
    }
}
