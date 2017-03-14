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
            entity.Property(p=>p.Id).HasColumnName("meta_id");
            entity.Property(p=>p.PostId).HasColumnName("post_id");
            entity.Property(p=>p.MetaKey).HasColumnName("meta_key");
            entity.Property(p=>p.MetaValue).HasColumnName("meta_value");

            return modelBuilder;
        }
    }
}