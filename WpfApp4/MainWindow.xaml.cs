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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public class Database
        {
            public List<string> _Database { get; set; }
            public void ReadDatabase()
            {
                string text = System.IO.File.ReadAllText(@"~/../../../Files/database.txt");
                _Database = text.Split('\n','\r').ToList();
            }
            public List<string> GetWord(string word)
            {
                var list2 = _Database.Where(x => x.StartsWith(word));
                return list2.ToList();
            }
            public Database()
            {
                ReadDatabase();
            }
        }
        public class Proxy
        {
            public Database databaseMain { get; set; }
            public List<string> cache { get; set; }
            public Proxy()
            {
                cache = new List<string>();
                databaseMain = new Database();
            }
            public List<string> GetWord(string word)
            {
                List<string> list = new List<string>();
                foreach (var item in cache)
                {
                    if (item.StartsWith(word))
                    {
                        list.Add(item);
                    }
                }
                //return list;
                if (list.Count > 0)
                {
                    return list;
                }
                else
                {
                    var list2 = databaseMain.GetWord(word);
                    cache.AddRange(list2);
                    return list2;
                }
                
            }
        }
        public Proxy proxy { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            proxy = new Proxy();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = proxy.GetWord(SearchTB.Text);
            SuggestLB.Items.Clear();
            foreach (var item in list)
            {
                SuggestLB.Items.Add(item);
            }
        }

        private void SuggestLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var str = SuggestLB.SelectedItem as string;
            SearchTB.Text = str;
            //SuggestLB.Items.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TxtBox.AppendText(" "+SearchTB.Text);
            SearchTB.Clear();
        }
    }
}
