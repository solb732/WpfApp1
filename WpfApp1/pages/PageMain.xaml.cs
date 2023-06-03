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

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            if(role.roleid == 2)
            {
                user.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ProductView());
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Users());
        }

        private void korz_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Order());
        }

        private void zakaz_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new Orders());
        }
    }
}
