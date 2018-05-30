namespace WAGreenLeaf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        public int TaskID { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TaskDate { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        public int? EmpID { get; set; }

        public int? StationID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Station Station { get; set; }
    }
}
