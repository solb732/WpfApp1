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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            if (activeuser.activeuserid == 1)
            {
                List<cheque> checkArray = ConnectOdb.con.cheque.ToList();
                List<cheque> checks1 = new List<cheque>();
                foreach (cheque checks in checkArray)
                {

                    string tmpstring = "";
                    string tmpPrice = "";
                    decimal cost = 0;
                    List<order> orderlist = ConnectOdb.con.order.Where(
                        x => x.idcheq == checks.idcheq).ToList();
                    foreach (var order in orderlist)
                    {
                        product tmpProd = ConnectOdb.con.product.Where(
                            x => x.idproduct == order.idproduct).ToList().First();

                        tmpstring += tmpProd.title + " Кол-во: " + order.total + "\n";
                        cost += tmpProd.cost * Convert.ToDecimal(order.total);
                        tmpPrice += (decimal)tmpProd.cost + " руб." + "\n";
                        
                    }
                    cheque tmp = new cheque()
                    {
                        idcheq = checks.idcheq,

                        FIOC = ConnectOdb.con.user.Where
                        (x => x.userid == checks.iduser).ToList().First().name
                        + " " + ConnectOdb.con.user.Where
                        (x => x.userid == checks.iduser).ToList().First().surname,

                        products = tmpstring,

                        price = tmpPrice,

                        date1 = Convert.ToDateTime(checks.date),

                        cost = Convert.ToString(cost)
                    };
                    checks1.Add(tmp);
                }
                ListData.ItemsSource = checks1;
            }
            else
            {
                List<cheque> checkArray = ConnectOdb.con.cheque.Where(x => x.iduser == activeuser.activeuserid).ToList();
                List<cheque> checks1 = new List<cheque>();
                foreach (cheque checks in checkArray)
                {

                    string tmpstring = "";
                    string tmpPrice = "";
                    decimal cost = 0;
                    List<order> orderlist = ConnectOdb.con.order.Where(
                        x => x.idcheq == checks.idcheq).ToList();
                    foreach (var order in orderlist)
                    {
                        product tmpProd = ConnectOdb.con.product.Where(
                             x => x.idproduct == order.idproduct).ToList().First();

                        tmpstring += tmpProd.title + " Кол-во: " + order.total + "\n";
                        cost += tmpProd.cost * Convert.ToDecimal(order.total);
                        tmpPrice += (decimal)tmpProd.cost + " руб." + "\n";
                    }
                    cheque tmp = new cheque()
                    {
                        idcheq = checks.idcheq,

                        FIOC = ConnectOdb.con.user.Where
                        (x => x.userid == checks.iduser).ToList().First().name
                        + " " + ConnectOdb.con.user.Where
                        (x => x.userid == checks.iduser).ToList().First().surname,


                        products = tmpstring,

                        price = tmpPrice,

                        date1 = Convert.ToDateTime(checks.date),

                        cost = Convert.ToString(cost)
                    };
                    checks1.Add(tmp);
                }
                ListData.ItemsSource = checks1;
            }
        }
    }
}
