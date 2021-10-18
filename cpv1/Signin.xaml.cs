using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cpv1
{
    /// <summary>
    /// Логика взаимодействия для Signin.xaml
    /// </summary>
    public partial class Signin : Window
    {
        public User _CurrentUser;
        public int nowid;
        public string nowemail;
        public Signin()
        {
            InitializeComponent();
        }

        public User Login(string login)
        {
            User user = null;
            string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
            var queryString = "select top 1 id,login,password,email,roleId from Users where login=@login";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@login", login);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        object DB = null;
                        user = new User();
                        user.id = (int)reader.GetValue(0);
                        nowid = user.id;

                        DB = reader.GetValue(1);
                        if (!(DB is DBNull))
                        {
                            user.login = (DB as string).Trim();
                            
                        }
                        DB = reader.GetValue(2);
                        if (!(DB is DBNull))
                        {
                            user.password = (DB as string).Trim();
                        }
                        DB = reader.GetValue(3);
                        if (!(DB is DBNull))
                        {
                            user.email = (DB as string).Trim();
                            nowemail = user.email;
                        }
                        user.roleId = (int)reader.GetValue(4);
                    }

                }
            }
            return user;
        }

        public bool Login(string login, string password)
        {
            var user = Login(login);
            var code_password = Signup.GetHash(password);
            if (user != null && user.password == code_password)
            {
                _CurrentUser = user;
                return true;
            }

            return false;
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLoginIn.Text.Trim();
            string pass = passBoxIn.Password.Trim();
            var isLogedIn = Login(textBoxLoginIn.Text, passBoxIn.Password);

            if (isLogedIn)
            {
                MainWindow main = new MainWindow(_CurrentUser, nowid, nowemail);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid data, try again!");
            }
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }

        private void textBoxLoginIn_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void passBoxIn_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxLoginIn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void passBoxIn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLoginIn.Focus();
        }
    }
}
