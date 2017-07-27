namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ROLE()
        {
            tbl_ROLE_PAGE = new HashSet<tbl_ROLE_PAGE>();
            tbl_ROLE_RESTRICT = new HashSet<tbl_ROLE_RESTRICT>();
            tbl_USER_ROLE = new HashSet<tbl_USER_ROLE>();
        }

        [Key]
        public int ROLE_ID { get; set; }

        [StringLength(50)]
        public string ROLE_NAME { get; set; }

        [StringLength(300)]
        public string ROLE_DESC { get; set; }

        public int APPLICATION_ID { get; set; }

        public int? MANAGER_ROLE_ID { get; set; }

        [StringLength(1)]
        public string IS_DELETED { get; set; }

        [StringLength(36)]
        public string UPDATE_ID { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public int? MAKE_ID { get; set; }

        public virtual tbl_APPLICATION tbl_APPLICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ROLE_PAGE> tbl_ROLE_PAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ROLE_RESTRICT> tbl_ROLE_RESTRICT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_USER_ROLE> tbl_USER_ROLE { get; set; }
    }
}
