using System.ComponentModel.DataAnnotations;
namespace InformaEventsAPI.Core.EntityLayer
{
    public class TermsRelationship
    {
        [Key]
        public int ObjectId { get; set; }
        public int TermTaxonomyId { get; set; }
        public int TermOrder { get; set; }
    }
}