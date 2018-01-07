namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.JOBS")]
    public partial class JOB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOB()
        {
            EMPLOYEES = new HashSet<EMPLOYEE>();
            JOB_HISTORY = new HashSet<JOB_HISTORY>();
        }

        [Key]
        [StringLength(10)]
        public string JOB_ID { get; set; }

        [Required]
        [StringLength(35)]
        public string JOB_TITLE { get; set; }

        public int? MIN_SALARY { get; set; }

        public int? MAX_SALARY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB_HISTORY> JOB_HISTORY { get; set; }
    }
}
