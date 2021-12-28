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
using System.IO;
using System.Data.SQLite;
using System.Globalization;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace sekretariat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///
    /// 
    /// 
    /// v0.0.4


    public partial class MainWindow : Window
    {
        public string PathImageToBase64(string path)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);

            ImageFormat format = new ImageFormat(image.RawFormat.Guid);

            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public BitmapImage Base64ToWPFImageSource(string base64String)
        {
            // Convert Base64 String to byte[]
            MessageBox.Show(base64String.ToString(), "XD?");
            byte[] imageBytes = Convert.FromBase64String(base64String);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);

            bi.StreamSource = new MemoryStream(imageBytes);
            bi.EndInit();

            return bi;
        }
        public class WorkerRow
        {
            public string imie { set; get; }
            public string druImie { set; get; }
            public string nazwisko { set; get; }
            public string panNazwisko { set; get; }
            public string imRodzicow { set; get; }
            public BitmapImage zdjecie { set; get; }
            public string plec { set; get; }
            public string pesel { set; get; }
            public DateTime dataUr { set; get; }
            public DateTime dataZat { set; get; }
            public string opisStan { set; get; }
            public string etat { set; get; }

        }
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

            photoBtn.Focusable = true;
            photoBtn.Visibility = Visibility.Visible;

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

            string rows = "";
            string values = "";

            foreach (var element in container.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox e = (TextBox)element;
                    if (e.Text != "")
                    {
                        rows += $"{e.Name},";
                        if(e.Name=="zdjecie")
                            values += $"\"{PathImageToBase64(e.Text)}\",";
                        else
                            values += $"\"{e.Text}\",";
                    }
                        
                }
                else if (element.GetType() == typeof(DatePicker))
                {
                    DatePicker e = (DatePicker)element;

                    if(e.SelectedDate.HasValue)
                    if (e.SelectedDate.Value.ToString() != "")
                    {
                        rows += $"{e.Name},";
                        values+=$"\"{e.SelectedDate.Value}\",";
                    }
                       

                }
                else if (element.GetType() == typeof(ComboBox))
                {
                    ComboBox e = (ComboBox)element;
                    if (e.SelectedValue!=null)
                    if (e.Name.ToString() != "typeSelector" && e.SelectedValue.ToString()!="")
                    {
                        rows += $"{e.Name},";
                        values += $"\"{e.SelectedValue}\",";
                    }
                }
            }
            rows = rows.Remove(rows.Length - 1);
            values = values.Remove(values.Length - 1);

            query += $"({rows}) VALUES ({values});";
            return query;
        }

        public MainWindow()
        {
            InitializeComponent();
            hidePrompts();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // Create DB if not exists
            bool newdb = File.Exists("school.db");
            if (!newdb)
            {
                sqlite_conn = new SQLiteConnection("Data Source=school.db;Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                // TODO: Make this create tables: (Uczniowie, Nauczyciele, Pracownicy)
                sqlite_cmd.CommandText = $"CREATE TABLE IF NOT EXISTS Pracownik (imie TEXT, druImie TEXT, nazwisko TEXT, panNazwisko Text, imRodzicow TEXT, zdjecie TEXT, plec TEXT, pesel TEXT, dataUr TEXT, dataZat TEXT, opisStan TEXT, etat TEXT);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Reset();
                sqlite_cmd.CommandText = $"CREATE TABLE IF NOT EXISTS Nauczyciel (imie TEXT, druImie TEXT, nazwisko TEXT, panNazwisko Text, imRodzicow TEXT, zdjecie TEXT, plec TEXT, pesel TEXT, dataUr TEXT, dataZat TEXT, przedmiotyNau TEXT, wychowawstwo TEXT, klasyZGodz TEXT);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Reset();
                sqlite_cmd.CommandText = $"CREATE TABLE IF NOT EXISTS Uczen (imie TEXT, druImie TEXT, nazwisko TEXT, panNazwisko Text, imRodzicow TEXT, zdjecie TEXT, plec TEXT, pesel TEXT, dataUr TEXT, klasa TEXT, grupyJez TEXT);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Reset();
                sqlite_conn.Close();
                //MessageBox.Show("DB created");
            }

            sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            
            // new data insertion (Automated)
            sqlite_cmd.CommandText = "SELECT * FROM Pracownik;";
            var read = sqlite_cmd.ExecuteReader();
            List<WorkerRow> workers = new List<WorkerRow> { };
            
            while (read.Read())
            {
                
                workers.Add(new WorkerRow
                {
                    imie = read.GetValue(read.GetOrdinal("imie")).ToString(),
                    druImie = read.GetValue(read.GetOrdinal("druImie")).ToString(),
                    nazwisko = read.GetValue(read.GetOrdinal("nazwisko")).ToString(),
                    panNazwisko = read.GetValue(read.GetOrdinal("panNazwisko")).ToString(),
                    imRodzicow = read.GetValue(read.GetOrdinal("imRodzicow")).ToString(),
                    zdjecie = Base64ToWPFImageSource(read.GetValue(read.GetOrdinal("zdjecie")).ToString()),
                    plec = read.GetValue(read.GetOrdinal("plec")).ToString(),
                    pesel = read.GetValue(read.GetOrdinal("pesel")).ToString(),
                    dataUr = DateTime.Parse(read.GetValue(read.GetOrdinal("dataUr")).ToString()),
                    dataZat = DateTime.Parse(read.GetValue(read.GetOrdinal("dataZat")).ToString()),
                    opisStan = read.GetValue(read.GetOrdinal("opisStan")).ToString(),
                    etat = read.GetValue(read.GetOrdinal("etat")).ToString()
                });
                

            }
            sqlite_conn.Close();
            workersTable.Items.Clear();
            workersTable.ItemsSource = workers;
            //workersTable.Items.Add(testc);
            //workersTable.Items.Add(new WorkerRow {imie="Nikodem",druImie="Rafał",nazwisko="Reszka",panNazwisko="",imRodzicow="",zdjecie=new Image(),plec="",pesel="",dataUr=new DateTime(),dataZat=new DateTime(),opisStan="",etat=""});
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


            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            // new data insertion (Automated)
            sqlite_cmd.CommandText = generateInsertQuery();

            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();

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

        private void loadImgPath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

            dlg.DefaultExt = ".png"; // Default file extension 

            // Show open file dialog box 
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                zdjecie.Text = dlg.FileName;
            }
        }
    }
}
