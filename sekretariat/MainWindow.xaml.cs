using Microsoft.Data.Sqlite;
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

namespace sekretariat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///
    /// 
    /// 
    /// v0.0.1
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void typeChange(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("", comboBox.SelectedValue.ToString(), System.Windows.MessageBoxButton.OK);
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            // SqliteConnection sqlite_conn;
            // SqliteCommand sqlite_cmd;
        }
        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
