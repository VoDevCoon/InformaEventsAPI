using System;

namespace InformaEventsAPI.ViewModels
{
    public class EventViewModelOverview
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string ShortDescription { get; set; }
        public string Overview { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public string MainCategory { get; set; }
    }
}