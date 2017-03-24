using System;
using System.Linq;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Core.EntityLayer;
using InformaEventsAPI.Extensions;

namespace InformaEventsAPI.Extensions
{
    public static class EventModelMapper
    {
        public static Event ToListEvent(this Post entity, IInformaEventsRepository repositoty)
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

                model.EventCategory = repositoty.GetPostCategory(entity.Id);

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

                int postId;
                var thumbnailPostId = entity.ThumbnailPostId;
                if(Int32.TryParse(thumbnailPostId, out postId))
                {
                    var thumbnailPost = repositoty.GetPost(postId);
                    model.ThumbnailUrl = thumbnailPost!=null?thumbnailPost.Guid:string.Empty; // TODO: change to use default images
                }
                else{
                    model.ThumbnailUrl = string.Empty; // TODO: change to use default images
                }

                return model;
            }

            return null;
        }
    }
}
