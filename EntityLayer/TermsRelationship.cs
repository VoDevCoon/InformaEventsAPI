using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformaEventsAPI.Core.EntityLayer
{
    public class TermsRelationship
    {
        [Key]
        public int ObjectId { get; set; }
        public int TermTaxonomyId { get; set; }
        public int TermOrder { get; set; }
        [ForeignKey("ObjectId") ]
        public Post Post { get; set; }
    }
}