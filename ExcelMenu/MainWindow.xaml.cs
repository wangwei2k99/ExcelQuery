using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelMenu
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet dataSet;
        public ObservableCollection<string> listView { get; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            CreatView();
        }
        private void CreatView()
        {
            dataSet = Npoi.ExcelToDataSet(@"\\192.168.10.10\技术中心\工艺查询表.xlsx");
            foreach (DataTable dataTable in dataSet.Tables)
            {
                listView.Add(dataTable.TableName);
            }
            this.ListBox1.ItemsSource = listView;
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedItem is null)
            {
                return;
            }
            else
            {
                this.DataGrid1.ItemsSource = dataSet.Tables[ListBox1.SelectedItem.ToString()].AsDataView();
            }

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = this.DataGrid1.SelectedItem as DataRowView;
                var uri = row["地址"].ToString();
                uri = Regex.Replace(uri, @"(192.168.4.10){1}", "192.168.10.10");
                Process.Start(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查链接地址!");
                //MessageBox.Show(ex.ToString());
            }

        }
    }
}
