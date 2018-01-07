namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.LOCATIONS")]
    public partial class LOCATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOCATION()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LOCATION_ID { get; set; }

        [StringLength(40)]
        public string STREET_ADDRESS { get; set; }

        [StringLength(12)]
        public string POSTAL_CODE { get; set; }

        [Required]
        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(25)]
        public string STATE_PROVINCE { get; set; }

        [StringLength(2)]
        public string COUNTRY_ID { get; set; }

        public virtual COUNTRy COUNTRy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }
    }
}
