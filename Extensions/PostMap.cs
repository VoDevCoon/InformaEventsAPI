using InformaEventsAPI.Core.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace InformaEventsAPI.Extensions
{
    public static class PostMap
    {
        public static ModelBuilder MapPost(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Post>();
            entity.ToTable("in_posts");
            entity.Property(p=>p.PostAuthor).HasColumnName("post_author");
            entity.Property(p=>p.PostDate).HasColumnName("post_date");
            entity.Property(p=>p.PostDateGMT).HasColumnName("post_date_gmt");
            entity.Property(p=>p.PostContent).HasColumnName("post_content");
            entity.Property(p=>p.PostTitle).HasColumnName("post_title");
            entity.Property(p=>p.PostExcerpt).HasColumnName("post_excerpt");
            entity.Property(p=>p.PostStatus).HasColumnName("post_status");
            entity.Property(p=>p.CommentStatus).HasColumnName("comment_status");
            entity.Property(p=>p.PingStatus).HasColumnName("ping_status");
            entity.Property(p=>p.PostPassword).HasColumnName("post_password");
            entity.Property(p=>p.PostName).HasColumnName("post_name");
            entity.Property(p=>p.ToPing).HasColumnName("to_ping");
            entity.Property(p=>p.Pinged).HasColumnName("pinged");
            entity.Property(p=>p.PostModified).HasColumnName("post_modified");
            entity.Property(p=>p.PostModifiedGMT).HasColumnName("post_modified_gmt");
            entity.Property(p=>p.PostContentFiltered).HasColumnName("post_content_filtered");
            entity.Property(p=>p.PostParent).HasColumnName("post_parent");
            entity.Property(p=>p.Guid).HasColumnName("guid");
            entity.Property(p=>p.MenuOrder).HasColumnName("menu_order");
            entity.Property(p=>p.PostType).HasColumnName("post_type");
            entity.Property(p=>p.PostMimeType).HasColumnName("post_mime_type");
            entity.Property(p=>p.CommentCount).HasColumnName("comment_count");

            return modelBuilder;
        }
    }
}