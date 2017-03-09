using System;

namespace InformaEventsAPI.Core.EntityLayer
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainCategory { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}