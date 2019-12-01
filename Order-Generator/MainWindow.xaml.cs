using System;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Window = System.Windows.Window;
using DataTable = System.Data.DataTable;

namespace Order_Generator
{
    public partial class MainWindow : Window
    {
        private List<int> settings;
        private DataTable _dataheaderDataTable;
        private DataTable _datalinesDataTable;
        private DataTable _selectedTable;

        public MainWindow()
        {
            Hide();
            InitializeComponent();
            //initialiseDataline();
        }

        public void loadData()
        {
            settings = GetSettings.getSettings();
            _dataheaderDataTable = GetDataheader.getExcelData();
            _datalinesDataTable = GetDatalines.getExcelData();
            _selectedTable = new DataTable();
        }

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

        private void closeBtnClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dataheaderTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            dataheaderTextBox.Text = "";
        }

        private void datalinesTextBoxClick(object sender, MouseButtonEventArgs e)
        {
            datalineTextBox.Text = "";
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
                var dv = (DataView)TBC.ItemsSource;
                var dt = ((DataView)TBC.ItemsSource).Table;
            }
            catch
            {
                //ignore
            }
        }

        private void CreateBtn_OnClickBtnClick(object sender, RoutedEventArgs e)
        {
            var dataheaderDataTable = _selectedTable.Clone();
            var datalinesDataTable = _datalinesDataTable.Clone();
            int orderAmount;

            try
            {
                orderAmount = Convert.ToInt32(datalineTextBox.Text);
            }
            catch (Exception)
            {
                orderAmount = 1;
            }

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

            foreach (DataRow dr in _datalinesDataTable.Rows)
            {
                if (!dr.IsNull("Client_Id"))
                {
                    datalinesDataTable.Rows.Add(dr.ItemArray);
                }
            }

            settings = settings.Select(x => x + 1).ToList();
            GetSettings.setSettings(settings);
            initialiseDataline();
            datalinesRadio.IsChecked = false;
            TBC.ItemsSource = null;
            _selectedTable.Clear();
            var fileName = CreateXML.createXML(dataheaderDataTable, datalinesDataTable);
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            MessageBox.Show($@"{fileName} has been saved to {path}\orders", "Successfully saved!");
        }

    }
}
