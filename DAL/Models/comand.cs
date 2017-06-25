namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comand")]
    public partial class comand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comand()
        {
            employee = new HashSet<employee>();
            manager = new HashSet<manager>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int comandId { get; set; }

        public int? taskID { get; set; }

        public int? chatidID { get; set; }

        public int? adminID { get; set; }

        public virtual adminin adminin { get; set; }

        public virtual chat chat { get; set; }

        public virtual task task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<manager> manager { get; set; }
    }
}
