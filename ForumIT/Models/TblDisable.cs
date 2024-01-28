using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumIT.Models
{
    public partial class TblDisable
    {
        [Key]
        public int? FkT2 { get; set; }
        public bool? Disable { get; set; }
        public DateTime? Logtime { get; set; }

        public virtual TblBaiViet? FkT2Navigation { get; set; }
    }
}
