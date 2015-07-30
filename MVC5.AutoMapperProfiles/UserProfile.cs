using System;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses;
using MVC5.DomainClasses.Entities;
using MVC5.Utility;
using MVC5.ViewModel.Account;
using MVC5.ViewModel.AdminArea.User;
using EditUserViewModel = MVC5.ViewModel.AdminArea.User.EditUserViewModel;


namespace MVC5.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
           CreateMap<DateTime, string>().ConvertUsing(new ToPersianDateTimeConverter());

            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(d => d.Roles, s => s.Ignore()).IgnoreAllNonExisting();

            CreateMap<AddUserViewModel, ApplicationUser>()
                .ForMember(d => d.RegisterDate, m => m.MapFrom(s => DateTime.Now))
                .IgnoreAllNonExisting();

            CreateMap<EditUserViewModel, ApplicationUser>().ForMember(s => s.Roles, d => d.Ignore()).IgnoreAllNonExisting();
            CreateMap<ApplicationUser, EditUserViewModel>().IgnoreAllNonExisting();

            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(u => u.RegisterDate, a => a.MapFrom(b => DateTime.Now))
                .ForMember(u => u.CommentPermission, a => a.MapFrom(b => CommentPermissionType.WithApprove))
                .ForMember(u => u.AvatarFileName, a => a.MapFrom(b => "avatar.jpg"))
                .ForMember(u=>u.NameForShow,m=>m.MapFrom(d=>d.NameForShow.GetFriendlyPersianName()))
                .ForMember(u => u.Email, m => m.MapFrom(d => d.Email.FixGmailDots()))
                .IgnoreAllNonExisting();
            
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

}
