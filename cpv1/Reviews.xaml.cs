using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Логика взаимодействия для Reviews.xaml
    /// </summary>
    public partial class Reviews : Window
    {
        public User user;
        string connectionString = "Data Source=(local);Initial Catalog=Rentlock;Integrated Security=True";
        public int? Add(
                string name,
                string review)


        {
            int? id = null;
            var queryString = "Insert into [Reviews] ([name],[review]) OUTPUT inserted.id VALUES (@name,@review)";
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@review", review);

                connection.Open();
                id = (int?)command.ExecuteScalar();
            }
            return id;
        }

        //string connectionString;
        SqlDataAdapter adapter;
        DataTable ReviewsTable;
        //public int? Add(
        //    string name,
        //    string review);
        public Reviews(User CurrentUser)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            user = CurrentUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Reviews;";
            ReviewsTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertRentlock", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NChar, 50, "name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@review", SqlDbType.NVarChar, 200, "review"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(ReviewsTable);
                ReviewsGrid.ItemsSource = ReviewsTable.DefaultView;
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
            adapter.Update(ReviewsTable);
        }


        private void UpdateReviews_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateDB();
            }
            catch
            {
                MessageBox.Show("Updating failed");
            }
        }

        private void BackReviews_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            string name, review;
            name = textBoxNameReviews.Text;
            review = textBoxReview.Text;
            if (name.Length < 2 || name.Length > 20)
            {
                textBoxNameReviews.ToolTip = "Minimal length of Name 2 symbols!";
                textBoxNameReviews.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxNameReviews.ToolTip = null;
                textBoxNameReviews.Background = Brushes.White;
            }
            if (review.Length < 1 || review.Length > 199)
            {

                textBoxReview.ToolTip = "Minimal length of review 1 symbol!";
                textBoxReview.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxReview.ToolTip = null;
                textBoxReview.Background = Brushes.White;
            }
            if(name.Length >= 2 && name.Length <= 20 &&
                review.Length <= 199 && review.Length >= 1)
            {
                try
                {
                    Add(textBoxNameReviews.Text, textBoxReview.Text);
                    textBoxNameReviews.Clear();
                    textBoxReview.Clear();
                    UpdateDB();
                    Window_Loaded(sender, e);
                    MessageBox.Show("Thank you for your review, we appreciate it!");
                }
                catch
                {
                    MessageBox.Show("Review don't added, try again later");
                }
            }
        }

        private void DeleteReviews_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReviewsGrid.SelectedItems != null)
                {
                    for (int i = 0; i < ReviewsGrid.SelectedItems.Count; i++)
                    {
                        DataRowView datarowView = ReviewsGrid.SelectedItems[i] as DataRowView;
                        if (datarowView != null)
                        {
                            DataRow dataRow = (DataRow)datarowView.Row;
                            dataRow.Delete();
                        }
                    }
                }
                UpdateDB();
            }
            catch
            {
                MessageBox.Show("Deleting failed, try again later");
            }
        }

        

        private void DeleteReviews_Loaded(object sender, RoutedEventArgs e)
        {
            if (user.roleId != 1)
            {
                DeleteReviews.IsEnabled = true;
                AddReview.IsEnabled = false;
                AddReview.Visibility = Visibility.Hidden;
                ReviewsGrid.IsReadOnly = false;
                textBoxNameReviews.IsReadOnly = true;
                textBoxNameReviews.Visibility = Visibility.Hidden;
                textBoxReview.IsReadOnly = true;
                textBoxReview.Visibility = Visibility.Hidden;
                AddReviewGrid.Visibility = Visibility.Hidden;
                this.SizeToContent = SizeToContent.Width;
                UpdateReviews.IsEnabled = true;
            }
            else
            {
                ReviewsGrid.IsReadOnly = true;
                DeleteReviews.IsEnabled = false;
                DeleteReviews.Visibility = Visibility.Hidden;
                textBoxNameReviews.IsReadOnly = false;
                textBoxReview.IsReadOnly = false;
                UpdateReviews.IsEnabled = false;
                UpdateReviews.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateReviews_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void textBoxNameReviews_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxNameReviews_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxReview_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я.!$()0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxNameReviews_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
