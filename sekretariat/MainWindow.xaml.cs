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
using MaterialDesignThemes.Wpf;
using static sekretariat.selectorDialog;

namespace sekretariat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///
    /// 
    /// 
    /// v0.0.3


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
                    e.Text = "";
                }
                else if (element.GetType() == typeof(DatePicker))
                {
                    DatePicker e = (DatePicker)element;
                    e.Focusable = false;
                    e.Visibility = Visibility.Hidden;
                    e.SelectedDate = null;

                }
                else if (element.GetType() == typeof(Button))
                {
                    Button e = (Button)element;
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
                        e.SelectedIndex = -1;
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

            submitBtn.Focusable = true;
            submitBtn.Visibility = Visibility.Visible;

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

        private String generateInsertQuery()
        {
            string query = $"INSERT INTO {typeSelector.SelectedValue} ";

            string rows = "(";
            string values = "(";

            foreach (var element in container.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox e = (TextBox)element;
                    if (e.Text != "")
                    {
                        rows += $"{e.Name},";
                        values+= $"{e.Text},";
                    }
                        
                }
                else if (element.GetType() == typeof(DatePicker))
                {
                    DatePicker e = (DatePicker)element;

                    if(e.SelectedDate.HasValue)
                    if (e.SelectedDate.Value.ToString() != "")
                    {
                        rows += $"{e.Name},";
                        values+=$"{e.SelectedDate.Value.ToString()},";
                    }
                       

                }
                else if (element.GetType() == typeof(ComboBox))
                {
                    ComboBox e = (ComboBox)element;
                    if (e.SelectedValue!=null)
                    if (e.Name.ToString() != "typeSelector" && e.SelectedValue.ToString()!="")
                    {
                        rows += $"{e.Name},";
                        values += $"{e.SelectedValue},";
                    }
                }
            }
            rows = rows.Remove(rows.Length - 1);
            values = values.Remove(values.Length - 1);

            rows += ")";
            values += ")";

            query += $"{rows} VALUES {values};";
            return query;
        }

        public MainWindow()
        {
            InitializeComponent();
            hidePrompts();
        }

        private void typeChange(object sender, SelectionChangedEventArgs e)
        {
            if (typeSelector.SelectedIndex != -1) { 
                hidePrompts();
                ShowBoxes(typeSelector.SelectedValue.ToString());
            }


            
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            // TODO: Add validate function 
            MessageBox.Show(generateInsertQuery(), "");
            typeSelector.SelectedIndex = -1;
            hidePrompts();
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
