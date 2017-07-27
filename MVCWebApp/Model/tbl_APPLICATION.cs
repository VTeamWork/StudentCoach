namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_APPLICATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_APPLICATION()
        {
            tbl_PAGE = new HashSet<tbl_PAGE>();
            tbl_ROLE = new HashSet<tbl_ROLE>();
        }

        [Key]
        public int APPLICATION_ID { get; set; }

        [StringLength(50)]
        public string APPLICATION_NAME { get; set; }

        [StringLength(300)]
        public string APPLICATION_DESC { get; set; }

        [StringLength(36)]
        public string UPDATE_ID { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PAGE> tbl_PAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ROLE> tbl_ROLE { get; set; }
    }
}
