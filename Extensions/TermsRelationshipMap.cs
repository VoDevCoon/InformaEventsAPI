using InformaEventsAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace InformaEventsAPI.Extensions
{
    public static class TermRelationshipMap
    {
        public static ModelBuilder MapTermRelationship(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TermsRelationship>();

            entity.ToTable("in_term_relationships");
            entity.Property(c=>c.ObjectId).HasColumnName("object_id");
            entity.Property(c=>c.TermTaxonomyId).HasColumnName("term_taxonomy_id");
            entity.Property(c=>c.TermOrder).HasColumnName("term_order");

            return modelBuilder;
        }
    }
}