using System;
using System.Collections.Generic;
using System.Text;
using WpfExo3.Models;

namespace WpfExo3.Services
{
    class UtilisateurService
    {
        public List<Utilisateur> Users { get; set; }
        public int Id { get; set; }

        public UtilisateurService()
        {
            Users = new List<Utilisateur> { };
            Id = 0;
        }

        public void AddUser(Utilisateur user)
        {
            user.Id = Id;
            Users.Add(user);
            Id++;
        }
    }
}
