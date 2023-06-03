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
using System.Windows.Threading;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            ListUser.ItemsSource = ConnectOdb.con.user.ToList();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
           
        }

        private void txtAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.con.user.ToList();
            ListUser.ItemsSource = HistoryProduct;
            ListUser.ItemsSource = ConnectOdb.con.user.Where(x => x.name.StartsWith(txtSearch.Text)).ToList();

        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            user user = (sender as Button).DataContext as user;
            ConnectOdb.con.user.Remove(user);
            ConnectOdb.con.SaveChanges();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new RegisterPage());
        }
    }
}
