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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            ConnectOdb.con = new ogonekfixEntities6();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = Window.GetWindow(this) as MainWindow;
            var ListUsers = ConnectOdb.con.user.ToList();
            var currentuser = ConnectOdb.con.user.FirstOrDefault(u => u.login == txtlogin.Text && u.password == txtpassword.Password);
            
                if (currentuser !=null)
                {


                    if (currentuser.userroleid == 1)
                    {
                        role.roleid = 1;
                        FrameObj.frameMain.Navigate(new ProductView());
                        MainWindow.MainMenu.Visibility = Visibility.Visible;
                    MainWindow.Quit.Visibility = Visibility.Visible;
                    }
                    else if (currentuser.userroleid == 2)
                    {
                        role.roleid = 2;
                        FrameObj.frameMain.Navigate(new ProductView());
                        MainWindow.MainMenu.Visibility = Visibility.Visible;
                        MainWindow.MenuAddProduct.Visibility = Visibility.Collapsed;
                        MainWindow.MenuUser.Visibility = Visibility.Collapsed;
                        MainWindow.Quit.Visibility = Visibility.Visible;
                    }
                    activeuser.activeuserid = currentuser.userid;
                }
                else
                {
                    MessageBox.Show("Данные введены некорректно", "Уведомление");
                }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new RegisterPage());
            

        }
    }
}
