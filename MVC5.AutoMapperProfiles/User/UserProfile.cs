using System;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.Account;
using MVC5.ViewModel.AdminArea.User;
using EditUserViewModel = MVC5.ViewModel.AdminArea.User.EditUserViewModel;

namespace MVC5.AutoMapperProfiles.User
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, EditUserViewModel>();

            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(u => u.RegisterDate, a => a.MapFrom(b => DateTime.Now))
                .ForMember(u => u.AvatarFileName, a => a.MapFrom(b => "avatar.jpg"))
                .ForMember(u => u.UserName, a => a.MapFrom(b => b.Email))
                .IgnoreAllNonExisting();

            CreateMap<InstallViewModel, ApplicationUser>()
              .ForMember(u => u.RegisterDate, a => a.MapFrom(b => DateTime.Now))
              .ForMember(u => u.AvatarFileName, a => a.MapFrom(b => "avatar.jpg"))
              .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }

}
