namespace MVC5.ViewModel.User
{
    public class AddUserViewModel
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public bool IsBanned { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegisterDate { get; set; }
        public string BannedDate { get; set; }
        public string LastLoginDate { get; set; }
    }
}
