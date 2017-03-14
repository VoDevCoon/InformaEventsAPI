using System;
using System.Linq;
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
                Id = entity.Id,
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
        public static EventViewModelOverview ToViewModelEventOverview(this Post entity)
        {
            if(entity!=null)
            {
                var viewModel = new EventViewModelOverview();

                viewModel.Id = entity.Id;
                viewModel.EventName = entity.PostTitle;
                viewModel.ShortDescription = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("excerpt"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();
                viewModel.Overview = entity.PostContent;

                var unixTimeStamp = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("single_start_dates_sting"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();
                viewModel.StartDate = unixTimeStamp.UnixTimeStampToDateTime();
                viewModel.Duration = Int32.Parse(entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("duration"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault());

                return viewModel;
            }

            return null;
        }

        public static DateTime UnixTimeStampToDateTime(this string timestamp)
        {
            double dTimeStamp;

            if(!string.IsNullOrEmpty(timestamp)&&Double.TryParse(timestamp, out dTimeStamp))
            {          
                return new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc).AddSeconds(dTimeStamp).ToLocalTime();
            }

            return default(DateTime);
        }
    }
}