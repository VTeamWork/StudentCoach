namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ANSWER
    {
        [Key]
        public int ANSWER_ID { get; set; }

        [StringLength(100)]
        public string ANSWER_NAME { get; set; }

        [StringLength(1000)]
        public string ANSWER_DESCRITION { get; set; }

        public int? QUESTION_ID { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_ON { get; set; }

        [StringLength(50)]
        public string UPDATED_BY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UPDATED_ON { get; set; }

        public int? USER_ID { get; set; }

        public int? COACH_ID { get; set; }

        public virtual tbl_USER tbl_USER { get; set; }

        public virtual tbl_USER tbl_USER1 { get; set; }
    }
}
