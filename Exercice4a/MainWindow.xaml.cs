using Microsoft.Win32;
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

namespace Exercice4a
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "";
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            tbxSaisie.Text = null;


        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            if(path !="")
            {
                File.WriteAllText(path, tbxSaisie.Text);
                MessageBox.Show("Fichier sauvegardé");
            }
            else
            {
                MessageBox.Show("Vous devez selectionner un nom de fichier");
            }
            
        }

        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                path = System.IO.Path.GetFullPath(saveFileDialog.FileName);
                File.WriteAllText(path, tbxSaisie.Text);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                path = System.IO.Path.GetFullPath(openFileDialog.FileName);
                tbxSaisie.Text = File.ReadAllText(path);
            }
        }

        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
