using System;
using System.Collections.Generic;

namespace InformaEventsAPI.Core.EntityLayer
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EventCode { get; set; }
        public string EventType { get; set; }
        public IEnumerable<EventCategory> EventCategory { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public int Duration { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public string ThumbnailUrl { get; set; }
        public IEnumerable<AgendaDay> AgendaDays { get; set; }
        public IEnumerable<Spex> Spex { get; set; }
    }
}