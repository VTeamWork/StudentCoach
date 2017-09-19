namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_MODULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_MODULE()
        {
            tbl_QUESTION = new HashSet<tbl_QUESTION>();
            tbl_MODULE1 = new HashSet<tbl_MODULE>();
            tbl_TEAM_MODULE = new HashSet<tbl_TEAM_MODULE>();
            TeamReviews = new HashSet<TeamReview>();
        }

        [Key]
        public int MODULE_ID { get; set; }

        [StringLength(1000)]
        public string MODULE_NAME { get; set; }

        [StringLength(1000)]
        public string MODULE_DESCRITION { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public int? PARENT_MODULE_ID { get; set; }

        [StringLength(1)]
        public string IS_DEFAULT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_QUESTION> tbl_QUESTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_MODULE> tbl_MODULE1 { get; set; }

        public virtual tbl_MODULE tbl_MODULE2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_TEAM_MODULE> tbl_TEAM_MODULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamReview> TeamReviews { get; set; }
    }
}
