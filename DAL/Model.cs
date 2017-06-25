
namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelProject")
        {
        }

        public virtual DbSet<adminin> adminin { get; set; }
        public virtual DbSet<chat> chat { get; set; }
        public virtual DbSet<comand> comand { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<manager> manager { get; set; }
        public virtual DbSet<messager> messager { get; set; }
        public virtual DbSet<task> task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adminin>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<chat>()
                .Property(e => e.namechat)
                .IsUnicode(false);

            modelBuilder.Entity<chat>()
                .HasMany(e => e.comand)
                .WithOptional(e => e.chat)
                .HasForeignKey(e => e.chatidID);

            modelBuilder.Entity<employee>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.messager)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.sendId);

            modelBuilder.Entity<manager>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<messager>()
                .Property(e => e.text_s)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.checkList)
                .IsUnicode(false);
        }
    }
}
