using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.ObjectModel;
using System.IO; 
using System.Text;
using WorkToGether.DBLib.Class; 
using WorkToGether.Internal;
using iText.Kernel.Pdf; 
using iText.Layout;
using System.Diagnostics; 

namespace WorkToGether.ViewModels
{
    class LocationViewModel : ObservableObject
    {
        private ObservableCollection<Location> _Locations; // Collection des réservations
        public Location _SelectedLocation; // Réservation sélectionnée

        // Propriété pour la collection des réservations
        public ObservableCollection<Location> Locations
        {
            get => _Locations;
            set => SetProperty(nameof(Locations), ref _Locations, value);
        }

        // Propriété pour la réservation sélectionnée
        public Location SelectedLocation
        {
            get => _SelectedLocation;
            set => SetProperty(nameof(SelectedLocation), ref _SelectedLocation, value);
        }

        // Constructeur de la classe
        public LocationViewModel()
        {
            using (WorkToGetherContext workToGetherContext = new WorkToGetherContext())
            {
                // Initialisation de la collection des réservations à partir de la base de données
                this.Locations = new ObservableCollection<Location>(workToGetherContext.Locations.Include(loc => loc.Users).Include(loc => loc.Pack).Include(loc => loc.Type));
            }
        }

        // Méthode pour exporter les réservations au format PDF
        internal void ExportToPdf()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Construction du contenu du PDF à partir des réservations
            stringBuilder.AppendLine("Liste des réservations : " + System.Environment.NewLine);
            foreach (var location in this.Locations)
            {
                stringBuilder.AppendLine($"Nom : {location.Nom}, Client : {location.Users?.Nom ?? "N/A"}, Nom du pack : {location.Pack?.Nom ?? "N/A"}");
            }

            try
            {
                // Création du PDF à partir du contenu
                using (MemoryStream ms = new MemoryStream())
                {
                    using (var pdfWriter = new PdfWriter(ms))
                    {
                        using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfWriter))
                        {
                            using (var document = new Document(pdfDocument))
                            {
                                document.Add(new iText.Layout.Element.Paragraph(stringBuilder.ToString()));
                            }
                        }
                    }

                    // Convertir MemoryStream en tableau de bytes
                    byte[] bytes = ms.ToArray();

                    // Sauvegarder le contenu dans un fichier
                    string filePath = "toto.pdf"; // Chemin où vous souhaitez sauvegarder le fichier
                    File.WriteAllBytes(filePath, bytes);

                    Console.WriteLine("PDF créé avec succès !");

                    // Ouvrir le fichier PDF
                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du PDF : " + ex.Message);
            }
        }

    }
}
