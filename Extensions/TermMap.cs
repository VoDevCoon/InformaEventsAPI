using InformaEventsAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace InformaEventsAPI.Extensions
{
    public static class TermMap
    {
        public static ModelBuilder MapTerm(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Term>();

            entity.ToTable("in_terms");
            entity.Property(c=>c.TermId).HasColumnName("term_id");
            entity.Property(c=>c.Name).HasColumnName("name");
            entity.Property(c=>c.Slug).HasColumnName("slug");
            entity.Property(c=>c.TermGroup).HasColumnName("term_group");

            return modelBuilder;
        }
    }
}