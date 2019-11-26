using System;
using System.Windows;
using System.Windows.Input;
using Window = System.Windows.Window;
using System.Data;
using DataTable = System.Data.DataTable;

namespace Order_Generator
{
    public partial class MainWindow : Window
    {
        readonly DataTable _dataheaderDataTable = GetDataheader.getExcelData();
        readonly DataTable _datalinesDataTable = GetDatalines.getExcelData();
        private DataTable _selectedTable = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
                //ignored
            }
        }

        private void dataheaderBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = true;
            datalinesRadio.IsChecked = false;
            loadBtn.Visibility = Visibility.Visible;
            dataheaderTextBox.Visibility = Visibility.Visible;
            nextBtn.Visibility = Visibility.Visible;
            datalineTextBox.Visibility = Visibility.Hidden;
            createBtn.Visibility = Visibility.Hidden;
            TBC.ItemsSource = _selectedTable.DefaultView;
        }

        private void datalinesBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = false;
            datalinesRadio.IsChecked = true;
            loadBtn.Visibility = Visibility.Hidden;
            dataheaderTextBox.Visibility = Visibility.Hidden;
            nextBtn.Visibility = Visibility.Hidden;
            datalineTextBox.Visibility = Visibility.Visible;
            createBtn.Visibility = Visibility.Visible;
            TBC.ItemsSource = _datalinesDataTable.DefaultView;
        }

        private void closeBtnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dataheaderTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            dataheaderTextBox.Text = "";
        }

        private void dataheaderTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            //if (!loadBtnWasClicked)
            //{
            //    dataheaderTextBox.Text = "Enter Dataheader ID";
            //}
        }

        private void loadBtnClick(object sender, RoutedEventArgs e)
        {
            if (dataheaderTextBox.Text == "Enter Dataheader ID") return;
            try
            {
                var dataheaderID = Convert.ToString(dataheaderTextBox.Text);
                _selectedTable = _dataheaderDataTable.AsEnumerable()
                    .Where(r => r.Field<string>("ID") == dataheaderID)
                    .CopyToDataTable();
                TBC.ItemsSource = _selectedTable.DefaultView;
            }
            catch
            {
                //MessageBox.Show($"{exception}", "Unable to return data", button:MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void nextBtnClick(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = false;
            datalinesRadio.IsChecked = true;
            loadBtn.Visibility = Visibility.Hidden;
            dataheaderTextBox.Visibility = Visibility.Hidden;
            nextBtn.Visibility = Visibility.Hidden;
            datalineTextBox.Visibility = Visibility.Visible;
            createBtn.Visibility = Visibility.Visible;
            TBC.ItemsSource = _datalinesDataTable.DefaultView;

            try
            {
                var dv = (DataView) TBC.ItemsSource;
                var dt = ((DataView) TBC.ItemsSource).Table;
            }
            catch
            {
                //ignore
            }
        }

        private void dataheaderRdioClick(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = true;
            datalinesRadio.IsChecked = false;
            loadBtn.Visibility = Visibility.Visible;
            dataheaderTextBox.Visibility = Visibility.Visible;
            nextBtn.Visibility = Visibility.Visible;
            datalineTextBox.Visibility = Visibility.Hidden;
            createBtn.Visibility = Visibility.Hidden;
            TBC.ItemsSource = _selectedTable.DefaultView;
        }

        private void datalinesRdioClick(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = false;
            datalinesRadio.IsChecked = true;
            loadBtn.Visibility = Visibility.Hidden;
            dataheaderTextBox.Visibility = Visibility.Hidden;
            nextBtn.Visibility = Visibility.Hidden;
            datalineTextBox.Visibility = Visibility.Visible;
            createBtn.Visibility = Visibility.Visible;
            TBC.ItemsSource = _datalinesDataTable.DefaultView;
        }
    }
}
