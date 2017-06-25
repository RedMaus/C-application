namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("manager")]
    public partial class manager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int managerId { get; set; }

        [StringLength(255)]
        public string FIO { get; set; }

        public int? comandId { get; set; }

        public virtual comand comand { get; set; }
    }
}
