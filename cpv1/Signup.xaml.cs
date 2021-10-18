using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public User CurrentUser;
        public int nowid;
        public string nowemail;
        string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
        public int? Create(
                string login,
                string password,
                string email,
                int roleId)

        {
           var code_password = GetHash(password);
            int? id = null;
            var queryString = "Insert into [Users] ([login],[password],[email],[roleId]) OUTPUT inserted.id VALUES (@login,@password,@email,@roleId)";
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", code_password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@roleId", roleId);
                connection.Open();
                id = (int?)command.ExecuteScalar();
            }
            return id;
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
        public Signup()
        {
            InitializeComponent();
        }

        public bool Login(string login, string password)
        {
            var user = Login(login);
            var code_password = Signup.GetHash(password);
            if (user != null && user.password == code_password)
            {
                CurrentUser = user;
                return true;
            }

            return false;
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

        public bool IsUser(string login)
        {
            //User user = null;
            string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
            var queryString = "select top 1 Users.Id from Users where Users.login = @login";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                var command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@login", login);
                // Создание объеков команд и параметров.
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var idVal = reader.GetValue(0);

                        return !((idVal is DBNull)
                                    || (int)idVal < 0);
                    }
                }
            }

            return false;
        }

        public bool IsAdmin()
        {
            //User user = null;
            string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
            var queryString = "select top 1 Users.id from Users join RoleID on RoleID.id = Users.roleId where RoleID.roleName = 'Администратор'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                var command = new SqlCommand(queryString, connection);

                // Создание объеков команд и параметров.
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var idVal = reader.GetValue(0);

                        return !((idVal is DBNull)
                                    || (int)idVal < 0);
                    }
                }
            }

            return false;
        }

        

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLoginUp.Text.Trim(); 
            string pass = passBoxUp.Password.Trim();
            string pass2 = passBoxUp2.Password.Trim();
            string email = textBoxEmail.Text.ToLower().Trim();
            string role = comboBoxRole.Text;
            

            if(login.Length < 4 || login.Length > 25)
            {
                textBoxLoginUp.ToolTip = "Minimal length 4 symbols";
                textBoxLoginUp.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLoginUp.ToolTip = null;
                textBoxLoginUp.Background = Brushes.Transparent;
            }
            if(pass.Length < 3 || pass.Length > 15)
            {
                passBoxUp.ToolTip = "Minimal length 3 symbols";
                passBoxUp.Background = Brushes.DarkRed;
            }
            else
            {
                passBoxUp.ToolTip = null;
                passBoxUp.Background = Brushes.Transparent;
            }
            if (pass != pass2 || pass2 == "")
            {
                passBoxUp2.ToolTip = "Invalid password";
                passBoxUp2.Background = Brushes.DarkRed;
            }
            else
            {
                passBoxUp2.ToolTip = null;
                passBoxUp2.Background = Brushes.Transparent;
            }
            if (email.Length < 8 || !email.Contains("@") || !email.Contains(".") || email.Length > 49)
            {
                textBoxEmail.ToolTip = "Minimal length 8 symbols\nOr invalid email";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.Transparent;
            }
            if (comboBoxRole.SelectedIndex == -1)
            {
                comboBoxRole.ToolTip = "Choose role!";
                comboBoxRole.Background = Brushes.DarkRed;
            }
            else
            {
                comboBoxRole.ToolTip = null;
                comboBoxRole.Background = Brushes.Transparent;
            }
            if (login.Length >= 4 && login.Length <= 25 &&
                pass.Length >= 3 && pass.Length <= 15 && pass == pass2 &&
                email.Length >= 8 && email.Length <= 49 && email.Contains("@") && email.Contains(".") &&
                comboBoxRole.SelectedIndex != -1)
            {
                if (comboBoxRole.SelectedIndex == 0) // Admin
                {
                    if (!IsAdmin())
                    {
                        Create(textBoxLoginUp.Text, passBoxUp.Password, textBoxEmail.Text, comboBoxRole.SelectedIndex);
                        var isLogedIn = Login(textBoxLoginUp.Text, passBoxUp.Password);
                        textBoxLoginUp.Clear();
                        passBoxUp.Clear();
                        passBoxUp2.Clear();
                        textBoxEmail.Clear();
                        comboBoxRole.SelectedIndex = -1;
                        MessageBox.Show("Registration complete, welcome to RentLock!");
                        MainWindow main = new MainWindow(CurrentUser, nowid, nowemail);
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error, admin already exists!");
                    }
                }

                if (comboBoxRole.SelectedIndex == 1) // User
                {
                    if (!IsUser(textBoxLoginUp.Text))
                    {
                        Create(textBoxLoginUp.Text, passBoxUp.Password, textBoxEmail.Text, comboBoxRole.SelectedIndex);
                        var isLogedIn = Login(textBoxLoginUp.Text, passBoxUp.Password);
                        textBoxLoginUp.Clear();
                        passBoxUp.Clear();
                        passBoxUp2.Clear();
                        textBoxEmail.Clear();
                        comboBoxRole.SelectedIndex = -1;
                        MessageBox.Show("Registration complete, welcome to RentLock!");
                        MainWindow main = new MainWindow(CurrentUser, nowid, nowemail);
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error, this user already exists!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid data, try again");
            }
        }

        private void Back_Sign_up_Click(object sender, RoutedEventArgs e)
        {
            Signin signin = new Signin();
            signin.Show();
            this.Close();
        }

        private void textBoxLoginUp_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBoxLoginUp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void passBoxUp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void passBoxUp2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxLoginUp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z0-9@.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void passBoxUp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLoginUp.Focus();
        }
    }
}
