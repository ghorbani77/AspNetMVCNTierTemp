using System.Globalization;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Permission;

namespace MVC5.AutoMapperProfiles
{
    public class PermissionProfile:Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationPermission, SelectPermissionViewModel>().MaxDepth(1)
               .ForMember(s => s.Text, d => d.MapFrom(a => a.Name))
               .ForMember(s => s.Value, d => d.MapFrom(a => a.Id.ToString(CultureInfo.InvariantCulture)))
               .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }
}
