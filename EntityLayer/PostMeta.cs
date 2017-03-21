using System.ComponentModel.DataAnnotations.Schema;
namespace InformaEventsAPI.Core.EntityLayer
{
    public class PostMeta
    {
        public int Id { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        [ForeignKey("PostId") ]
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}