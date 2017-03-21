using InformaEventsAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace InformaEventsAPI.Extensions
{
    public static class PostMetaMap
    {
        public static ModelBuilder MapPostMeta(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PostMeta>();

            entity.ToTable("in_postmeta");
            entity.Property(c=>c.Id).HasColumnName("meta_id");
            entity.Property(c=>c.PostId).HasColumnName("post_id");
            entity.Property(c=>c.MetaKey).HasColumnName("meta_key");
            entity.Property(c=>c.MetaValue).HasColumnName("meta_value");

            return modelBuilder;
        }
    }
}