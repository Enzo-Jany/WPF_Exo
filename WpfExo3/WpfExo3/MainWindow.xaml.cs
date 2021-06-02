using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfExo3.Models;
using WpfExo3.Services;

namespace WpfExo3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UtilisateurService userService;
        public MainWindow()
        {
            InitializeComponent();
            userService = new UtilisateurService();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            if (Age.Text != null && Age.Text != ""
                && Nom.Text != null && Nom.Text != ""
                && Genre.Text != null && Genre.Text != "")
            {
                userService.AddUser(new Utilisateur { Age = int.Parse(Age.Text), Nom = Nom.Text, Genre = Genre.Text });
                xUsers.Items.Add(userService.Users[^1]);
            }
            
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur currentUser = (Utilisateur) xUsers.SelectedItem;
            if (currentUser != null)
            {
                userService.Users.Remove(userService.Users.Find(user => user.Id == currentUser.Id));
                xUsers.Items.Clear();
                foreach (Utilisateur user in userService.Users)
                {
                    xUsers.Items.Add(user);
                }
            }
            
        }

        private void OnUserSelected_Change(object sender, SelectionChangedEventArgs e)
        {
            Utilisateur currentUser = (Utilisateur) xUsers.SelectedItem;
            if (currentUser != null)
            {
                UserName.Text = currentUser.Nom;
                UserGenre.Text = currentUser.Genre;
                UserAge.Text = currentUser.Age.ToString();
            } else
            {
                UserName.Text = "";
                UserGenre.Text = "";
                UserAge.Text = "";
            }
            
        }

        private void ValidateNumberType(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}
