using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WorkToGether.DBLib.Class;
using WorkToGether.Internal;
using WorkToGether.View;
using PackView = WorkToGether.View.PackView;

namespace WorkToGether.ViewModels
{
    class PackViewModel : ObservableObject
    {
        private ObservableCollection<DBLib.Class.Pack> _packs; // Collection de packs
        public DBLib.Class.Pack _SelectedPack; // Pack sélectionné

        // Propriété pour la collection de packs
        public ObservableCollection<DBLib.Class.Pack> Packs
        {
            get => _packs;
            set => SetProperty(nameof(Packs), ref _packs, value);
        }

        // Propriété pour le pack sélectionné
        public DBLib.Class.Pack SelectedPack
        {
            get => _SelectedPack;
            set => SetProperty(nameof(SelectedPack), ref _SelectedPack, value);
        }

        // Constructeur de la classe
        public PackViewModel()
        {
            using (WorkToGetherContext workToGetherContext = new WorkToGetherContext())
            {
                // Initialisation de la collection de packs à partir de la base de données
                this.Packs = new ObservableCollection<DBLib.Class.Pack>(workToGetherContext.Packs);
            }
        }

        // Méthode pour mettre à jour un pack
        public void updatePack()
        {
            using (WorkToGetherContext ctx = new())
            {
                if (this.SelectedPack != null)
                {
                    var packToUpdate = ctx.Packs.Find(SelectedPack.Id);

                    if (packToUpdate != null)
                    {
                        // Mettre à jour les propriétés du pack sélectionné
                        packToUpdate.Reduction = this.SelectedPack.Reduction;
                        packToUpdate.Nom = this.SelectedPack.Nom;
                        packToUpdate.Prix = this.SelectedPack.Prix;
                        packToUpdate.NombreEmplacement = this.SelectedPack.NombreEmplacement;

                        ctx.SaveChanges();
                        MessageBox.Show("les Modifications ont été pris en compte");
                    }
                    else
                    {
                        MessageBox.Show("Erreur veuillez sélectionner un champ valide");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur veuillez sélectionner un champ");
                }
            }
        }

        // Méthode interne pour vérifier si un pack peut être mis à jour
        internal bool updatePack(object? parameter = null) => this.SelectedPack != null;

        // Méthode pour gérer le clic sur le bouton d'ajout de pack
        public void AjouterPackButton_Click()
        {
            // Ouvrir la fenêtre d'ajout de pack
            AddPackWindow addPackWindow = new AddPackWindow();
            addPackWindow.ShowDialog();
        }

        // Méthode pour ajouter un nouveau pack
        public void AddPack(string nom, string prix, string nombreEmplacement, string reduction)
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                try
                {
                    // Créer un nouveau pack avec les valeurs spécifiées
                    Pack pack = new Pack();
                    pack.Nom = nom;
                    pack.Prix = Convert.ToDecimal(prix);
                    pack.NombreEmplacement = Convert.ToInt32(nombreEmplacement);
                    pack.Reduction = Convert.ToDouble(reduction);

                    // Ajouter le pack à la base de données
                    context.Packs.Add(pack);
                    context.SaveChanges();

                    // Mettre à jour la collection de packs
                    this.Packs.Add(pack); // Ajouter le nouveau pack à la collection existante

                  
                    MessageBox.Show("Pack Ajouté avec succès");


                    // Fermer la fenêtre d'ajout de pack
                    Window window = Application.Current.Windows[Application.Current.Windows.Count - 1];
                    window.Close();

                    // Rafraîchir la vue
                    ICollectionView view = CollectionViewSource.GetDefaultView(this.Packs);
                    view.Refresh();

                }

                catch (Exception ex)
                {
                    // Afficher l'erreur interne
                    MessageBox.Show("Veillez saisir des valeurs correctes");
                }
            }
        }



        // Méthode pour supprimer un pack
        public void DeletePack()
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                if (this.SelectedPack != null)
                {
                    // Supprimer le pack sélectionné de la base de données
                    context.Packs.Remove(context.Packs.Find(this.SelectedPack.Id));

                    try
                    {
                        context.SaveChanges();

                        // Supprimer le pack de la collection
                        this.Packs.Remove(this.SelectedPack);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la suppression du pack : {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : Aucun pack sélectionné.");
                }
            }
        }
    }
}
