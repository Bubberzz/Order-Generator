using System;
using System.Collections.Generic;
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
using Microsoft.Office.Interop.Excel;
using Type = System.Type;
using Window = System.Windows.Window;
using System.Data;
using DataTable = System.Data.DataTable;

namespace Order_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Data> PackOrder { get; set; }
        DataTable getExcel = GetExcelData.getExcelData();
        //DataTable dt = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
            TBC.ItemsSource = getExcel.DefaultView;


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
        }

        private void datalinesBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            dataheaderRadio.IsChecked = false;
            datalinesRadio.IsChecked = true;
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
            dataheaderTextBox.Text = "Enter Dataheader ID";
        }

        private void loadBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception exception)
            {
                
            }

            //var dataheaderID = Convert.ToInt32(dataheaderTextBox.Text);

            int dataheaderID = 3;

            //int.TryParse(dataheaderTextBox.Text, out dataheaderID);
            //dt.Rows.Add();

            //getExcel.Rows.Add(textBoxID.Text, textBoxFN.Text, textBoxLN.Text, textBoxAGE.Text);

            //var query = from o in getExcel
            //    select

            TBC.ItemsSource = (System.Collections.IEnumerable)getExcel;

            //Cast<GetExcelData>() = getExcel
            //.Where(item => item.ID == "3")
            //.Select(item => item.Make);


            //getExcel
            //.AsEnumerable()
            //.Where(myRow => myRow.Field<string>("ID") == "3");
        }
    }
}
