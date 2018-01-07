namespace Oracle_And_ASPNET_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRModel : DbContext
    {
        public HRModel()
            : base("name=HRModel")
        {
        }

        public virtual DbSet<COUNTRy> COUNTRIES { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual DbSet<JOB_HISTORY> JOB_HISTORY { get; set; }
        public virtual DbSet<JOB> JOBS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<REGION> REGIONS { get; set; }
        public virtual DbSet<EMP_DETAILS_VIEW> EMP_DETAILS_VIEW { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.COUNTRY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRy>()
                .Property(e => e.REGION_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEPARTMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.EMPLOYEES)
                .WithOptional(e => e.DEPARTMENT)
                .HasForeignKey(e => e.DEPARTMENT_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.PHONE_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.SALARY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.COMMISSION_PCT)
                .HasPrecision(2, 2);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.MANAGERS)
                .WithOptional(e => e.MANAGER)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.EMPLOYEE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOB_HISTORY>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .Property(e => e.JOB_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<JOB>()
                .HasMany(e => e.EMPLOYEES)
                .WithRequired(e => e.JOB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOB>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.JOB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.STREET_ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.POSTAL_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.STATE_PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<LOCATION>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGION_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.JOB_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.COUNTRY_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.SALARY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.COMMISSION_PCT)
                .HasPrecision(2, 2);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.DEPARTMENT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.JOB_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.STATE_PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.COUNTRY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP_DETAILS_VIEW>()
                .Property(e => e.REGION_NAME)
                .IsUnicode(false);

            // packages generated in oracle sql developer
            modelBuilder
              .Entity<EMPLOYEE>()
              .MapToStoredProcedures(s =>
                s.Update(u => u.HasName("EMPLOYEES_TAPI.UPD")
                               .Parameter(b => b.JOB_ID, "p_JOB_ID")
                               .Parameter(b => b.EMPLOYEE_ID, "p_EMPLOYEE_ID")
                               .Parameter(b => b.SALARY, "p_SALARY")
                               .Parameter(b => b.HIRE_DATE, "p_HIRE_DATE")
                               .Parameter(b => b.DEPARTMENT_ID, "p_DEPARTMENT_ID")
                               .Parameter(b => b.LAST_NAME, "p_LAST_NAME")
                               .Parameter(b => b.EMAIL, "p_EMAIL")
                               .Parameter(b => b.PHONE_NUMBER, "p_PHONE_NUMBER")
                               .Parameter(b => b.FIRST_NAME, "p_FIRST_NAME")
                               .Parameter(b => b.COMMISSION_PCT, "p_COMMISSION_PCT")
                               .Parameter(b => b.MANAGER_ID, "p_MANAGER_ID"))
                 .Insert(u => u.HasName("EMPLOYEES_TAPI.INS")
                               .Parameter(b => b.JOB_ID, "p_JOB_ID")
                               .Parameter(b => b.EMPLOYEE_ID, "p_EMPLOYEE_ID")
                               .Parameter(b => b.SALARY, "p_SALARY")
                               .Parameter(b => b.HIRE_DATE, "p_HIRE_DATE")
                               .Parameter(b => b.DEPARTMENT_ID, "p_DEPARTMENT_ID")
                               .Parameter(b => b.LAST_NAME, "p_LAST_NAME")
                               .Parameter(b => b.EMAIL, "p_EMAIL")
                               .Parameter(b => b.PHONE_NUMBER, "p_PHONE_NUMBER")
                               .Parameter(b => b.FIRST_NAME, "p_FIRST_NAME")
                               .Parameter(b => b.COMMISSION_PCT, "p_COMMISSION_PCT")
                               .Parameter(b => b.MANAGER_ID, "p_MANAGER_ID"))
                               );



            //            p_JOB_ID IN EMPLOYEES.JOB_ID % type ,
            //      p_EMPLOYEE_ID IN EMPLOYEES.EMPLOYEE_ID % type ,
            //      p_SALARY IN EMPLOYEES.SALARY % type DEFAULT NULL,
            //p_HIRE_DATE      IN EMPLOYEES.HIRE_DATE % type ,
            //      p_DEPARTMENT_ID IN EMPLOYEES.DEPARTMENT_ID % type DEFAULT NULL,
            //       p_LAST_NAME      IN EMPLOYEES.LAST_NAME % type ,
            //      p_EMAIL IN EMPLOYEES.EMAIL % type ,
            //      p_PHONE_NUMBER IN EMPLOYEES.PHONE_NUMBER % type DEFAULT NULL,
            //      p_FIRST_NAME     IN EMPLOYEES.FIRST_NAME % type DEFAULT NULL,
            //        p_COMMISSION_PCT IN EMPLOYEES.COMMISSION_PCT % type DEFAULT NULL,
            //          p_MANAGER_ID     IN EMPLOYEES.MANAGER_ID % type DEFAULT NULL
        }
    }
}
