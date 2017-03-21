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
        public DbSet<PostMeta> PostMetas { get; set; }
        public DbSet<TermsRelationship> TermsRelationships { get; set; }
        public DbSet<TermTaxonomy> TermTaxonomies { get; set; }
        public DbSet<Term> Terms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapPost();
            modelBuilder.MapPostMeta();
            modelBuilder.MapTerm();
            modelBuilder.MapTermRelationship();
            modelBuilder.MapTermTaxonomy();

            base.OnModelCreating(modelBuilder);
        }
    }
}