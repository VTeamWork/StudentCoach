namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoachTeam")]
    public partial class CoachTeam
    {
        [Key]
        public int Coach_Team_ID { get; set; }

        public int Coach_ID { get; set; }

        public int Team_ID { get; set; }

        public virtual tbl_USER tbl_USER { get; set; }

        public virtual tbl_TEAM tbl_TEAM { get; set; }
    }
}
