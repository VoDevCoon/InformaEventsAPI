using System;
using InformaEventsAPI.Core.EntityLayer;
using InformaEventsAPI.ViewModels;
namespace InformaEventsAPI.Extensions
{
    public static class EventViewModelMapper
    {
        public static EventViewModelList ToViewModelEventList(this Event model)
        {
            if(model==null)
            {
                return null;
            }
            
            var viewModel = new EventViewModelList();

            viewModel.Id = model.Id;
            viewModel.EventName = model.Title;
            viewModel.City = model.City;
            viewModel.ShortDescription = model.ShortDescription;

            if(model.StartDate!=null)
            {
                var startDate = (DateTime)model.StartDate;
                viewModel.Date = string.Format("{0} - {1}", startDate.ToString("dd"), startDate.AddDays(model.Duration).ToString("dd MMM yyyy"));
            }
            else{
                viewModel.Date = string.Empty;
            }

            
            viewModel.ThumbnailUrl = model.ThumbnailUrl;

            viewModel.EventCategory = model.EventCategory;

            return viewModel;
        }
        public static EventViewModelOverview ToViewModelEventOverview(this Event model)
        {
            if(model==null)
            {
                return null;
            }
            
            var viewModel = new EventViewModelOverview();

            viewModel.Id = model.Id;
            viewModel.EventName = model.Title;
            viewModel.City = model.City;
            viewModel.Venue = model.Venue;
            viewModel.ShortDescription = model.ShortDescription;
            viewModel.Overview = model.LongDescription;
            //viewModel.StartDate = model.StartDate;
            viewModel.Duration = model.Duration;
            //viewModel.MainCategory = model.MainCategory;

            return viewModel;
        }
    }
}