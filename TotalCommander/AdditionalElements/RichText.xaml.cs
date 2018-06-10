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
using TotalCommander.Classes;

namespace TotalCommander.AdditionalElements
{
    /// <summary>
    /// Interaction logic for RichText.xaml
    /// </summary>
    public partial class RichText : Window
    {
        public RichText(string txtFilePath, string name)
        {
            InitializeComponent();
            
            string text = System.IO.File.ReadAllText(txtFilePath);
            richTextBox.AppendText(text);
            nameFileTxt.Content = name;

        }

      

      
    }
}
