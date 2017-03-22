using System.Collections.Generic;
using InformaEventsAPI.Core.EntityLayer;

namespace InformaEventsAPI.ViewModels
{
    public class EventViewModelList
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string ShortDescription { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string ThumbnailUrl { get; set; }
        public IEnumerable<EventCategory> EventCategory { get; set; }
    }
}