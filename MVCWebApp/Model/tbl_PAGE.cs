namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PAGE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_PAGE()
        {
            tbl_ROLE_PAGE = new HashSet<tbl_ROLE_PAGE>();
        }

        [Key]
        public int PAGE_ID { get; set; }

        [StringLength(50)]
        public string PAGE_NAME { get; set; }

        [StringLength(250)]
        public string PAGE_PATH { get; set; }

        public int APPLICATION_ID { get; set; }

        public int? MENU_GROUP_ID { get; set; }

        [StringLength(50)]
        public string PAGE_TYPE { get; set; }

        [StringLength(36)]
        public string UPDATE_ID { get; set; }

        public int? PAGE_SEQ { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public virtual tbl_APPLICATION tbl_APPLICATION { get; set; }

        public virtual tbl_MENU_GROUP tbl_MENU_GROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ROLE_PAGE> tbl_ROLE_PAGE { get; set; }
    }
}
