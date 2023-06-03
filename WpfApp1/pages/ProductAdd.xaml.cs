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
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Page
    {
        public ProductAdd()
        {
            InitializeComponent();
            ConnectOdb.con = new ogonekfixEntities6();
           
            txtproducttype.SelectedValuePath = "id";
            txtproducttype.DisplayMemberPath = "name";
            txtproducttype.ItemsSource = ConnectOdb.con.productype.ToList();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectOdb.con.product.Add(new product()
                {
                    title = txttitle.Text,
                    work_time = txtworktime.Text,
                    effectsam = txteffect.Text,
                    caliber = txtcalibr.Text,
                    volleysam = txtvolley.Text,
                    amount = txtamount.Text,
                    cost = Convert.ToDecimal(txtCost.Text),
                    photo = txtphoto.Text,
                    productype = txtproducttype.SelectedItem as productype
                });
                ConnectOdb.con.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString()); 
            }
            
        }
    }
}
