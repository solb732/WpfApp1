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
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView(product product)
        {
            InitializeComponent();

            ListProduct.ItemsSource = ConnectOdb.con.product.ToList();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();

            
            type.SelectedValuePath = "id";
            type.DisplayMemberPath = "name";
            type.ItemsSource = ConnectOdb.con.productype.ToList();
            
            if(role.roleid == 2)
            {
                txtAdd.Visibility = Visibility.Collapsed;
                
                
                
            }

        }
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.con.product.Where(x => x.title.Contains(txtSearch.Text)).ToList();
            if (type.SelectedItem != null)
            {
                int SelectProduct = Convert.ToInt32(type.SelectedValue);
                HistoryProduct = HistoryProduct.Where(x => x.producttypeid == SelectProduct).ToList();
                ListProduct.SelectedIndex = 0;
            }
            ListProduct.ItemsSource = HistoryProduct;
        }

        private void btnAddInCart_Click(object sender, RoutedEventArgs e)
        {
            product prod = (sender as Button).DataContext as product;
            crate crt = new crate()
            {
                iduser = activeuser.activeuserid,
                total = 1,
                idproduct = prod.idproduct,

            };
            try
            {
                crate tmpord = ConnectOdb.con.crate.Where(x => x.iduser == activeuser.activeuserid && x.idproduct == prod.idproduct).First();
                tmpord.total = tmpord.total + 1;
            }
            catch 
            {
                ConnectOdb.con.crate.Add(crt);
            }
            prod.amount -= prod.amount - crt.total;
            ConnectOdb.con.SaveChanges();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ProductEdit((sender as Button).DataContext as product));
        }

        private void txtAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ProductAdd((sender as Button).DataContext as product));
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           UpdateData(sender, e);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData(sender, e);
        }
    }
}
