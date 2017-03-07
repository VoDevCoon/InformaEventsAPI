using InformaEventsAPI.Core.EntityLayer;
using InformaEventsAPI.ViewModels;
namespace InformaEventsAPI.Extensions
{
    public static class EventViewModelMapper
    {
        public static EventViewModel ToViewModel(this Event entity)
        {
            return entity == null ? null : new EventViewModel
            {
                ID = entity.ID,
                EventName = entity.Title,
                ShortDescription = entity.ShortDescription,
                Overview = entity.LongDescription,
                StartDate = entity.StartDate,
                Duration = entity.Duration,
                City = entity.City,
                Venue = entity.Venue,
                MainCategory = entity.MainCategory
            };
        }
    }
}