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
using System.Windows.Shapes;
using System.IO;

namespace TotalCommander.AdditionalElements
{
    /// <summary>
    /// Interaction logic for DisplayPhoto.xaml
    /// </summary>
    public partial class DisplayPhoto : Window
    {
      
        public DisplayPhoto(string name, DateTime CreationDate, string type, double size, string path) 

        {
            InitializeComponent();
            NameLabel.Content = name;
            DateLabel.Content = CreationDate.ToShortDateString();
            ExtensionLabel.Content = type;
            SizeLabel.Content = Math.Round((size / (1024 * 1024)), 2) + " MB";


            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(path);
            b.EndInit();
          
            image.Source = b;
           
        }
    }
}
