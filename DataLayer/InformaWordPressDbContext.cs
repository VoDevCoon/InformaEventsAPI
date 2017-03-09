using InformaEventsAPI.Core.EntityLayer;
using InformaEventsAPI.Extensions;
using Microsoft.EntityFrameworkCore;


namespace InformaEventsAPI.Core.DataLayer
{
    public class InformaWordPressDbContext : DbContext
    {
        public InformaWordPressDbContext(DbContextOptions<InformaWordPressDbContext> options):base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMeta> PostMeta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapPost();
            modelBuilder.MapPostMeta();

            base.OnModelCreating(modelBuilder);
        }
    }
}