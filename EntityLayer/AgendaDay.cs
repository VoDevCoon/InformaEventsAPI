using System;
using System.Collections.Generic;

namespace InformaEventsAPI.Core.EntityLayer
{
    public class AgendaDay
    {
        public int Id { get; set; }
        public string DayTitle { get; set; }
        public DateTime AgendaDate { get; set; }
        public IEnumerable<AgendaSession> AgendaSessions { get; set; }
    }
}