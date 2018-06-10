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
using TotalCommander.AdditionalElements;

namespace TotalCommander.MainViews
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : UserControl
    {
        SelectedSide selectedSite;

        public SideView sideLeft { get; set; }
        public SideView sideRight { get; set; }


        public Operations(SideView sideLeft, SideView sideRight)
        {
            InitializeComponent();
            this.sideLeft = sideLeft;
            this.sideRight = sideRight;
           
        }

        public void RefreshAllList()
        {
            sideLeft.RefreshList();
            sideRight.RefreshList();
        }

        public delegate void deletedEventHandler();
        public event deletedEventHandler ShowAfterDeleted;

        public delegate void sortedNameElementsEventHandler(string side);
        public event sortedNameElementsEventHandler ShowAfterNameSorted;

        public delegate void sortedDateElementEventHandler(string side);
        public event sortedDateElementEventHandler ShowAfterDateSorted;

        FocusCommunication communication = new FocusCommunication();
        protected virtual void onShowAfterDateSorted()
        {
           
            string side = communication.CorrectSide(sideLeft, sideRight);
            sideLeft.isActive = false;
            sideRight.isActive = false;

            if (ShowAfterDateSorted != null)
            {
                ShowAfterDateSorted.Invoke(side);
            }
    }

        protected virtual void onShowAfterNameSorted()
        {
            
            string side = communication.CorrectSide(sideLeft, sideRight);
            sideLeft.isActive = false;
            sideRight.isActive = false;

            if (ShowAfterNameSorted != null)
            {
                ShowAfterNameSorted.Invoke(side);
            }
         }

        protected virtual void onShowAfterDeleted()
        {
            if (ShowAfterDeleted != null)
            {
                ShowAfterDeleted.Invoke();
            }
        }
        
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

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            else
            {
                MessageBox.Show("Folder o podanej nazwie już istnieje");
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
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

            DiscElement presentElement = selectedSite == SelectedSide.left ? sideLeft.SelectedElement : sideRight.SelectedElement;
            string dirName = selectedSite == SelectedSide.left ? sideLeft.SelectedElement.Path : sideRight.SelectedElement.Path;
            string fileName = selectedSite == SelectedSide.left ? sideLeft.SelectedElement.getName() : sideRight.SelectedElement.getName();
            string sourcePath = selectedSite == SelectedSide.left ? sideLeft.mainPath.Text : sideRight.mainPath.Text;
            string targetPath = selectedSite == SelectedSide.left ? sideRight.mainPath.Text : sideLeft.mainPath.Text;
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (presentElement.isFile())
            {
               if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                File.Copy(sourceFile, destFile, true);
                onShowAfterDeleted();
            }

            else
            {
                DirectoryCopy(dirName, destFile, true);
                onShowAfterDeleted();
            }
        }

        private void byName_Checked(object sender, RoutedEventArgs e)
        {
           onShowAfterNameSorted();
        }
        private void byName_Unchecked(object sender, RoutedEventArgs e)
        {
            onShowAfterDateSorted();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            string side = communication.CorrectSide(sideLeft, sideRight);
            sideLeft.isActive = false;
            sideRight.isActive = false;
            string sourcePath = side == "left" ? sideLeft.mainPath.Text : sideRight.mainPath.Text;
            var dialog = new CreateDirectory(sourcePath);
            dialog.Show();
            dialog.CreatedDirectory += RefreshAllList;
           
         }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshAllList();
        }

    }
}
