namespace InformaEventsAPI.Core.EntityLayer
{
    public class EventCategory
    {
        public int Id { get; set; }
        public int WPTermId { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public int CategoryEventCount { get; set; }
    }
}