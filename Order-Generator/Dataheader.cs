using System.Collections.Generic;

namespace Order_Generator
{
    public partial class Dataheader : MainWindow
    {
        public List<Data> Employees { get; set; }
        public List<string> Genders { get; set; }


        //Range getExcel = GetExcelData.getExcelData();

        //public Dataheader()
        //{
        //    Employees = new List<Data>()
        //    {
        //        new Data() { ID = getExcel.ID, Address1 = getExcel.Address },
                
        //    };

            
        //    InitializeComponent();
        //    TBC.ItemsSource = Employees;
           
        //}

        //private void ShowPersonDetails_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (Data employee in Employees)
        //    {
        //        string text = string.Empty;
        //        text = "Name : " + employee.Name + Environment.NewLine;
        //        text += "Gender : " + employee.Gender + Environment.NewLine;
        //        MessageBox.Show(text);
        //    }
        //}
    }
}
