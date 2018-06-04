using System;
using System.Collections.Generic;
using System.IO;
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

namespace TotalCommander.MainViews
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : UserControl
    {

        public SideView sideLeft { get; set; }
        public SideView sideRight { get; set; }


        public Operations(SideView sideLeft, SideView sideRight)
        {
            InitializeComponent();
            this.sideLeft = sideLeft;
            this.sideRight = sideRight;
        }

        public delegate void deletedEventHandler();
        public event deletedEventHandler ShowAfterDeleted;
        protected virtual void onShowAfterDeleted()
        {
            if (ShowAfterDeleted != null)
            {
                ShowAfterDeleted.Invoke();
            }
        }
        SelectedSide selectedSite;

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (sideRight.SelectedElement != null)
            {
                selectedSite = SelectedSide.right;
            }
            else selectedSite = SelectedSide.left;



            if (selectedSite == SelectedSide.left)
            {

                try
                {
                    if (sideLeft.SelectedElement.isFile())
                    {
                        File.Delete(sideLeft.SelectedElement.Path);
                        ShowAfterDeleted();
                    }
                    else
                    {
                        Directory.Delete(sideLeft.SelectedElement.Path, true);
                        ShowAfterDeleted();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            else
            {
                try
                {
                    if (sideRight.SelectedElement.isFile())
                    {
                        File.Delete(sideRight.SelectedElement.Path);
                        ShowAfterDeleted();
                    }
                    else
                    {
                        Directory.Delete(sideRight.SelectedElement.Path, true);
                        ShowAfterDeleted();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            if (sideRight.SelectedElement != null)
            {
                selectedSite = SelectedSide.right;
            }
            else selectedSite = SelectedSide.left;

            string fileName = sideLeft.SelectedElement.Path;
            string sourcePath = sideLeft.mainPath.Text;
            string targetPath = sideRight.mainPath.Text;

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
           // Console.ReadKey();

            onShowAfterDeleted();
        
    }
    }
}
