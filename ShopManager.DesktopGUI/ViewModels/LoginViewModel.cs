using Caliburn.Micro;
using ShopManager.APIAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShopManager.DesktopGUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string username;
        private string password;
        private IAPIClient apiClient;
        private IAuthenticatedUser authenticatedUser;

        public LoginViewModel(IAPIClient apiClient, IAuthenticatedUser authenticatedUser)
        {
            this.apiClient = apiClient;
            this.authenticatedUser = authenticatedUser;
        }

        public event EventHandler LoggedSuccessfully;

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

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        private Brush messageBoxColor;

        public Brush MessageBoxColor
        {
            get { return messageBoxColor; }
            set
            {
                messageBoxColor = value;
                NotifyOfPropertyChange(() => MessageBoxColor);
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
                ErrorMessage = "";
                authenticatedUser = null;
                authenticatedUser = await apiClient.AuthenticateUser(Username, Password);
                MessageBoxColor = Brushes.Green;
                ErrorMessage = "Logged properly";
                LoggedSuccessfully(this, null);
            }
            catch (Exception ex)
            {
                MessageBoxColor = Brushes.Red;
                ErrorMessage = ex.Message;
            }
        }
    }
}
