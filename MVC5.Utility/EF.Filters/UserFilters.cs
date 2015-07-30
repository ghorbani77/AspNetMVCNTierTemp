using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Utility.EF.Filters
{
   public static  class UserFilters
   {
       public static string EmailConfirmedList = "EmailConfirmedList";
       public static string ActiveList = "ActiveList";
       public static string BannedList = "BannedList";
       public static string DeletedList = "DeletedList";
       public static string SystemAccountList = "SystemAccountList";
       public static string AllowForCommentWithOutApproveList = "AllowForCommentWithOutApproveList";
       public static string AllowForCommentWithApproveList = "AllowForCommentWithApprove";
       public static string ForbiddenForCommentList = "ForbiddenForCommentList";
       public static string CanUploadfileList = "CanUploadfileList";
       public static string CanChangeProfilePicList = "CanChangeProfilePicList";
       public static string CanModifyFirsAndLastNameList = "ForbiddenForCommentList";
       public static string NotSystemAccountList = "NotSystemAccountList";
      
    }
}
