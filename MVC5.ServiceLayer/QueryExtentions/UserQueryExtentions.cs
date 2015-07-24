using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DomainClasses.Entities;

namespace MVC5.ServiceLayer.QueryExtentions
{
    public static class UserQueryExtentions
    {
        public static IQueryable<ApplicationUser> SkipAndTake(this IQueryable<ApplicationUser> users, int pageIndex, int pageSize)
        {
            return users.Skip(pageIndex * pageSize).Take(pageSize);
        }
        public static IQueryable<ApplicationUser> OrderByUserName(this IQueryable<ApplicationUser> users,  bool isDesc = false)
        {
            return isDesc ? users.OrderByDescending(a => a.UserName) : users.OrderBy(a => a.UserName);
        }
        public static IQueryable<ApplicationUser> OrderByEmail(this IQueryable<ApplicationUser> users, bool isDesc = false)
        {
            return isDesc ? users.OrderByDescending(a => a.Email) : users.OrderBy(a => a.Email);
        }

        public static IQueryable<ApplicationUser> SearchByEmail(this IQueryable<ApplicationUser> users, string email)
        {
            return users.Where(a => a.Email.Contains(email));
        }

        public static IQueryable<ApplicationUser> SearchByUserName(this IQueryable<ApplicationUser> users, string userName)
        {
            return users.Where(a => a.UserName.Contains(userName));
        }

        public static IQueryable<ApplicationUser> SearchByFirstName(this IQueryable<ApplicationUser> users,
            string firstName)
        {
            return users.Where(a => a.FirstName.Contains(firstName));
        }
        public static IQueryable<ApplicationUser> SearchByIp(this IQueryable<ApplicationUser> users,
           string ip)
        {
            return users.Where(a => a.LastIp.Contains(ip));
        }
        public static IQueryable<ApplicationUser> SearchByLastName(this IQueryable<ApplicationUser> users,
           string lastName)
        {
            return users.Where(a => a.LastName.Contains(lastName));
        }
    }
}
