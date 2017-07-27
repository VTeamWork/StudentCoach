namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ROLE_PAGE
    {
        [Key]
        public int ROLE_PAGE_ID { get; set; }

        public int? ROLE_ID { get; set; }

        public int? PAGE_ID { get; set; }

        [StringLength(1)]
        public string CAN_ADD { get; set; }

        [StringLength(1)]
        public string CAN_EDIT { get; set; }

        [StringLength(1)]
        public string CAN_DELETE { get; set; }

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

        public virtual tbl_PAGE tbl_PAGE { get; set; }

        public virtual tbl_ROLE tbl_ROLE { get; set; }
    }
}
