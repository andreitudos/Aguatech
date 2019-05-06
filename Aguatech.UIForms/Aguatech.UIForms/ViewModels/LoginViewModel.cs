namespace Aguatech.UIForms.ViewModels
{
    using System.Windows.Input;
    using Aguatech.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            this.Email = "andreitudos@gmail.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter you password",
                    "Accept");

                return;
            }
            if(!this.Email.Equals("andreitudos@gmail.com")|| !this.Password.Equals("123456")){
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Password or email is wrong!!!",
                   "Accept");

                return;
            }
            //await Application.Current.MainPage.DisplayAlert(
            //    "OK",
            //    "TUDO BEM",
            //    "Accept"
            //    );

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }

}