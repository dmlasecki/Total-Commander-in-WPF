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
using System.ComponentModel;
using TotalCommander.AdditionalElements;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace TotalCommander.MainViews
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

        public bool isActive { get; set; }
        private void Side_Loaded(object sender, RoutedEventArgs e)
        {
            isActive = false;

        }

        Stack myStack = new Stack();
        public DiscElement SelectedElement
        {

            get
            {
                Contr selectedItem = ((Contr)listView.SelectedItem);
                if (selectedItem != null)
                {
                    return selectedItem.Ele;
                }
                else return null;

                }
        }
     
        public void sortByName()
        {
           
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }


        public void sortByDate()
        {
          
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CreationDate", ListSortDirection.Ascending));
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
            myStack.Push(mainPath.Text);
           
        }
        
        //public List<DiscElement> elements;
        public void RefreshList()
        {
           
            listView.ItemsSource = "";
           
            List<Contr> controller = new List<Contr>();
            MyDirectory dirs = new MyDirectory(mainPath.Text);

            List<DiscElement> elements = dirs.GetSubElements();

            foreach (var item in elements)
            {
                controller.Add(new Contr(item));
            }
            listView.ItemsSource = controller;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            view.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Contr).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Disc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] nazwy;
            nazwy = Directory.GetLogicalDrives();
            mainPath.Text = nazwy[Disc.SelectedIndex];
            myStack.Clear();
            myStack.Push(mainPath.Text);
            RefreshList();
            isActive = true;
           
        }


        private void OpenDirectory(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                txtFilter.Text = "";
                isActive = true;

                Contr selectedItem = ((Contr)listView.SelectedItem);
                if (selectedItem != null)
                {
                    if (selectedItem.isFile)
                    {
                        if (selectedItem.Type == "JPG" || selectedItem.Type == "PNG" || selectedItem.Type == "BMP")
                        {
                            DisplayPhoto photo = new DisplayPhoto(selectedItem.Name, selectedItem.CreationDate, selectedItem.Type, selectedItem.IntSize, selectedItem.Path);
                            photo.Show();
                        }

                        else if (selectedItem.Type == "TXT")
                        {
                            RichText textWindow = new RichText(selectedItem.Path, selectedItem.Name);
                            textWindow.Show();
                        }
                        else
                            Process.Start(selectedItem.Path);

                    }

                    else
                    {
                        mainPath.Text = selectedItem.Path;
                        myStack.Push(mainPath.Text);
                        RefreshList();
                    }

                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (myStack.Count > 1)
            {
                myStack.Pop();
                mainPath.Text = myStack.Peek().ToString();
                RefreshList();
            }

        }

         private void listView_GotFocus(object sender, RoutedEventArgs e)
        {
          isActive = true;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
       }

          }
}
