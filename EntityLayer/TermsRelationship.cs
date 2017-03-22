using System.Collections.Generic;
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

        [ForeignKeyAttribute("TermTaxonomyId")]
        public IEnumerable<TermTaxonomy> TermTaxonomy { get; set; }

        [ForeignKeyAttribute("ObjectId")]
        public Post Post { get; set; }
    }
}