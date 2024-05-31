using iText.Svg.Renderers.Path.Impl;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WorkToGether.DBLib.Class;
using WorkToGether.Internal;
using WorkToGether.View;

namespace WorkToGether.ViewModels
{
    class UserViewModel : ObservableObject
    {
        private ObservableCollection<DBLib.Class.User> _Users;


        public DBLib.Class.User _SelectedUser;


        public ObservableCollection<DBLib.Class.User> Users
        {
            get => _Users;
            set => SetProperty(nameof(Users), ref _Users, value);
        }

        public DBLib.Class.User SelectedUser
        {
            get => _SelectedUser;
            set => SetProperty(nameof(SelectedUser), ref _SelectedUser, value);
        }

        public UserViewModel()
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                this.Users = new ObservableCollection<DBLib.Class.User>(context.Users);

            }
        }

        public void DeleteUser()
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                if (this._SelectedUser == null)
                {
                    MessageBox.Show("Erreur : Aucun utilisateur sélectionné.");
                    return;
                }

                if (this._SelectedUser.Locations.Count > 0)
                {
                    MessageBox.Show("L'utilisateur sélectionné a des réservations enregistrées. Veuillez d'abord supprimer ses réservations.");
                    return;
                }


                var userLocations = context.Locations.Where(l => l.UsersId == this._SelectedUser.Id);
                context.Locations.RemoveRange(userLocations);


                context.Users.Remove(this._SelectedUser);


                context.SaveChanges();


                this.Users.Remove(this._SelectedUser);
            }
        }


        public void AddUsers(string nom, string prenom, string password, string numero, string email, string roles)
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                DBLib.Class.User newUser = new DBLib.Class.User()
                {
                    Nom = nom,
                    Prenom = prenom,
                    Password = password,
                    Numero = numero,
                    Email = email,
                    Roles = roles
                };

                try
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Users.Add(newUser);


                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                }


        

            }
        }


        private void HandleDbUpdateException(DbUpdateException ex)
        {
            if (ex.InnerException is SqlException innerException && innerException.Number == 547)
            {
                MessageBox.Show("Erreur : Impossible d'ajouter l'utilisateur en raison de contraintes de clés étrangères.");
            }
            else
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'utilisateur : {ex.Message}");
            }
        }


        //  public void LoadUsers()
        // {
        // using (WorkToGetherContext context = new WorkToGetherContext())
        //{
        //    Users = new ObservableCollection<DBLib.Class.User>(context.Users.ToList());
        //}
        //}



        public void UpdateUser()
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                if (this.SelectedUser != null)
                {
                    var userToUpdate = context.Users.Find(SelectedUser.Id);

                    if (userToUpdate != null)
                    {
                        // Mettre à jour les propriétés de l'utilisateur existant
                        userToUpdate.Nom = this.SelectedUser.Nom;
                        userToUpdate.Prenom = this.SelectedUser.Prenom;
                        userToUpdate.Password = this.SelectedUser.Password;
                        userToUpdate.Numero = this.SelectedUser.Numero;
                        userToUpdate.Email = this.SelectedUser.Email;
                        userToUpdate.BaieId = this.SelectedUser.BaieId;
                        userToUpdate.Roles = this.SelectedUser.Roles;

                        try
                        {
                            // Enregistrer les modifications dans la base de données
                            context.SaveChanges();
                            MessageBox.Show("Utilisateur mis à jour avec succès.");
                        }
                        catch (DbUpdateException ex)
                        {
                            // Gérer les exceptions liées aux conflits de clés étrangères
                            if (ex.InnerException is SqlException innerException && innerException.Number == 547)
                            {
                                MessageBox.Show("Erreur : Impossible de mettre à jour l'utilisateur en raison de contraintes de clés étrangères.");
                            }
                            else
                            {
                                MessageBox.Show($"Erreur lors de la mise à jour de l'utilisateur : {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Veuillez sélectionner un utilisateur valide.");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : Veuillez sélectionner un utilisateur.");
                }
            }
        }



        internal bool UpdateUser(object? parameter = null) => this.SelectedUser != null;

        public void AjouterUserButton_Click()
        {
            AddUser user = new AddUser();
            user.ShowDialog();


        }


        public void RetourButton_Click()
        {
           
          
        }



    }

}
