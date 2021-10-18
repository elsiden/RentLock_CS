using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace cpv1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int nowidmain;
        public string nowemailmain;
        public MainWindow(User CurrentUser, int nowid, string nowemail)
        {
            InitializeComponent();
            user = CurrentUser;
            nowidmain = nowid;
            nowemailmain = nowemail;
        }

        public User user;

        private void SedansMain_Click(object sender, RoutedEventArgs e)
        {
            Sedans sedans = new Sedans(user, nowidmain, nowemailmain);
            sedans.ShowDialog();
        }

        private void PersonalAccountMain_Click(object sender, RoutedEventArgs e)
        {
            PersonalAccount account = new PersonalAccount(nowidmain, user, nowemailmain);
            account.ShowDialog();
        }

        private void ExitMain_Click(object sender, RoutedEventArgs e)
        {
            Signin signin = new Signin();
            signin.Show();
            this.Close();
        }

        private void ReviewsMain_Click(object sender, RoutedEventArgs e)
        {
            Reviews review = new Reviews(user);
            review.ShowDialog();
        }

        private void WebSiteMain_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://rentlock.000webhostapp.com/php/index.php");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
