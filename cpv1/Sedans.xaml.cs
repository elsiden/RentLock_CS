using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Text.RegularExpressions;

namespace cpv1
{
    /// <summary>
    /// Логика взаимодействия для Sedans.xaml
    /// </summary>
    public partial class Sedans : Window
    {
        public int nowidsedans;
        public string nowemailsedans;
        public User user;
        string connectionString;
        SqlDataAdapter adapter;
        DataTable SedansTable;
        public Sedans(User CurrentUser, int nowidmain, string nowemailmain)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            user = CurrentUser;
            nowidsedans = nowidmain;
            nowemailsedans = nowemailmain;
        }

        public int? AddSedansbd(
                string company,
                string model,
                string classs,
                string power,
                string engine,
                string drive,
                string places,
                string price)


        {
            int? id = null;
            var queryString = "Insert into [Sedans] ([company],[model],[class],[power],[engine],[drive],[places],[price]) OUTPUT inserted.id VALUES (@company,@model,@class,@power,@engine,@drive,@places,@price)";
            using (SqlConnection connection = new SqlConnection(connectionString))

            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@company", company);
                command.Parameters.AddWithValue("@model",model);
                command.Parameters.AddWithValue("@class", classs);
                command.Parameters.AddWithValue("@power",power);
                command.Parameters.AddWithValue("@engine",engine);
                command.Parameters.AddWithValue("@drive",drive);
                command.Parameters.AddWithValue("@places",places);
                command.Parameters.AddWithValue("@price",price);

                connection.Open();
                id = (int?)command.ExecuteScalar();
            }
            return id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Sedans;";
            SedansTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertRentlock", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@company", SqlDbType.NVarChar, 50, "company"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@model", SqlDbType.NVarChar, 50, "model"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@class", SqlDbType.NVarChar, 50, "class"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@power", SqlDbType.NVarChar, 30, "power"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@engine", SqlDbType.NVarChar, 50, "engine"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@drive", SqlDbType.NVarChar, 20, "drive"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@places", SqlDbType.NVarChar, 20, "places"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.NVarChar, 20, "price"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(SedansTable);
                SedansGrid.ItemsSource = SedansTable.DefaultView;
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

        

        private void BackSedans_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RentSedans_Click(object sender, RoutedEventArgs e)
        {
            Rent rent = new Rent(nowidsedans, nowemailsedans);
            rent.ShowDialog();
        }

        

        private void UpdateSedans_Click(object sender, RoutedEventArgs e)
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

