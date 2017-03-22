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
            entity.Property(c=>c.PostAuthor).HasColumnName("post_author");
            entity.Property(c=>c.PostDate).HasColumnName("post_date");
            entity.Property(c=>c.PostDateGMT).HasColumnName("post_date_gmt");
            entity.Property(c=>c.PostContent).HasColumnName("post_content");
            entity.Property(c=>c.PostTitle).HasColumnName("post_title");
            entity.Property(c=>c.PostExcerpt).HasColumnName("post_excerpt");
            entity.Property(c=>c.PostStatus).HasColumnName("post_status");
            entity.Property(c=>c.CommentStatus).HasColumnName("comment_status");
            entity.Property(c=>c.PingStatus).HasColumnName("ping_status");
            entity.Property(c=>c.PostPassword).HasColumnName("post_password");
            entity.Property(c=>c.PostName).HasColumnName("post_name");
            entity.Property(c=>c.ToPing).HasColumnName("to_ping");
            entity.Property(c=>c.Pinged).HasColumnName("pinged");
            entity.Property(c=>c.PostModified).HasColumnName("post_modified");
            entity.Property(c=>c.PostModifiedGMT).HasColumnName("post_modified_gmt");
            entity.Property(c=>c.PostContentFiltered).HasColumnName("post_content_filtered");
            entity.Property(c=>c.PostParent).HasColumnName("post_parent");
            entity.Property(c=>c.Guid).HasColumnName("guid");
            entity.Property(c=>c.MenuOrder).HasColumnName("menu_order");
            entity.Property(c=>c.PostType).HasColumnName("post_type");
            entity.Property(c=>c.PostMimeType).HasColumnName("post_mime_type");
            entity.Property(c=>c.CommentCount).HasColumnName("comment_count");

            entity.Ignore(c=>c.ThumbnailPostId);

            return modelBuilder;
        }
    }
}