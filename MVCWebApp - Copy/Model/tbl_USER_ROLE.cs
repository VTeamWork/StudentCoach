namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_USER_ROLE
    {
        [Key]
        public int USER_ROLE_ID { get; set; }

        public int? ROLE_ID { get; set; }

        public int? USER_ID { get; set; }

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

        public virtual tbl_ROLE tbl_ROLE { get; set; }

        public virtual tbl_USER tbl_USER { get; set; }
    }
}
