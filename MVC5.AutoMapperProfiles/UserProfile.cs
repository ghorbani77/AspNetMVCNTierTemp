using System;
using AutoMapper;
using MVC5.AutoMapperProfiles.Extentions;
using MVC5.DomainClasses;
using MVC5.DomainClasses.Entities;
using MVC5.ViewModel.AdminArea.Security;
using MVC5.ViewModel.AdminArea.User;


namespace MVC5.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<DateTime, string>().ConvertUsing(new ToPersianDateTimeConverter());

            CreateMap<ApplicationUser, UserViewModel>().IgnoreAllNonExisting().ForMember(d => d.Roles, s => s.Ignore());
          //  CreateMap<UserViewModel, ApplicationUser>().IgnoreAllNonExisting();

            CreateMap<AddUserViewModel, ApplicationUser>().IgnoreAllNonExisting();

            CreateMap<EditUserViewModel, ApplicationUser>().ForMember(s=>s.Roles,d=>d.Ignore()).IgnoreAllNonExisting();
            CreateMap<ApplicationUser, EditUserViewModel>();

            CreateMap<MVC5.ViewModel.Account.RegisterViewModel, ApplicationUser>()
                .ForMember(u => u.RegisterDate, a => a.MapFrom(b=>DateTime.Now))
                .ForMember(u => u.CommentPermission, a => a.MapFrom(b => CommentPermissionType.WithApprove))
                .ForMember(u => u.AvatarFileName, a => a.MapFrom(b => "avatar.jpg"))
                .IgnoreAllNonExisting();

            CreateMap<DefaultUserRecord, ApplicationUser>()
              .ForMember(u => u.AvatarFileName, a => a.MapFrom(b => "avatar.jpg"))
              .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

}
