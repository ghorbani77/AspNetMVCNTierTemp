using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC5.DomainClasses
{
   
    #region Users
    /// <summary>
    /// Represents the customer name fortatting enumeration
    /// </summary>
    public enum UserShowNameFormat : int
    {
        /// <summary>
        /// Show emails
        /// </summary>
        ShowEmails = 1,
        /// <summary>
        /// Show usernames
        /// </summary>
        ShowUsernames = 2,
        /// <summary>
        /// Show full names
        /// </summary>
        ShowFullNames = 3,
        /// <summary>
        /// Show first name
        /// </summary>
        ShowFirstName = 4,
        /// <summary>
        /// Show shorted name and city
        /// </summary>
        ShowNameAndCity = 5
    }

    public enum UserRegistrationType : int
    {
        /// <summary>
        /// Standard account creation
        /// </summary>
        Standard = 1,
        /// <summary>
        /// Email validation is required after registration
        /// </summary>
        EmailValidation = 2,
        /// <summary>
        /// A customer should be approved by administrator
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// Registration is disabled
        /// </summary>
        Disabled = 4,
    }

    #endregion //Users
}