        private void DeleteSedans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SedansGrid.SelectedItems != null)
                {
                    for (int i = 0; i < SedansGrid.SelectedItems.Count; i++)
                    {
                        DataRowView datarowView = SedansGrid.SelectedItems[i] as DataRowView;
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
                MessageBox.Show("Error, deletion or update failed");
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(SedansTable);
        }

        private void RentSedans_Loaded(object sender, RoutedEventArgs e)
        {
            if (user.roleId != 1)
            {
                AddSedans.IsEnabled = true;
                RentSedans.IsEnabled = false;
                RentSedans.Visibility = Visibility.Hidden;
                SedansGrid.IsReadOnly = false;
                StackAddSedans.IsEnabled = true;
                
            }
            else
            {
                AddSedans.IsEnabled = false;
                AddSedans.Visibility = Visibility.Hidden;
                RentSedans.IsEnabled = true;
                DeleteSedans.IsEnabled = false;
                DeleteSedans.Visibility = Visibility.Hidden;
                SedansGrid.IsReadOnly = true;
                StackAddSedans.IsEnabled = false;
                StackAddSedans.Visibility = Visibility.Hidden;
                this.SizeToContent = SizeToContent.Width;
                UpdateSedans.IsEnabled = false;
                UpdateSedans.Visibility = Visibility.Hidden;
            }
        }

        private void AddSedans_Click(object sender, RoutedEventArgs e)
        {
            string company, model, classs, power, engine, drive, places, price;
            company = textBoxCompanySedans.Text;
            model = textBoxModelSedans.Text;
            classs = comboBoxClassSedans.Text;
            power = textBoxHorseSedans.Text;
            engine = textBoxEngineSedans.Text;
            drive = comboBoxDriveSedans.Text;
            places = comboBoxPlacesSedans.Text;
            price = textBoxPriceSedans.Text;
            if (company.Length < 3 || company.Length > 30)
            {
                textBoxCompanySedans.ToolTip = "Minimal length 3 symbols";
                textBoxCompanySedans.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxCompanySedans.ToolTip = null;
                textBoxCompanySedans.Background = Brushes.Transparent;
            }
            if (model.Length < 1 || model.Length > 30)
            {
                textBoxModelSedans.ToolTip = "Minimal length 1 symbol";
                textBoxModelSedans.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxModelSedans.ToolTip = null;
                textBoxModelSedans.Background = Brushes.Transparent;
            }
            if (comboBoxClassSedans.SelectedIndex == -1)
            {
                comboBoxClassSedans.ToolTip = "Choose class!";
                comboBoxClassSedans.Background = Brushes.DarkRed;
            }
            else
            {
                comboBoxClassSedans.ToolTip = null;
                comboBoxClassSedans.Background = Brushes.Transparent;
            }
            if (power.Length < 1 || power.Length > 4)
            {
                textBoxHorseSedans.ToolTip = "Minimal length 1 symbol";
                textBoxHorseSedans.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxHorseSedans.ToolTip = null;
                textBoxHorseSedans.Background = Brushes.Transparent;
            }
            if(engine.Length < 1 || engine.Length > 3 || !Regex.IsMatch(engine, @"\d"))
            {
                textBoxEngineSedans.ToolTip = "Minimal length 1 symbols and contains number!";
                textBoxEngineSedans.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxEngineSedans.ToolTip = null;
                textBoxEngineSedans.Background = Brushes.Transparent;
            }
            if (comboBoxDriveSedans.SelectedIndex == -1)
            {
                comboBoxDriveSedans.ToolTip = "Choose drive!";
                comboBoxDriveSedans.Background = Brushes.DarkRed;
            }
            else
            {
                comboBoxDriveSedans.ToolTip = null;
                comboBoxDriveSedans.Background = Brushes.Transparent;
            }
            if (comboBoxPlacesSedans.SelectedIndex == -1)
            {
                comboBoxPlacesSedans.ToolTip = "Choose places!";
                comboBoxPlacesSedans.Background = Brushes.DarkRed;
            }
            else
            {
                comboBoxPlacesSedans.ToolTip = null;
                comboBoxPlacesSedans.Background = Brushes.Transparent;
            }
            if (price.Length < 1 || price.Length > 4)
            {
                textBoxPriceSedans.ToolTip = "Minimal length 1 symbol";
                textBoxPriceSedans.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxPriceSedans.ToolTip = null;
                textBoxPriceSedans.Background = Brushes.Transparent;
            }
            if (company.Length >= 3 && company.Length <= 30 &&
                model.Length >= 1 && model.Length <= 30 &&
                comboBoxClassSedans.SelectedIndex != -1 &&
                power.Length >= 1 && power.Length <= 4 &&
                engine.Length >= 1 && engine.Length <= 3 && Regex.IsMatch(engine, @"\d") &&
                comboBoxDriveSedans.SelectedIndex != -1 &&
                comboBoxPlacesSedans.SelectedIndex != -1 &&
                price.Length >= 1 && price.Length <= 4)
            {
                try
                {
                    AddSedansbd(textBoxCompanySedans.Text, textBoxModelSedans.Text, comboBoxClassSedans.Text, textBoxHorseSedans.Text,
                    textBoxEngineSedans.Text, comboBoxDriveSedans.Text, comboBoxPlacesSedans.Text, textBoxPriceSedans.Text);

                    textBoxCompanySedans.Clear();
                    textBoxModelSedans.Clear();
                    comboBoxClassSedans.SelectedIndex = -1;
                    textBoxHorseSedans.Clear();
                    textBoxEngineSedans.Clear();
                    comboBoxDriveSedans.SelectedIndex = -1;
                    comboBoxPlacesSedans.SelectedIndex = -1;
                    textBoxPriceSedans.Clear();
                    UpdateDB();
                    Window_Loaded(sender, e);
                    MessageBox.Show("Car added!");
                }
                catch
                {
                    MessageBox.Show("Error, adding or updating failed");
                }
            }
        }

        private void textBoxCompanySedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBoxModelSedans_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxClassSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxHorseSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxHorseSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^+]*[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxEngineSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^+]*[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxDriveSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxPlacesSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^+]*[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxPriceSedans_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxPriceSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^+]*[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxCompanySedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxModelSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxClassSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxDriveSedans_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBoxEngineSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxPlacesSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void textBoxPriceSedans_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        /// ПОИСК

        //private ObservableCollection<TestClass> _testData = new ObservableCollection<TestClass>();
        //public ObservableCollection<TestClass> TestData
        //{
        //    get { return _testData; }
        //    set { _testData = value; }
        //}
    }

    public static class DataGridTextSearch
    {
        // Using a DependencyProperty as the backing store for SearchValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchValueProperty =
            DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        public static string GetSearchValue(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchValueProperty);
        }

        public static void SetSearchValue(DependencyObject obj, string value)
        {
            obj.SetValue(SearchValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsTextMatch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTextMatchProperty =
            DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool), typeof(DataGridTextSearch), new UIPropertyMetadata(false));

        public static bool GetIsTextMatch(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTextMatchProperty);
        }

        public static void SetIsTextMatch(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTextMatchProperty, value);
        }
    }

    public class SearchValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string cellText = values[0] == null ? string.Empty : values[0].ToString();
            string searchText = values[1] as string;

            if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
            {
                return cellText.ToLower().StartsWith(searchText.ToLower());
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
