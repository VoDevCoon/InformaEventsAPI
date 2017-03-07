namespace InformaEventsAPI.Core.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string MainCategory { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}