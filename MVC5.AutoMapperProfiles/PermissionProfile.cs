using System.Globalization;
using System.Web.Mvc;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Permission;

namespace MVC5.AutoMapperProfiles
{
    public class PermissionProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationPermission, SelectListItem>()
                .ForMember(d => d.Text, m => m.MapFrom(s => s.Name))
                  .ForMember(d => d.Value, m => m.MapFrom(s => s.Id))
                .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }
}
