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
using System.IO;
using System.Data.SQLite;
using System.Globalization;
using Microsoft.Win32;
using System.Drawing.Imaging;
using System.Data;
namespace sekretariat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///
    /// 
    /// 
    /// v1.0.0
    public partial class MainWindow : Window
    {

        public class testRow
        {
            public string imie { set; get; }
            public string druImie { set; get; }
            public string nazwisko { set; get; }
            public string panNazwisko { set; get; }
            public string imRodzicow { set; get; }
            public BitmapImage zdjecie { set; get; }
            public string strZdjecie { set; get; }
            public string plec { set; get; }
            public string pesel { set; get; }
            public Nullable<DateTime> dataUr { set; get; }
            public Nullable<DateTime> dataZat { set; get; }
            public string opisStan { set; get; }
            public string etat { set; get; }
            public string wychowawstwo { set; get; }
            public string przedmiotyNau { set; get; }
            public string klasyZGodz { set; get; }
            public string klasa { set; get; }
            public string grupyJez { set; get; }

        }
        public Nullable<DateTime> parseDate(string arg)
        {
            if (arg != "")
            {
                return (Nullable<DateTime>)DateTime.Parse(arg);
            }
            return null;
        }
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
            if (base64String.ToString() != "")
            {
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
            return new BitmapImage();
        }
        public void reloadTables()
        {
            var sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            var sqlite_cmd = sqlite_conn.CreateCommand();

            // new data insertion (Automated)
            sqlite_cmd.CommandText = "SELECT * FROM Pracownik;";
            var read = sqlite_cmd.ExecuteReader();
            List<testRow> workers = new List<testRow> { };
            List<testRow> teachers = new List<testRow> { };
            List<testRow> students = new List<testRow> { };



            while (read.Read())
            {
                workers.Add(new testRow
                {
                    imie = read.GetValue(read.GetOrdinal("imie")).ToString(),
                    druImie = read.GetValue(read.GetOrdinal("druImie")).ToString(),
                    nazwisko = read.GetValue(read.GetOrdinal("nazwisko")).ToString(),
                    panNazwisko = read.GetValue(read.GetOrdinal("panNazwisko")).ToString(),
                    imRodzicow = read.GetValue(read.GetOrdinal("imRodzicow")).ToString(),
                    zdjecie = Base64ToWPFImageSource(read.GetValue(read.GetOrdinal("zdjecie")).ToString()),
                    strZdjecie = read.GetValue(read.GetOrdinal("zdjecie")).ToString(),
                    plec = read.GetValue(read.GetOrdinal("plec")).ToString(),
                    pesel = read.GetValue(read.GetOrdinal("pesel")).ToString(),
                    dataUr = parseDate(read.GetValue(read.GetOrdinal("dataUr")).ToString()),
                    dataZat = parseDate(read.GetValue(read.GetOrdinal("dataZat")).ToString()),
                    opisStan = read.GetValue(read.GetOrdinal("opisStan")).ToString(),
                    etat = read.GetValue(read.GetOrdinal("etat")).ToString()
                });
            }

            //workersTable.Items.Clear();

            workersTable.ItemsSource = workers;

            sqlite_cmd.Reset();
            sqlite_cmd.CommandText = "SELECT * FROM Nauczyciel;";
            read = sqlite_cmd.ExecuteReader();
            while (read.Read())
            {
                teachers.Add(new testRow
                {
                    imie = read.GetValue(read.GetOrdinal("imie")).ToString(),
                    druImie = read.GetValue(read.GetOrdinal("druImie")).ToString(),
                    nazwisko = read.GetValue(read.GetOrdinal("nazwisko")).ToString(),
                    panNazwisko = read.GetValue(read.GetOrdinal("panNazwisko")).ToString(),
                    imRodzicow = read.GetValue(read.GetOrdinal("imRodzicow")).ToString(),
                    zdjecie = Base64ToWPFImageSource(read.GetValue(read.GetOrdinal("zdjecie")).ToString()),
                    strZdjecie = read.GetValue(read.GetOrdinal("zdjecie")).ToString(),
                    plec = read.GetValue(read.GetOrdinal("plec")).ToString(),
                    pesel = read.GetValue(read.GetOrdinal("pesel")).ToString(),
                    dataUr = parseDate(read.GetValue(read.GetOrdinal("dataUr")).ToString()),
                    dataZat = parseDate(read.GetValue(read.GetOrdinal("dataZat")).ToString()),
                    wychowawstwo = read.GetValue(read.GetOrdinal("wychowawstwo")).ToString(),
                    przedmiotyNau = read.GetValue(read.GetOrdinal("przedmiotyNau")).ToString(),
                    klasyZGodz = read.GetValue(read.GetOrdinal("klasyZGodz")).ToString()
                });
            }
            //teachersTable.Items.Clear();
            teachersTable.ItemsSource = teachers;

            sqlite_cmd.Reset();
            sqlite_cmd.CommandText = "SELECT * FROM Uczen;";
            read = sqlite_cmd.ExecuteReader();
            while (read.Read())
            {
                students.Add(new testRow
                {
                    imie = read.GetValue(read.GetOrdinal("imie")).ToString(),
                    druImie = read.GetValue(read.GetOrdinal("druImie")).ToString(),
                    nazwisko = read.GetValue(read.GetOrdinal("nazwisko")).ToString(),
                    panNazwisko = read.GetValue(read.GetOrdinal("panNazwisko")).ToString(),
                    imRodzicow = read.GetValue(read.GetOrdinal("imRodzicow")).ToString(),
                    zdjecie = Base64ToWPFImageSource(read.GetValue(read.GetOrdinal("zdjecie")).ToString()),
                    plec = read.GetValue(read.GetOrdinal("plec")).ToString(),
                    pesel = read.GetValue(read.GetOrdinal("pesel")).ToString(),
                    dataUr = parseDate(read.GetValue(read.GetOrdinal("dataUr")).ToString()),
                    klasa = read.GetValue(read.GetOrdinal("klasa")).ToString(),
                    grupyJez = read.GetValue(read.GetOrdinal("grupyJez")).ToString(),
                    strZdjecie = read.GetValue(read.GetOrdinal("zdjecie")).ToString()
                });
            }
            //studentsTable.Items.Clear();
            studentsTable.ItemsSource = students;

            sqlite_conn.Close();
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
                        if (e.Name == "zdjecie")
                            values += $"\"{PathImageToBase64(e.Text)}\",";
                        else
                            values += $"\"{e.Text}\",";
                    }

                }
                else if (element.GetType() == typeof(DatePicker))
                {
                    DatePicker e = (DatePicker)element;

                    if (e.SelectedDate.HasValue)
                        if (e.SelectedDate.Value.ToString() != "")
                        {
                            rows += $"{e.Name},";
                            values += $"\"{e.SelectedDate.Value}\",";
                        }


                }
                else if (element.GetType() == typeof(ComboBox))
                {
                    ComboBox e = (ComboBox)element;
                    if (e.SelectedValue != null)
                        if (e.Name.ToString() != "typeSelector" && e.SelectedValue.ToString() != "")
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
        public void implementChanges(String tablename)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            List<string> values = new List<string>();
            sqlite_cmd.CommandText = $"DELETE FROM {tablename};";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.Reset();

            string rows = "imie, druImie, nazwisko, panNazwisko, imRodzicow, zdjecie, plec, pesel, dataUr, ";

            if (tablename == "Uczen")
            {
                rows += $"klasa, grupyJez";
                foreach (testRow row in studentsTable.Items)
                    values.Add($"\"{row.imie}\",\"{row.druImie}\",\"{row.nazwisko}\",\"{row.panNazwisko}\",\"{row.imRodzicow}\",\"{row.strZdjecie}\",\"{row.plec}\",\"{row.pesel}\",\"{row.dataUr}\",\"{row.klasa}\",\"{row.grupyJez}\"");
            }

            else if (tablename == "Nauczyciel")
            {
                rows += "dataZat, wychowawstwo, klasyZGodz";
                foreach (testRow row in teachersTable.Items)
                    values.Add($"\"{row.imie}\",\"{row.druImie}\",\"{row.nazwisko}\",\"{row.panNazwisko}\",\"{row.imRodzicow}\",\"{row.strZdjecie}\",\"{row.plec}\",\"{row.pesel}\",\"{row.dataUr}\",\"{row.dataZat}\",\"{row.wychowawstwo}\",\"{row.klasyZGodz}\"");
            }

            else if (tablename == "Pracownik")
            {
                rows += "dataZat, opisStan, etat";
                foreach (testRow row in workersTable.Items)
                    values.Add($"\"{row.imie}\",\"{row.druImie}\",\"{row.nazwisko}\",\"{row.panNazwisko}\",\"{row.imRodzicow}\",\"{row.strZdjecie}\",\"{row.plec}\",\"{row.pesel}\",\"{row.dataUr}\",\"{row.dataZat}\",\"{row.opisStan}\",\"{row.etat}\"");
            }

            foreach (string value in values)
            {
                sqlite_cmd.CommandText = $"INSERT INTO {tablename} ({rows}) VALUES ({value});";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Reset();
            }


            sqlite_cmd.Dispose();
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            reloadTables();
        }
        public string generateSQL()
        {
            string query = $"SELECT * FROM {tableSelection.SelectedValue} ";
            string queryToShow = query;
            bool isData = columnSelection.SelectedValue.ToString().Contains("data");
            if (!isData)
                query += $"WHERE {columnSelection.SelectedValue} ";
            else
                query += $"WHERE CAST((substr({columnSelection.SelectedValue},7,4)||substr({columnSelection.SelectedValue},4,2)||substr({columnSelection.SelectedValue},0,3)) as INT) ";
            queryToShow += $"WHERE {columnSelection.SelectedValue} ";
            if (operationSelection.SelectedValue.ToString() == "Równa")
            {
                query += $"=";
                if (!isData)
                {
                    query += $" \"{datePicker.Text + valuePicker.Text}\"";
                }
            }
                
            else if (operationSelection.SelectedValue.ToString() == "W stylu")
                query += $"LIKE \"%{valuePicker.Text}%\"";
            else if (operationSelection.SelectedValue.ToString() == "Większa")
                query += $">";
            else if (operationSelection.SelectedValue.ToString() == "Większa lub Równa")
                query += $">=";
            else if (operationSelection.SelectedValue.ToString() == "Mniejsza")
                query += $"<";
            else if (operationSelection.SelectedValue.ToString() == "Mniejsza lub Równa")
                query += $"<=";
            if (isData)
            {
                queryToShow += query.Split(' ').Last();
                query += $" CAST((substr(\"{datePicker.Text}\",7,4)||substr(\"{datePicker.Text}\",0,3)||substr(\"{datePicker.Text}\",4,2)) as INT)";
                queryToShow += $" {columnSelection.SelectedValue};";
            }
            if (orderBy.SelectedIndex != -1)
                query += $" ORDER BY {orderBy.SelectedValue}";
            if (orderType.SelectedIndex == 1)
                query += " DESC";

            query += ";";
            
            //SqlTextContainer.Text = (!isData)?query:queryToShow;
            SqlTextContainer.Text = query;

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
            }

            reloadTables();
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
            // TODO project in paint
            // TODO: FIX SQL DATA

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            // new data insertion (Automated)
            sqlite_cmd.CommandText = generateInsertQuery();

            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            sqlite_cmd.Dispose();
            sqlite_conn.Dispose();

            typeSelector.SelectedIndex = -1;
            hidePrompts();
            reloadTables();

        }


        private void loseFocus(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void loadImgPath(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
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
        private void ShowFirstMessage(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Skrót klawiszowy 1");
        }
        private void ShowSecondMessage(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Skrót klawiszowy 2");
        }
        private void changeStudents(object sender, RoutedEventArgs e)
        {
            implementChanges("Uczen");
        }

        private void revertStudents(object sender, RoutedEventArgs e)
        {
            reloadTables();
        }

        private void changeTeachers(object sender, RoutedEventArgs e)
        {
            implementChanges("Nauczyciel");
        }

        private void revertTeachers(object sender, RoutedEventArgs e)
        {
            reloadTables();
        }

        private void changeWorkers(object sender, RoutedEventArgs e)
        {
            implementChanges("Pracownik");
        }

        private void revertWorkers(object sender, RoutedEventArgs e)
        {
            reloadTables();
        }

        private void short1Achange(object sender, SelectionChangedEventArgs e)
        {
            command1.Modifiers = (ModifierKeys)new ModifierKeysConverter().ConvertFromString(short1A.SelectedValue.ToString());
        }
        private void short2Achange(object sender, SelectionChangedEventArgs e)
        {

            command1.Key = (Key)new KeyConverter().ConvertFromString(short2A.SelectedValue.ToString());
        }
        private void short1Bchange(object sender, SelectionChangedEventArgs e)
        {
            command2.Modifiers = (ModifierKeys)new ModifierKeysConverter().ConvertFromString(short1B.SelectedValue.ToString());
        }

        private void short2Bchange(object sender, SelectionChangedEventArgs e)
        {
            command2.Key = (Key)new KeyConverter().ConvertFromString(short2B.SelectedValue.ToString());
        }
        private void ShowSecondMessage(object sender, CanExecuteRoutedEventArgs e)
        {
            MessageBox.Show("Skrót Klawiszowy 2");
        }

        private void ShowFirstMessage(object sender, CanExecuteRoutedEventArgs e)
        {
            MessageBox.Show("Skrót Klawiszowy 1");
        }
        private void importFile(object sender, RoutedEventArgs e)
        {
            if (fileImportComboBox.SelectedIndex == -1 || delimiter.SelectedIndex==-1 || addType.SelectedIndex==-1)
            {
                InfoSnackBar.MessageQueue?.Enqueue(
                    "Aby importować plik należy wcześniej wybrać tabelę, typ importu oraz ustawić delimiter.",
                    null, null, null, false, true, TimeSpan.FromSeconds(3));
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";

                // Show open file dialog box 
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    string filename = $"{dlg.FileName}";

                    SQLiteConnection sqlite_conn;
                    SQLiteCommand sqlite_cmd;

                    sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
                    sqlite_conn.Open();
                    sqlite_cmd = sqlite_conn.CreateCommand();

                    var lines = File.ReadLines(filename);

                    if (addType.SelectedValue.ToString() == "Nadpisz")
                    {
                        sqlite_cmd.CommandText = $"DELETE FROM TABLE {fileImportComboBox.SelectedValue}";
                        sqlite_cmd.ExecuteNonQuery();
                        sqlite_cmd.Reset();
                    }
                    try { 
                        foreach (var line in lines)
                        {

                            List<string> linevars = line.Split(delimiter.SelectedValue.ToString().First()).ToList();
                            if (fileImportComboBox.SelectedValue.ToString() == "Uczen") {
                                sqlite_cmd.CommandText = $"INSERT INTO Uczen (imie,druImie,nazwisko,panNazwisko,imRodzicow,plec,pesel,dataUr,klasa,grupyJez) VALUES ({string.Join(",", linevars.Select(argument => "\"" + argument + "\"")) })";
                            }
                            else if (fileImportComboBox.SelectedValue.ToString() == "Pracownik")
                                sqlite_cmd.CommandText = $"INSERT INTO Pracownik (imie,druImie,nazwisko,panNazwisko,imRodzicow,plec,pesel,dataUr,dataZat,opisStan,etat) VALUES ({string.Join(",", linevars.Select(argument => "\"" + argument + "\"")) })";
                            else if (fileImportComboBox.SelectedValue.ToString() == "Nauczyciel")
                                sqlite_cmd.CommandText = $"INSERT INTO Nauczyciel (imie,druImie,nazwisko,panNazwisko,imRodzicow,plec,pesel,dataUr,dataZat,przedmiotyNau,wychowawstwo,klasyZGodz) VALUES ({string.Join(",", linevars.Select(argument => "\"" + argument + "\"")) })";

                            sqlite_cmd.ExecuteNonQuery();
                            sqlite_cmd.Reset();
                        }
                    }
                    catch
                    {
                        ErrorSnackBar.MessageQueue?.Enqueue(
                        "Dane zawarte w pliku są nieprawidłowe.",
                        null, null, null, false, true, TimeSpan.FromSeconds(3));
                    }
                    sqlite_conn.Close();
                    sqlite_conn.Dispose();
                    sqlite_cmd.Dispose();
                    reloadTables();
                }
            }
        }

        private void OnTableSelect(object sender, SelectionChangedEventArgs e)
        {
            if (tableSelection.SelectedIndex!=-1)
            {
                List<string> pracownikVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "dataZat", "opisStan", "etat" };
                List<string> nauczycielVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "dataZat", "przedmiotyNau", "wychowawstwo", "klasyZGodz" };
                List<string> uczenVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "klasa", "grupyJez" };
                selectorGrid.Columns.Clear();
                ICollection<DataGridColumn> columns = studentsTable.Columns;
                if (tableSelection.SelectedValue.ToString() == "Pracownik")
                {
                    columnSelection.ItemsSource = pracownikVals;
                    columns = workersTable.Columns;
                }
                else if (tableSelection.SelectedValue.ToString() == "Nauczyciel")
                {
                    columnSelection.ItemsSource = nauczycielVals;
                    columns = teachersTable.Columns;
                }
                
                else if (tableSelection.SelectedValue.ToString() == "Uczen")
                {
                    columnSelection.ItemsSource = uczenVals;

                }

                
                foreach (DataGridColumn dgColumns in columns)
                {
                    if (dgColumns.GetType().ToString().Contains("DataGridTextColumn"))
                    selectorGrid.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn
                    {
                        Header = dgColumns.Header,
                        Binding = new Binding(string.Format("{0}", dgColumns.SortMemberPath)),
                        Visibility = dgColumns.Visibility,
                        HeaderTemplate = dgColumns.HeaderTemplate,
                        HeaderTemplateSelector = dgColumns.HeaderTemplateSelector,
                        HeaderStringFormat = dgColumns.HeaderStringFormat,
                        CellStyle = dgColumns.CellStyle
                    }
                    );

                    
                }
                
                columnSelection.IsEnabled = true;
                columnSelection.SelectedIndex = -1;
            }
            else
            {
                columnSelection.IsEnabled = false;
                columnSelection.SelectedIndex = -1;
            }
        }

        private void OnColumnSelect(object sender, SelectionChangedEventArgs e)
        {
            if (columnSelection.SelectedIndex != -1)
            {
                if (columnSelection.SelectedValue.ToString().Contains("data"))
                    operationSelection.ItemsSource = new List<string> { "Mniejsza", "Większa", "Równa", "Większa lub Równa", "Mniejsza lub Równa" };
                else
                    operationSelection.ItemsSource = new List<string> { "Równa", "W stylu" };

                operationSelection.IsEnabled = true;
                operationSelection.SelectedIndex = -1;
            }
            else
            {
                operationSelection.IsEnabled = false;
                operationSelection.SelectedIndex = -1;
            }
        }

        private void OnOperationSelect(object sender, SelectionChangedEventArgs e)
        {
            if (operationSelection.SelectedIndex != -1)
            {
                if (columnSelection.SelectedValue.ToString().Contains("data"))
                {
                    datePicker.IsEnabled = true;
                }
                else
                {
                    valuePicker.IsEnabled = true;
                }
                generateRaportBtn.IsEnabled = true;
                orderBy.IsEnabled = true;
                List<string> pracownikVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "dataZat", "opisStan", "etat" };
                List<string> nauczycielVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "dataZat", "przedmiotyNau", "wychowawstwo", "klasyZGodz" };
                List<string> uczenVals = new List<string>() { "imie", "druImie", "nazwisko", "panNazwisko", "imRodzicow", "plec", "pesel", "dataUr", "klasa", "grupyJez" };

                if (tableSelection.SelectedValue.ToString() == "Pracownik")
                    orderBy.ItemsSource = pracownikVals;
                else if (tableSelection.SelectedValue.ToString() == "Nauczyciel")
                    orderBy.ItemsSource = nauczycielVals;

                else if (tableSelection.SelectedValue.ToString() == "Uczen")
                    orderBy.ItemsSource = uczenVals;
            }
            else
            {
                valuePicker.IsEnabled = false;
                datePicker.IsEnabled = false;
                dataExportBtn.IsEnabled = false;
                generateRaportBtn.IsEnabled = false;
                orderBy.IsEnabled = false;
                orderType.IsEnabled = false;
                datePicker.Text = "";
                valuePicker.Text = "";
                orderBy.SelectedIndex = -1;
                orderType.SelectedIndex = -1;
            }
        }

        private void generateRaport(object sender, RoutedEventArgs e)
        {
            var sqlite_conn = new SQLiteConnection("DataSource=school.db;Version=3;");
            sqlite_conn.Open();
            var sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = generateSQL();
            var read = sqlite_cmd.ExecuteReader();
            
            List<testRow> workers = new List<testRow> { };

            tableSelection.SelectedValue.ToString();

            while (read.Read())
            {
                var newData = new testRow();
                newData.imie = read.GetValue(read.GetOrdinal("imie")).ToString();
                newData.druImie = read.GetValue(read.GetOrdinal("druImie")).ToString();
                newData.nazwisko = read.GetValue(read.GetOrdinal("nazwisko")).ToString();
                newData.panNazwisko = read.GetValue(read.GetOrdinal("panNazwisko")).ToString();
                newData.imRodzicow = read.GetValue(read.GetOrdinal("imRodzicow")).ToString();
                newData.plec = read.GetValue(read.GetOrdinal("plec")).ToString();
                newData.pesel = read.GetValue(read.GetOrdinal("pesel")).ToString();
                newData.dataUr = parseDate(read.GetValue(read.GetOrdinal("dataUr")).ToString());
                try
                {
                    newData.dataZat = parseDate(read.GetValue(read.GetOrdinal("dataZat")).ToString());
                    try
                    {
                        newData.opisStan = read.GetValue(read.GetOrdinal("opisStan")).ToString();
                        newData.etat = read.GetValue(read.GetOrdinal("etat")).ToString();
                    }
                    catch
                    {
                        newData.przedmiotyNau = read.GetValue(read.GetOrdinal("przedmiotyNau")).ToString();
                        newData.wychowawstwo = read.GetValue(read.GetOrdinal("wychowawstwo")).ToString();
                        newData.klasyZGodz = read.GetValue(read.GetOrdinal("klasyZGodz")).ToString();
                    }
                }
                catch
                {
                    newData.klasa = read.GetValue(read.GetOrdinal("klasa")).ToString();
                    newData.grupyJez = read.GetValue(read.GetOrdinal("grupyJez")).ToString();
                }

                workers.Add(newData);

            }
            selectorGrid.ItemsSource = workers;
            
            sqlite_conn.Close();
            sqlite_cmd.Dispose();
            sqlite_conn.Dispose();
            dataExportBtn.IsEnabled = true;

        }

        private void exportTable(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> isShowed = dlg.ShowDialog();

            // Process save file dialog box results
            if (isShowed == true)
            {
                // Save document
                selectorGrid.SelectAllCells();
                selectorGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, selectorGrid);

                selectorGrid.UnselectAllCells();
                string result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);

                File.AppendAllText(dlg.FileName, result, UnicodeEncoding.UTF8);
            }
            
        }

        private void onOrderBySelection(object sender, SelectionChangedEventArgs e)
        {
            if (orderBy.SelectedIndex != -1)
            {
                
                orderType.IsEnabled = true;


            }
            else
            {

                orderType.IsEnabled = false;
            }
        }
    }
}
