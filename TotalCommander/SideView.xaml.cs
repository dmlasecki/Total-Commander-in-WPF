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
using TotalCommander.Classes;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for SideView.xaml
    /// </summary>
    public partial class SideView : UserControl
    {

       
        public SideView()
        {
            InitializeComponent();
            }
      
        private void Side_loaded(object sender, RoutedEventArgs e)
        {

            string[] nazwy;
            nazwy = Directory.GetLogicalDrives();
            foreach (string dysk in nazwy)
            {
                Disc.Items.Add(dysk);
            }
            Disc.SelectedIndex = 0;
            mainPath.Text = nazwy[0];
        }

        public void RefreshList()
        {
            List<Contr> controller = new List<Contr>();
            listView.ItemsSource = "";
            MyDirectory dirs = new MyDirectory(mainPath.Text);
            List<DiscElement> elements = dirs.GetSubElements();

            foreach (var item in elements)
            {
                controller.Add(new Contr(item));
            }
            listView.ItemsSource = controller;


        }

        private void button2_Click(object sender, RoutedEventArgs e)
          {
             RefreshList();
          }

      
        private void Disc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] nazwy;
            nazwy = Directory.GetLogicalDrives();
            mainPath.Text = nazwy[Disc.SelectedIndex];
            RefreshList();
        }

        private void OpenDirectory(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Contr selectedItem = ((Contr)listView.SelectedItem);
                if (selectedItem.isFile)
                {
                    Process.Start(selectedItem.Path);

                }

                else
                {
                    mainPath.Text = selectedItem.Path;
                    RefreshList();
                }

            }
        }
    }
}
