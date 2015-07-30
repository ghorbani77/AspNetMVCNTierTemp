using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;

namespace MVC5.ServiceLayer.QueryExtensions
{
    public static class UserQueryExtensions
    {
        public static IQueryable<ApplicationUser> SkipAndTake(this IQueryable<ApplicationUser> users, int pageIndex, int pageSize)
        {
            return users.Skip(pageIndex * pageSize).Take(pageSize);
        }
        public static IQueryable<ApplicationUser> OrderByUserName(this IQueryable<ApplicationUser> users,  bool isDesc = false)
        {
            return isDesc ? users.OrderByDescending(a => a.UserName).AsQueryable() : users.OrderBy(a => a.UserName).AsQueryable();
        }
        public static IQueryable<ApplicationUser> OrderByEmail(this IQueryable<ApplicationUser> users, bool isDesc = false)
        {
            return isDesc ? users.OrderByDescending(a => a.Email).AsQueryable() : users.OrderBy(a => a.Email).AsQueryable();
        }

        public static IQueryable<ApplicationUser> SearchByEmail(this IQueryable<ApplicationUser> users, string email)
        {
            return users.Where(a => a.Email.Contains(email));
        }

        public static IQueryable<ApplicationUser> SearchByUserName(this IQueryable<ApplicationUser> users, string userName)
        {
            return users.Where(a => a.UserName.Contains(userName));
        }

        public static IQueryable<ApplicationUser> SearchByNameForShow(this IQueryable<ApplicationUser> users,
            string nameForShow)
        {
            return users.Where(a => a.NameForShow.Contains(nameForShow));
        }
        public static IQueryable<ApplicationUser> SearchByIp(this IQueryable<ApplicationUser> users,
           string ip)
        {
            return users.Where(a => a.LastIp.Contains(ip));
        }
      
    }
}
