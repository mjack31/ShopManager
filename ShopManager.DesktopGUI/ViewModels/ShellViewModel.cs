using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DesktopGUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly LoginViewModel loginViewModel;

        public ShellViewModel(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
            ActivateItem(loginViewModel);
        }
    }
}
