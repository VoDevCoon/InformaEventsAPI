
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformaEventsAPI.Core.EntityLayer
{
    public class TermTaxonomy
    {
        [Key]
        public int TermTaxonomyId { get; set; }
        public int TermId { get; set; }
        public string Taxonomy { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public int Count { get; set; }

        [ForeignKeyAttribute("TermTaxonomyId")]
        public TermsRelationship TermsRelationship { get; set; }
    }
}