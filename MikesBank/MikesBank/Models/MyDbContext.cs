using Microsoft.EntityFrameworkCore;

namespace MikesBank.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Logging> Logging { get; set; }

        /// <summary>
        /// 职业分类表.
        /// </summary>
        /// <value>
        /// The professions.
        /// </value>
        public virtual DbSet<Profession> Professions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=MikesMilk;user id=sa;password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profession>().HasMany(s => s.SubCategory).WithOne(s => s.SupCategory).HasForeignKey(s => s.ParentId);

        }
    }
}
