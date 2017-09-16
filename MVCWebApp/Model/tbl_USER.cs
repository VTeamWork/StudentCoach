namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_USER()
        {
            tbl_ANSWER = new HashSet<tbl_ANSWER>();
            tbl_QUESTION = new HashSet<tbl_QUESTION>();
            tbl_USER_ROLE = new HashSet<tbl_USER_ROLE>();
            TeamReviews = new HashSet<TeamReview>();
        }

        [Key]
        public int USER_ID { get; set; }

        [StringLength(50)]
        public string FIRST_NAME { get; set; }

        [StringLength(50)]
        public string LOGIN_ID { get; set; }

        [StringLength(512)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(20)]
        public string MOBILE_NO { get; set; }

        [StringLength(20)]
        public string PHONE_NUMBER_EXT { get; set; }

        [StringLength(50)]
        public string USER_TYPE { get; set; }

        public int? RETRY_COUNT { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(1)]
        public string IS_ACTIVE { get; set; }

        [StringLength(36)]
        public string UPDATE_ID { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_ON { get; set; }

        public DateTime? PWD_LASTUPDDATE { get; set; }

        public DateTime? PASSWORD_EXPIRYDATE { get; set; }

        public int? MAKE_ID { get; set; }

        [StringLength(100)]
        public string DEPT_NAME { get; set; }

        [StringLength(50)]
        public string USER_CLASS { get; set; }

        [StringLength(15)]
        public string CNIC { get; set; }

        [StringLength(50)]
        public string DESIGNATION { get; set; }

        [StringLength(20)]
        public string CITY { get; set; }

        [StringLength(50)]
        public string COUNTRY { get; set; }

        public DateTime? DATE_OF_BIRTH { get; set; }

        [StringLength(50)]
        public string MOTHER_MAIDEN_NAME { get; set; }

        public DateTime? LAST_LOGIN { get; set; }

        [StringLength(100)]
        public string EMPLOYEE_NO { get; set; }

        public int? USER_TYPE_ID { get; set; }

        public int? TEAM_ID { get; set; }

        [StringLength(50)]
        public string LAST_NAME { get; set; }

        [StringLength(1000)]
        public string COMMENTS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ENROLL_DATE { get; set; }

        [StringLength(50)]
        public string SKYPE_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ANSWER> tbl_ANSWER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_QUESTION> tbl_QUESTION { get; set; }

        public virtual tbl_TEAM tbl_TEAM { get; set; }

        public virtual tbl_USER_TYPE tbl_USER_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_USER_ROLE> tbl_USER_ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamReview> TeamReviews { get; set; }
    }
}
