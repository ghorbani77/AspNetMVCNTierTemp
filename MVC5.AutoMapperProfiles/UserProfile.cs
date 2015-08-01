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
                .ForMember(d => d.Roles, m => m.Ignore()).IgnoreAllNonExisting();

            CreateMap<AddUserViewModel, ApplicationUser>()
                .ForMember(d => d.RegisterDate, m => m.MapFrom(s => DateTime.Now))
                .ForMember(d => d.LastActivityDate, m => m.MapFrom(s => DateTime.Now))
                .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.FixGmailDots()))
                .ForMember(d => d.UserName, m => m.MapFrom(s => s.UserName.ToLower()))
                .IgnoreAllNonExisting();

            CreateMap<EditUserViewModel, ApplicationUser>()
                .ForMember(d => d.Roles, m => m.Ignore())
                .ForMember(d => d.RegisterDate, m => m.Ignore())
                .ForMember(d => d.LastActivityDate, m => m.Ignore())
                .ForMember(d => d.BirthDay, m => m.Ignore())
                .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.FixGmailDots()))
                .ForMember(d => d.UserName, m => m.MapFrom(s => s.UserName.ToLower()))
                 .IgnoreAllNonExisting();

            CreateMap<ApplicationUser, EditUserViewModel>().IgnoreAllNonExisting();

            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(d => d.RegisterDate, a => a.MapFrom(s => DateTime.Now))
                .ForMember(d => d.LastActivityDate, m => m.MapFrom(s => DateTime.Now))
                .ForMember(d => d.CommentPermission, a => a.MapFrom(s => CommentPermissionType.WithApprove))
                .ForMember(d => d.AvatarFileName, a => a.MapFrom(s => "avatar.jpg"))
                .ForMember(d => d.Email, m => m.MapFrom(s => s.Email.FixGmailDots()))
                .ForMember(d => d.UserName, m => m.MapFrom(s => s.UserName.ToLower()))
                .IgnoreAllNonExisting();

        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

}
