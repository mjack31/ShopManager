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
        private readonly ProductsListViewModel productsListViewModel;

        public ShellViewModel(LoginViewModel loginViewModel, ProductsListViewModel productsListViewModel)
        {
            this.loginViewModel = loginViewModel;
            this.productsListViewModel = productsListViewModel;
            loginViewModel.LoggedSuccessfully += OnLoggedSuccessfullyEvent;

            ActivateItem(loginViewModel);
        }

        private void OnLoggedSuccessfullyEvent(object sender, EventArgs e)
        {
            ActivateItem(productsListViewModel);
        }
    }
}
