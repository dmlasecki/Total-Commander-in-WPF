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
using System.IO;
using TotalCommander.MainViews;
using TotalCommander.Classes;
using TotalCommander.AdditionalElements;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        SideView sideLeft;
        SideView sideRight;
        public Operations operation { get; set;}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            sideLeft = new SideView();
            sideRight = new SideView();
            
            operation = new Operations(sideLeft, sideRight);
            operation.ShowAfterDeleted += RefreshAllList;
            operation.ShowAfterNameSorted += RefreshAfterNameSort;
            operation.ShowAfterDateSorted += RefreshAfterDateSort;
           
            leftBorder.Child = sideLeft;
            rightBorder.Child = sideRight;
            Up.Child = operation;
        }

       public MainWindow() :base()
        {
            InitializeComponent();
         }
       

        public void RefreshAllList()
        {
            this.sideLeft.RefreshList();
            this.sideRight.RefreshList();
            
        }

         public void RefreshAfterNameSort(string a)
        {
          

            if (a == "left")
            {
                this.sideLeft.RefreshList();
                sideLeft.sortByName();

            }
            else {
                this.sideRight.RefreshList();
                sideRight.sortByName(); }
        }
        public void RefreshAfterDateSort(string a)
        {
         
            if (a == "left")
            {
                this.sideLeft.RefreshList();
                sideLeft.sortByDate();

            }
            else
            {
                this.sideRight.RefreshList();
                sideRight.sortByDate();
            }
        }

       
    }
}
