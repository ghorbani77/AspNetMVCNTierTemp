using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.Group;

namespace MVC5.AutoMapperProfiles
{
    public class GroupProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationGroup, GroupViewModel>();

            CreateMap<GroupViewModel, ApplicationGroup>().ForMember(d=>d.Type,s=>s.UseValue(GroupType.Custom))
                .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }
}
