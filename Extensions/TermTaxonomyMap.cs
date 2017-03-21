using InformaEventsAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace InformaEventsAPI.Extensions
{
    public static class TermTaxonomyMap
    {
        public static ModelBuilder MapTermTaxonomy(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TermTaxonomy>();

            entity.ToTable("in_term_taxonomy");
            entity.Property(c=>c.TermTaxonomyId).HasColumnName("term_taxonomy_id");
            entity.Property(c=>c.TermId).HasColumnName("term_id");
            entity.Property(c=>c.Taxonomy).HasColumnName("taxonomy");
            entity.Property(c=>c.Description).HasColumnName("description");
            entity.Property(c=>c.Parent).HasColumnName("parent");
            entity.Property(c=>c.Count).HasColumnName("count");

            return modelBuilder;
        }
    }
}