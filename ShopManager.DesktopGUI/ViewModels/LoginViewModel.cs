using Caliburn.Micro;
using ShopManager.APIAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DesktopGUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string username;
        private string password;
        private IAPIClient apiClient;
        private AuthUser authenticatedUser;

        public LoginViewModel(IAPIClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                if (Username?.Length > 0
                    && Password?.Length > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task LogIn()
        {
            try
            {
                authenticatedUser = null;
                authenticatedUser = await apiClient.AuthenticateUser(Username, Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
