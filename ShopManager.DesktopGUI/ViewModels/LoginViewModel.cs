using Caliburn.Micro;
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

        public LoginViewModel()
        {

        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public void LogIn()
        {

        }

        public bool CanLogIn()
        {
            var canlogIn = false;
            if (Username?.Length > 0)
                canlogIn = true;

            return canlogIn;
        }
    }
}
