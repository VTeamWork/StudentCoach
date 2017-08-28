namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TEAM_MODULE
    {
        [Key]
        public int Team_module_id { get; set; }

        public int team_id { get; set; }

        public int module_id { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public virtual tbl_MODULE tbl_MODULE { get; set; }

        public virtual tbl_TEAM tbl_TEAM { get; set; }
    }
}
