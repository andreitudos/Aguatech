namespace Aguatech.UIForms.ViewModels
{
    using Aguatech.Common.Models;
    public class MainViewModel
    {
        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }
        public ProductsViewModel Products { get; set; }

        public TokenResponse Token { get; set; }

  

        public MainViewModel()
        {
            // this.Login = new LoginViewModel();

            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
