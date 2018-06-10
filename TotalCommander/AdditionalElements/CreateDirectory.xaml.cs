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
    /// Interaction logic for CreateDirectory.xaml
    /// </summary>
    public partial class CreateDirectory : Window
    {
        public delegate void CreatedDirectoryEventHandler();
        public event CreatedDirectoryEventHandler CreatedDirectory;

        protected virtual void onCreatedDirectory()
        {
            if(CreatedDirectory != null)
            {
                CreatedDirectory.Invoke();

            }
        }

        public string path { get; }
        public CreateDirectory(string path)
        {
            InitializeComponent();
            this.path = path;
        }


        private void Create(object sender, RoutedEventArgs e)
        {
            string nameFolder = System.IO.Path.Combine(path, ItemNameTB.Text);

            if (!Directory.Exists(nameFolder))
            {


                if (nameFolder != path)
                {
                    Directory.CreateDirectory(nameFolder);
                    onCreatedDirectory();
                    ItemNameTB.Text = "";
                    this.Close();
                }

                else
                {
                    // this.Close();
                    MessageBox.Show("Wpisz nazwę");
                }
            }

            else
            {
                MessageBox.Show("Folder o zadanej nazwie już istnieje");
                ItemNameTB.Text = "";
            }
              }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
