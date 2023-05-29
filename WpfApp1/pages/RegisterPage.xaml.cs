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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage(user user)
        {
            InitializeComponent();
            ConnectOdb.con = new ogonekfixEntities6();
            cmbRole.SelectedValuePath = "roleid";
            cmbRole.DisplayMemberPath = "rolename";
            cmbRole.ItemsSource = ConnectOdb.con.useroles.Where(x => x.roleid == 2).ToList();
            if (role.roleid == 1)
            {
                cmbRole.ItemsSource = ConnectOdb.con.useroles.ToList();
            }
            else if (role.roleid == 2) 
            {
                cmbRole.ItemsSource = ConnectOdb.con.useroles.Where(x => x.roleid == 2).ToList();
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            if (textboxlogin.Text !=  "" && textboxpassword.Text != "" && textboxname.Text != "" && textboxsurname.Text != "")
            {
                ConnectOdb.con.user.Add(new user()
                {
                    login = textboxlogin.Text,
                    password = textboxpassword.Text,
                    name = textboxname.Text,
                    surname = textboxsurname.Text,
                    userroleid = cmbRole.SelectedIndex + 1
                });
                ConnectOdb.con.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Ошибка,заполните все поля ввода!");
            }
            
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
