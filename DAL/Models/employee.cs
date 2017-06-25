namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            messager = new HashSet<messager>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emplId { get; set; }

        [StringLength(255)]
        public string FIO { get; set; }

        public int? comandId { get; set; }

        public virtual comand comand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<messager> messager { get; set; }
    }
}
