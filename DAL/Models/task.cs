namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("task")]
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            comand = new HashSet<comand>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int taskID { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        public int? date_start { get; set; }

        public int? date_end { get; set; }

        [StringLength(255)]
        public string checkList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comand> comand { get; set; }
    }
}
