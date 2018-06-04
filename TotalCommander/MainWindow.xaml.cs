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

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
        }


     static SelectedSide selectedSite;

        SideView sideLeft;
        SideView sideRight;
    
        public MainWindow() :base()
        {
            InitializeComponent();
            sideLeft = new SideView();
            sideRight = new SideView();
          
            leftBorder.Child = sideLeft;
            rightBorder.Child = sideRight;
            //Up.Child = main;
}

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           

            if (selectedSite == SelectedSide.left)
            {
                
                System.IO.File.Delete(sideLeft.SelectedElement.Path);
                    }
            else if (selectedSite == SelectedSide.right)
            {
                System.IO.File.Delete(sideRight.SelectedElement.Path);
            }
        }
    }
}
