using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataTable = System.Data.DataTable;
using Window = System.Windows.Window;

namespace Order_Generator
{
    public partial class MainWindow : Window
    {
        // Creates empty local data containers 
        private List<int> settings;
        private DataTable _dataheaderDataTable;
        private DataTable _datalinesDataTable;
        private DataTable _selectedTable;

        public MainWindow()
        {
            Hide();
            InitializeComponent();
        }

        // Loads data into data containers from excel and text files
        public void loadData()
        {
            FilePaths.LoadFileLocations();
            settings = GetSettings.getSettings();
            _dataheaderDataTable = GetDataheader.getExcelData();
            _datalinesDataTable = GetDatalines.getExcelData();
            _selectedTable = new DataTable();
            initialiseDataline();
        }

        // Inject data from the settings file/list into Datalines data table
        private void initialiseDataline()
        {
            foreach (var row in _datalinesDataTable.AsEnumerable())
            {
                row.SetField("Host_Line_Id", settings[1]);
                row.SetField("Host_Order_Id", settings[0]);
                row.SetField("Line_Id", settings[2]);
                row.SetField("Order_Id", settings[0]);
                row.SetField("User_Def_Num_2", settings[1]);
                row.SetField("User_Def_Type_8", settings[2]);
            }
        }

        // UI control
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

        // UI control
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

        // UI control
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

        // UI control
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

        // UI control
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

        // UI control
        private void closeBtnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // UI control
        private void dataheaderTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            dataheaderTextBox.Text = "";
        }

        // UI control
        private void datalinesTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            datalineTextBox.Text = "";
        }

        // LINQ query to _dataheaderDataTable based on ID number
        private void loadBtnClick(object sender, RoutedEventArgs e)
        {

            if (dataheaderTextBox.Text == "Enter Dataheader ID")
            {
                return;
            }

            var dataheaderID = Convert.ToString(dataheaderTextBox.Text);
            try
            {
                _selectedTable = _dataheaderDataTable.AsEnumerable()
                    .Where(r => r.Field<string>("ID") == dataheaderID)
                    .CopyToDataTable();

                foreach (var row in _selectedTable.AsEnumerable().Where(r => r.Field<string>("Order_Id") == "ENTERED by program"))
                {
                    row.SetField("Order_Id", settings[0]);
                }
                TBC.ItemsSource = _selectedTable.DefaultView;
            }
            catch
            {
                // ignored
            }
        }

        // UI control
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
        }

        // Event handler for Create button - builds data tables for order creation
        private void CreateBtn_OnClickBtnClick(object sender, RoutedEventArgs e)
        {
            // Creates new empty data tables, copies data structure from existing data tables 
            var dataheaderDataTable = _selectedTable.Clone();
            var datalinesDataTable = _datalinesDataTable.Clone();
            int orderAmount;

            try
            {
                // Tries to convert text box input into integer
                orderAmount = Convert.ToInt32(datalineTextBox.Text);
            }
            catch (Exception)
            {
                // If unable to convert text box data to integer, sets variable to 1
                orderAmount = 1;
            }

            // Populates dataheaderDataTable - depending on the amount of orders user selected
            // and ignores empty fields
            for (var i = 0; i < orderAmount; i++)
            {
                foreach (DataRow dr in _selectedTable.Rows)
                {
                    if (!dr.IsNull("ID"))
                    {
                        dataheaderDataTable.Rows.Add(dr.ItemArray);
                    }
                }
            }

            // Removes empty fields from datalinesDataTable
            foreach (DataRow dr in _datalinesDataTable.Rows)
            {
                if (!dr.IsNull("Client_Id"))
                {
                    datalinesDataTable.Rows.Add(dr.ItemArray);
                }
            }

            // Clears the UI
            datalinesRadio.IsChecked = false;
            TBC.ItemsSource = null;
            _selectedTable.Clear();

            // Creates the XML order file and saves to orders folder
            var fileName = CreateXML.createXML(dataheaderDataTable, datalinesDataTable);
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            MessageBox.Show($@"{fileName} has been saved to {FilePaths.OrdersFolder}", "Successfully saved!");
            
            // Gets new (incremented) settings and initialises Dataline gridview 
            settings = GetSettings.getSettings();
            initialiseDataline();
        }

        // Enter key event handler
        private void dataheaderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                loadBtnClick(sender, e);
            }
        }
    }
}
