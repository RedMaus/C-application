namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adminin")]
    public partial class adminin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public adminin()
        {
            comand = new HashSet<comand>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int adminId { get; set; }

        [StringLength(255)]
        public string FIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comand> comand { get; set; }
    }
}
