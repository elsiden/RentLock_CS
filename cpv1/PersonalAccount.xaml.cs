using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {
        public User user;
        public string nowemailaccount;
        public int nowidaccount;
        string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
        SqlDataAdapter adapter;
        DataTable OrdersTable;
        public PersonalAccount(int nowidmain, User CurrentUser, string nowemailmain)
        {
            InitializeComponent();
            nowidaccount = nowidmain;
            user = CurrentUser;
            nowemailaccount = nowemailmain;
        }

        private void BackAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql1 = $@"SELECT * FROM Rent where Rent.userid = '{nowidaccount}';";
            string sql2 = "SELECT * FROM Rent;";
            OrdersTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                if(user.roleId == 0)
                {
                    SqlCommand command = new SqlCommand(sql2, connection);
                    adapter = new SqlDataAdapter(command);
                }
                else
                {
                    SqlCommand command = new SqlCommand(sql1, connection);
                    adapter = new SqlDataAdapter(command);
                }
                
                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertRentlock", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(OrdersTable);
                OrdersGrid.ItemsSource = OrdersTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(OrdersTable);
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrdersGrid.SelectedItems != null)
                {
                    for (int i = 0; i < OrdersGrid.SelectedItems.Count; i++)
                    {
                        DataRowView datarowView = OrdersGrid.SelectedItems[i] as DataRowView;
                        if (datarowView != null)
                        {
                            DataRow dataRow = (DataRow)datarowView.Row;
                            dataRow.Delete();
                        }
                    }
                }
                UpdateDB();
                MessageBox.Show($"Order canceled.");
            }
            catch
            {
                MessageBox.Show("Deleting failed");
            }
        }
        
        private void DeleteAccount_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
