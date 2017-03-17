using System;
using System.Linq;
using InformaEventsAPI.Core.EntityLayer;
using InformaEventsAPI.Extensions;

namespace InformaEventsAPI.Extensions
{
    public static class EventModelMapper
    {
        public static Event ToEvent(this Post entity)
        {
            if(entity!=null)
            {
                var model = new Event();

                model.Id = entity.Id;
                model.Title = entity.PostTitle;
                model.EventCode = entity.PostMetas
                            .Where(pm=>pm.MetaKey.ToLower().Equals("event_code"))
                            .Select(pm=>pm.MetaValue)
                            .FirstOrDefault();

                model.EventType = entity.PostMetas
                            .Where(pm=>pm.MetaKey.ToLower().Equals("event_type"))
                            .Select(pm=>pm.MetaValue)
                            .FirstOrDefault();

                model.MainCategory = entity.PostMetas
                            .Where(pm=>pm.MetaKey.ToLower().Equals("_yoast_wpseo_primary_product_cat"))
                            .Select(pm=>pm.MetaValue)
                            .FirstOrDefault();

                model.City = entity.PostMetas
                            .Where(pm=>pm.MetaKey.ToLower().Equals("single_address_string"))
                            .Select(pm=>pm.MetaValue)
                            .FirstOrDefault();

                var unixTimeStamp = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("single_start_dates_sting"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();
                model.StartDate = unixTimeStamp.UnixTimeStampToDateTime();
                            
                model.ShortDescription = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("excerpt"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();
                model.LongDescription = entity.PostContent;
                
                var duration = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("duration"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();
                int durationNotSet;                        
                if(Int32.TryParse(duration, out durationNotSet))
                {
                    model.Duration = Int32.Parse(duration);
                }
                else{
                    model.Duration = durationNotSet;
                }

                model.ThumbnailUrl = entity.PostMetas
                                        .Where(pm=>pm.MetaKey.ToLower().Equals("_thumbnail_id"))
                                        .Select(pm=>pm.MetaValue)
                                        .FirstOrDefault();

                return model;
            }

            return null;
        }
    }
}
