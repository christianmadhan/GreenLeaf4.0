namespace WAGreenLeaf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GreenLeafContext : DbContext
    {
        public GreenLeafContext()
            : base("name=GreenLeafContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Monitor> Monitor { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Particle)
                .IsUnicode(false);

            modelBuilder.Entity<Monitor>()
                .Property(e => e.Equipment)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
