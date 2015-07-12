namespace MVC5.ViewModel.Email
{
    public class EmailConfirmEmail:Postal.Email
    {
        public string To { get; set; }
        public string Link { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
