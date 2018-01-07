namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.COUNTRIES")]
    public partial class COUNTRy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COUNTRy()
        {
            LOCATIONS = new HashSet<LOCATION>();
        }

        [Key]
        [StringLength(2)]
        public string COUNTRY_ID { get; set; }

        [StringLength(40)]
        public string COUNTRY_NAME { get; set; }

        public decimal? REGION_ID { get; set; }

        public virtual REGION REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONS { get; set; }
    }
}
