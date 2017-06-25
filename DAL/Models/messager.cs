namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("messager")]
    public partial class messager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int messageId { get; set; }

        [StringLength(255)]
        public string text_s { get; set; }

        public int? chatId { get; set; }

        public int? sendId { get; set; }

        public int? data_ot { get; set; }

        public virtual chat chat { get; set; }

        public virtual employee employee { get; set; }
    }
}
