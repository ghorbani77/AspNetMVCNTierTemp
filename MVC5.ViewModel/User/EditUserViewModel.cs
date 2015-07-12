namespace MVC5.ViewModel.User
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public bool IsBanned { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
