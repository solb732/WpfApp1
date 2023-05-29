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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public bool isNull = false;
        public Order()
        {
            InitializeComponent();
            getData();
        }
        private void getData()
        {
            List<crate> cratelist = ConnectOdb.con.crate.Where(x => x.iduser == activeuser.activeuserid).ToList();
            List<product> productList = new List<product>();
            foreach (crate crate in cratelist)
            {
                product examle = ConnectOdb.con.product.Where
                    (x => x.idproduct == crate.idproduct).First();
                product tmp = new product()
                {
                    idproduct = examle.idproduct,
                    title = examle.title,
                    work_time = examle.work_time,
                    effectsam = examle.effectsam,
                    caliber = examle.caliber,
                    volleysam = examle.volleysam,
                    cost = examle.cost * crate.total,
                    photo = examle.photo,
                    GetTotal = crate.total
            };
                productList.Add(tmp);
            }
            ListProduct.ItemsSource = productList;
            if (productList.Count == 0)
            {
                isNull = true;
                btnBuy.Visibility = Visibility.Hidden;
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            product product = (sender as Button).DataContext as product;
            crate crt = ConnectOdb.con.crate.Where(x => x.iduser == activeuser.activeuserid
                && x.idproduct == product.idproduct).First();
            ConnectOdb.con.crate.Remove(crt);
            ConnectOdb.con.SaveChanges();
            getData();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (!isNull)
            {
                List<crate> crateList = ConnectOdb.con.crate.Where(
                    x => x.iduser == activeuser.activeuserid).ToList();
                int checkId = 0;
                try { checkId = ConnectOdb.con.cheque.ToList().Last().idcheq; }
                catch { }
                checkId += 1;

                cheque check = new cheque()
                {
                    idcheq = checkId,
                    iduser = activeuser.activeuserid,
                    date = DateTime.Now
                };
                ConnectOdb.con.cheque.Add(check);
                foreach (crate crate in crateList)
                {
                    var product = ConnectOdb.con.product.Where
                        (x => x.idproduct == crate.idproduct).ToList().First();
                    order tmpOrd = new order()
                    {
                        idcheq = checkId,
                        idproduct = crate.idproduct,
                        total = crate.total,
                        price = product.cost * crate.total
                    };
                    ConnectOdb.con.order.Add(tmpOrd);
                    ConnectOdb.con.crate.Remove(crate);
                }
                ConnectOdb.con.SaveChanges();
                FrameObj.frameMain.Navigate(new PageMain());
            }
        }
    }
}
