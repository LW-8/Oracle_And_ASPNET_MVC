namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.V_EMPLOYEES")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
            MANAGERS = new HashSet<EMPLOYEE>();
            JOB_HISTORY = new HashSet<JOB_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(25)]
        public string LAST_NAME { get; set; }

        [Required]
        [StringLength(25)]
        public string EMAIL { get; set; }

        [StringLength(20)]
        public string PHONE_NUMBER { get; set; }

        public DateTime HIRE_DATE { get; set; }

        [Required]
        [StringLength(10)]
        public string JOB_ID { get; set; }

        public decimal? SALARY { get; set; }

        public decimal? COMMISSION_PCT { get; set; }

        public int? MANAGER_ID { get; set; }

        public short? DEPARTMENT_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual JOB JOB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> MANAGERS { get; set; }

        public virtual EMPLOYEE MANAGER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB_HISTORY> JOB_HISTORY { get; set; }
    }
}
