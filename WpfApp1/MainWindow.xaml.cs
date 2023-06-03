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
using WpfApp1.pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameObj.frameMain = frmMain;
            frmMain.Navigate(new AuthPage());
            if(role.roleid == 1 )
            {
                MenuUserAdd.Visibility = Visibility.Visible;
                MenuAddProduct.Visibility = Visibility.Visible;
            }
            else if (role.roleid == 2 )
            {
                MenuUserAdd.Visibility = Visibility.Collapsed;
                MenuAddProduct.Visibility = Visibility.Collapsed;
            }
            

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           
        }



        private void frmMain_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MenuProductView_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ProductView());
        }

        private void MenuCrateview_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Order());
        }

        private void MenuOrderview_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Orders());
        }

        private void MenuAddProduct_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ProductAdd());
        }

        private void MenuUserView_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Users());
        }

        private void MenuUserAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new RegisterPage());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            activeuser.activeuserid = 0;
            FrameObj.frameMain.Navigate(new AuthPage());
        }
    }
}
