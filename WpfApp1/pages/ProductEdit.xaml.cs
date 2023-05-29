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
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Page
    {
        public ProductEdit(product product)
        {
            InitializeComponent();

            txtproducttype.SelectedIndex = (int)product.producttypeid - 1;
            txtproducttype.SelectedValuePath = "id";
            txtproducttype.DisplayMemberPath = "name";
            txtproducttype.ItemsSource = ConnectOdb.con.productype.ToList();

            ProductObj.idproduct = product.idproduct;
            txttitle.Text = product.title;
            txtworktime.Text = product.work_time;
            txteffect.Text = product.effectsam;
            txtcalibr.Text = product.caliber;
            txtvolley.Text = product.volleysam;
            txtCount.Text = product.amount;
            txtcost.Text = Convert.ToString(product.cost);
            txtphoto.Text = product.photo;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<product> products = ConnectOdb.con.product.Where(x => x.idproduct == ProductObj.idproduct).AsEnumerable().Select(x =>
                {
                    x.title = txttitle.Text;
                    x.work_time = txtworktime.Text;
                    x.effectsam = txteffect.Text;
                    x.caliber = txtcalibr.Text;
                    x.volleysam = txtvolley.Text;
                    x.amount = txtCount.Text;
                    x.cost = Convert.ToDecimal(txtcost.Text);
                    x.photo = txtphoto.Text;
                    return x;
                });
                foreach (product prdct in products)
                {
                    ConnectOdb.con.Entry(prdct).State = System.Data.Entity.EntityState.Modified;
                }
                ConnectOdb.con.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Ошибка", "Error");
            }

        }
    }
}
