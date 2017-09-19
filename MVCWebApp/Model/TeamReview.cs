namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamReview")]
    public partial class TeamReview
    {
        public int TeamReviewID { get; set; }

        [StringLength(1000)]
        public string TeamReviewComment { get; set; }

        public int? TeamID { get; set; }

        public int? CoachID { get; set; }

        public virtual tbl_MODULE tbl_MODULE { get; set; }

        public virtual tbl_TEAM tbl_TEAM { get; set; }
    }
}
