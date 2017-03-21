using System.ComponentModel.DataAnnotations;
namespace InformaEventsAPI.Core.EntityLayer
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int TermGroup { get; set; }
    }
}