using System.Web.Mvc;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Role;

namespace MVC5.AutoMapperProfiles
{
    public class RoleProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationRole, RoleViewModel>();
            CreateMap<AddRoleViewModel, ApplicationRole>().IgnoreAllNonExisting();
            CreateMap<RoleViewModel, ApplicationRole>().IgnoreAllNonExisting();
            CreateMap<EditRoleViewModel, ApplicationRole>().IgnoreAllNonExisting();
            CreateMap<ApplicationRole, EditRoleViewModel>().IgnoreAllNonExisting();
            CreateMap<ApplicationRole, SelectListItem>()
                .ForMember(d => d.Text, m => m.MapFrom(s => s.Name))
                .ForMember(d => d.Value, m => m.MapFrom(s => s.Id));
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
