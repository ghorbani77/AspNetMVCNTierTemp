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
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
