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
        private void hidePrompts()
        {
            foreach (var element in container.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox e = (TextBox)element;
                    e.Focusable = false;
                    e.Visibility = Visibility.Hidden;
                }
                else if (element.GetType() == typeof(DatePicker))
                {
                    DatePicker e = (DatePicker)element;
                    e.Focusable = false;
                    e.Visibility = Visibility.Hidden;

                }
                else if (element.GetType() == typeof(ComboBox))
                {
                    ComboBox e = (ComboBox)element;
                    if (e.Name.ToString() != "typeSelector")
                    {
                        e.Focusable = false;
                        e.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
        private void ShowBoxes(String arg)
        {
            imie.Focusable = true;
            imie.Visibility = Visibility.Visible;

            druImie.Focusable = true;
            druImie.Visibility = Visibility.Visible;

            nazwisko.Focusable = true;
            nazwisko.Visibility = Visibility.Visible;

            panNazwisko.Focusable = true;
            panNazwisko.Visibility = Visibility.Visible;

            imRodzicow.Focusable = true;
            imRodzicow.Visibility = Visibility.Visible;

            zdjecie.Focusable = true;
            zdjecie.Visibility = Visibility.Visible;

            plec.Focusable = true;
            plec.Visibility = Visibility.Visible;

            pesel.Focusable = true;
            pesel.Visibility = Visibility.Visible;

            dataUr.Focusable = true;
            dataUr.Visibility = Visibility.Visible;

            if (arg == "Pracownik")
            {
                etat.Focusable = true;
                etat.Visibility = Visibility.Visible;

                opisStan.Focusable = true;
                opisStan.Visibility = Visibility.Visible;

                dataZat.Focusable = true;
                dataZat.Visibility = Visibility.Visible;
            }
            else if (arg == "Nauczyciel")
            {
                wychowawstwo.Focusable = true;
                wychowawstwo.Visibility = Visibility.Visible;

                przedmiotyNau.Focusable = true;
                przedmiotyNau.Visibility = Visibility.Visible;
                
                klasyZGodz.Focusable = true;
                klasyZGodz.Visibility = Visibility.Visible;

                dataZat.Focusable = true;
                dataZat.Visibility = Visibility.Visible;
            }
            else if (arg == "Uczeń")
            {
                klasa.Focusable = true;
                klasa.Visibility = Visibility.Visible;

                grupyJez.Focusable = true;
                grupyJez.Visibility = Visibility.Visible;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            hidePrompts();
        }

        private void typeChange(object sender, SelectionChangedEventArgs e)
        {
            hidePrompts();
            ShowBoxes(typeSelector.SelectedValue.ToString());
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

        private void loseFocus(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
    }
}
