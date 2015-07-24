using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using MVC5.DomainClasses;

namespace MVC5.ViewModel.AdminArea.User
{
    public class UserViewModel
    {
        public int  Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsBanned { get; set; }
        public  bool IsDeleted { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsSystemAccount { get; set; }
        public string Name { get; set; }
        public string RegisterDate { get; set; }
        public string LastActivityDate { get; set; }
        public string Roles { get; set; }
        public CommentPermissionType CommentPermissionType { get; set; }


    }
}
