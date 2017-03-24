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
                if(DateTime.Compare(model.StartDate, DateTime.Now.AddYears(50))<0){
                    viewModel.Date = string.Format("{0} - {1}", 
                                        model.StartDate.ToString("dd"), 
                                        model.StartDate.AddDays(model.Duration).ToString("dd MMM yyyy"));
                }
                else{
                    viewModel.Date = "Dates yet to be announced";
                }
            }
            else{
                viewModel.Date = "Dates yet to be announced";
            }
       
            viewModel.ThumbnailUrl = model.ThumbnailUrl;

            viewModel.EventCategory = model.EventCategory;

            return viewModel;
        }
        public static EventViewModelOverview ToViewModelEventDetail(this Event model)
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