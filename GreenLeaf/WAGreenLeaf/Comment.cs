namespace WAGreenLeaf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentID { get; set; }

        [StringLength(30)]
        public string Description { get; set; }

        public int? StationID { get; set; }

        public virtual Station Station { get; set; }
    }
}
