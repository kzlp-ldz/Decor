using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Decor.Data;

namespace Decor.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnLoginAsGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ProductListPage());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var password = pbPassword.Password.ToString();
            App.User = DataAccess.GetUser(login, password);
            if(App.User != null)
            {
                NavigationService.Navigate(new Pages.ProductListPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
