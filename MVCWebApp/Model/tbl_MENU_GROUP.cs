namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_MENU_GROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_MENU_GROUP()
        {
            tbl_PAGE = new HashSet<tbl_PAGE>();
        }

        [Key]
        public int MENU_GROUP_ID { get; set; }

        [StringLength(50)]
        public string MENU_GROUP_NAME { get; set; }

        public int? PARENT_MENU_GROUP_ID { get; set; }

        [StringLength(36)]
        public string UPDATE_ID { get; set; }

        public int? MENU_GROUP_SEQ { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_ON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_PAGE> tbl_PAGE { get; set; }
    }
}
