namespace Jcf.Web.Models.Account
{
    public class LoginViewModel
    {
        public string UserName { get; set;}
        public string Password { get; set;}

        public LoginViewModel()
        {

        }

        public LoginViewModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
