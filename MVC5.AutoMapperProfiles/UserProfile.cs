using System;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.Account;
using EditUserViewModel = MVC5.ViewModel.AdminArea.User.EditUserViewModel;

namespace MVC5.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            
            CreateMap<ApplicationUser, EditUserViewModel>();
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(u => u.RegisterDate, a => a.MapFrom(b => DateTime.UtcNow))
                .ForMember(u => u.AvatarPath, a => a.MapFrom(b => "/Images/Profile/avatar.jpg"))
                .ForMember(u => u.UserName, a => a.MapFrom(b => b.Email))
                .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        }
    }

}
