using DesignMaterialsStore.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows;

namespace DesignMaterialsStore
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {

            bool handleIsVisibleChanged = true;

            //Show the login view
            var loginView = new LoginView();
            loginView.Show();

            //Show the main program view and close the login view if the user has successfully logged in
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (handleIsVisibleChanged && loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    loginView.Close();
                }
            };

            //Show the register view and hide the login view if the user click on register button
            loginView.buttonRegister.Click += (s, ev) =>
            {
                handleIsVisibleChanged = false;
                RegisterView registerView = new RegisterView();
                registerView.Show();
                loginView.Hide();

                //Show the login view again and close the register view if the user click on back button
                registerView.buttonBack.Click += (s1, ev1) =>
                {
                    loginView.Show();
                    registerView.Close();
                    handleIsVisibleChanged = true;
                };

            };

        }

    }//end class
}//end namespace
