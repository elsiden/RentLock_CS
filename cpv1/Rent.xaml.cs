using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        public int nowidrent;
        public string nowemailrent;
        string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
        public int? AddRent(
                string name,
                string phone,
                string date,
                string car,
                int userid)


        {
            int? id = null;
            var queryString = "Insert into [Rent] ([name],[phone],[date],[car],[userid]) OUTPUT inserted.id VALUES (@name, @phone, @date, @car, @userid)";
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@car", car);
                command.Parameters.AddWithValue("@userid", userid);

                connection.Open();
                id = (int?)command.ExecuteScalar();
            }
            return id;
        }

        //string connectionString;
        //SqlDataAdapter adapter;
        //DataTable ReviewsTable;
        public Rent(int nowidsedans, string nowemailsedans)
        {
            InitializeComponent();
            nowidrent = nowidsedans;
            nowemailrent = nowemailsedans;
        }

        

        private static bool _CanPingGoogle()
        {
            const int timeout = 1000;
            const string host = "google.com";

            var ping = new Ping();
            var buffer = new byte[32];
            var pingOptions = new PingOptions();

            try
            {
                var reply = ping.Send(host, timeout, buffer, pingOptions);
                return (reply != null && reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Back_Rent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RentCar_Click(object sender, RoutedEventArgs e)
        {
            string name, phone, date, car;
            int userid;
            name = textBoxNameRent.Text;
            phone = textBoxPhoneRent.Text;
            date = dpDateRent.Text;
            car = comboBoxCarsRent.Text;
            userid = nowidrent;

            if (name.Length < 4 || name.Length > 20) 
            {
                textBoxNameRent.ToolTip = "Minimal length of Name 4 symbols";
                textBoxNameRent.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxNameRent.ToolTip = "";
                textBoxNameRent.Background = Brushes.Transparent;
            }
            if (phone.Length < 11 || phone.Length > 13)
            {
                textBoxPhoneRent.ToolTip = "Minimal length of phone 11 symbols!";
                textBoxPhoneRent.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxPhoneRent.ToolTip = "";
                textBoxPhoneRent.Background = Brushes.Transparent;
            }
            if (dpDateRent.SelectedDate == null)
            {
                dpDateRent.ToolTip = "Choose date!";
                dpDateRent.Background = Brushes.DarkRed;
            }
            else
            {
                dpDateRent.ToolTip = null;
                dpDateRent.Background = Brushes.Transparent;
            }
            if (comboBoxCarsRent.SelectedIndex == -1)
            {
                comboBoxCarsRent.ToolTip = "Choose car!";
                comboBoxCarsRent.Background = Brushes.DarkRed;
            }
            else
            {
                comboBoxCarsRent.ToolTip = null;
                comboBoxCarsRent.Background = Brushes.Transparent;
            }
            if (name.Length >= 4 && name.Length <= 20 &&
                phone.Length >= 11 && phone.Length <= 13 &&
                dpDateRent.SelectedDate != null &&
                comboBoxCarsRent.SelectedIndex != -1)
            {
                AddRent(textBoxNameRent.Text, textBoxPhoneRent.Text, dpDateRent.Text, comboBoxCarsRent.Text, nowidrent);
                textBoxNameRent.Clear();
                textBoxPhoneRent.Clear();
                dpDateRent.Text = null;
                comboBoxCarsRent.SelectedIndex = -1;
                if (_CanPingGoogle())
                {
                    try
                    {
                        MailAddress from = new MailAddress("unc7447@gmail.com", "Company Rentlock");
                        MailAddress to = new MailAddress($"{nowemailrent}");
                        MailMessage m = new MailMessage(from, to);
                        m.Subject = "Rentlock";
                        m.Body = $"<h2>Dear {name}, thank you for oredring the {car} on the {date}.\nWe will contact you at the number {phone} as soon as possible.</h2>";
                        m.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.Credentials = new NetworkCredential("unc7447@gmail.com", "Macbook2019");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        Console.Read();
                        MessageBox.Show($"Thank you for order, our manager will contact you.\nCheck your e-mail {nowemailrent}.");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Thank you for order, our manager will contact you\nYour email doesn't exist");
                    }
                }
                else
                {
                    MessageBox.Show("Thank you for order, our manager will contact you");
                    this.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpDateRent.BlackoutDates.AddDatesInPast();
            textBoxNameRent.Focus();
        }

        private void textBoxPhoneRent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^+]*[^0-9+]+");
            e.Handled = regex.IsMatch(e.Text); 
        }

        private void textBoxNameRent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxNameRent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxPhoneRent_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
