namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_QUESTION
    {
        [Key]
        public int QUESTION_ID { get; set; }

        [StringLength(1000)]
        public string QUESTION_NAME { get; set; }

        [StringLength(1000)]
        public string QUESTION_DESCRITION { get; set; }

        public int? USER_ID { get; set; }

        public int? MODULE_ID { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public int? USER_TYPE_ID { get; set; }

        public bool? IsRequired { get; set; }

        public virtual tbl_MODULE tbl_MODULE { get; set; }

        public virtual tbl_USER_TYPE tbl_USER_TYPE { get; set; }

        public virtual tbl_USER tbl_USER { get; set; }
    }
}
