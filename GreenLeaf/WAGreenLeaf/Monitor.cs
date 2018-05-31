namespace WAGreenLeaf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Monitor")]
    public partial class Monitor
    {
        public int MonitorID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Particle { get; set; }

        [StringLength(30)]
        public string Equipment { get; set; }

        public int? StationID { get; set; }

        public virtual Station Station { get; set; }
    }
}
