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
                string text = System.IO.File.ReadAllText(@"~/../../Database.txt");
                _Database = text.Split('\r').ToList();
            }
            public List<string> GetWord(string word)
            {
                if()
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
                if(list.Count > 0)
                {
                    return list;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
