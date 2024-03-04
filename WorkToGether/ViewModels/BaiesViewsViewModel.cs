using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkToGether.DBLib.Class;
using WorkToGether.Internal;
using WorkToGether.View;

namespace WorkToGether.ViewModels
{
    class BaiesViewsViewModel : ObservableObject
    {
        private ObservableCollection<Baie> _Baies;

        // Champ pour stocker la baie sélectionnée
        public Baie _SelectedBaie;

        // Collection observable de baies
        public ObservableCollection<Baie> Baies
        {
            get => _Baies;
            set => SetProperty(nameof(Baies), ref _Baies, value);
        }

        // Propriété pour accéder à la baie sélectionnée
        public Baie SelectedBaie
        {
            get => _SelectedBaie;
            set => SetProperty(nameof(SelectedBaie), ref _SelectedBaie, value);
        }

        // Constructeur
        public BaiesViewsViewModel()
        {
            // Initialisation de la collection de baies depuis la base de données
            using (WorkToGetherContext context = new())
            {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
            }
        }

        // Méthode pour mettre à jour une baie
        public void updateBaie(object? parameter = null)
        {
            using (WorkToGetherContext context = new())
            {
                if (SelectedBaie != null)
                {
                    // Mettre à jour les propriétés de la baie sélectionnée dans la base de données
                    context.Baies.Find(SelectedBaie.Id).Capacite = SelectedBaie.Capacite;
                    context.Baies.Find(SelectedBaie.Id).Statut = SelectedBaie.Statut;
                    context.Baies.Find(SelectedBaie.Id).Code = SelectedBaie.Code;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez sélectionner un champ");
                }
            }
        }

        // Méthode interne pour vérifier si une mise à jour de baie est possible
        internal bool CanUpdateBaie(object? parameter = null) => this.SelectedBaie != null;

        // Méthode pour ajouter une baie
        public void addBaie(object? parameter = null)
        {
            using (WorkToGetherContext ctx = new WorkToGetherContext())
            {
                Random random = new Random();

                // Créer une nouvelle baie avec des valeurs aléatoires
                Baie baie = new Baie();
                baie.Capacite = random.Next(4, 42);
                baie.Statut = true;

                // Ajouter la nouvelle baie à la base de données
                ctx.Baies.Add(baie);

                try
                {
                    // Enregistrer les changements dans la base de données
                    ctx.SaveChanges();
                    // Ajouter la nouvelle baie à la collection observable
                    this.Baies.Add(baie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'ajout de la baie : {ex.Message}");
                }
            }
        }

        // Méthode interne pour vérifier si l'ajout d'une baie est possible
        internal bool CanAddBaie(object? parameter = null) => this.SelectedBaie != null;

        // Méthode pour supprimer une baie
        public void DeleteBaie()
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                if (this.SelectedBaie != null)
                {
                    // Supprimer la baie sélectionnée de la base de données
                    context.Baies.Remove(context.Baies.Find(this.SelectedBaie.Id));

                    try
                    {
                        // Enregistrer les changements dans la base de données
                        context.SaveChanges();
                        // Supprimer la baie de la collection observable
                        this.Baies.Remove(this.SelectedBaie);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la suppression de la baie : {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : Aucune baie sélectionnée.");
                }
            }
        }

        // Méthode interne pour vérifier si la suppression d'une baie est possible
        internal bool DeleteBaie(object? parameter = null) => this.SelectedBaie != null;
    }
}
