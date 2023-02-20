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

namespace _20._101_Farukov_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.EntitiesAuthorization database = Connection.getContex();

            string login = tbLogin.Text; //Логин пользователя
            string password = tbPassword.Text; //Пароль пользователя

            //Проверка наличия пользователя в базе данных
            if (database.User.Any(us=> us.UserLogin == login && us.UserPassword == password))
            {
                Model.User user = database.User.Where(us => us.UserLogin == login && us.UserPassword == password).FirstOrDefault();
                string role = database.Role.Where(r => r.RoleID == user.RoleID).FirstOrDefault().RoleName; //Роль пользователя

                tblResult.Text = "Добро пожаловать! Ваша роль: " + role; //Вывод роли
            }
            else
            {
                tblResult.Text = "Неверно введены логин или пароль!"; //Если пользователя нет в базе данных, то вывод сообщения об ошибке в данныз пользователя
            }
        }
    }
}
