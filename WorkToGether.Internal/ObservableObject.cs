using System.ComponentModel;

namespace WorkToGether.Internal
{
    public abstract class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Events

        /// <summary>
        /// Se produit quand une propriété a été changée
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Se produit quand une propriété va être changée
        /// </summary>
        public event PropertyChangingEventHandler? PropertyChanging;

        #endregion

        #region Methods

        /// <summary>
        /// Déclenche l'événement PropertyChanging <see cref="PropertyChanging"/>
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui va changé</param>
        private void OnPropertyChanging(string propertyName) => this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

        /// <summary>
        /// Déclenche l'événement PropertyChanged <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui a changé</param>
        private void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        /// <summary>
        /// Assigne une propriété et déclenche les événéments
        /// </summary>
        /// <typeparam name="T">Type de la propriété</typeparam>
        /// <param name="propertyName">Nom de la propriété</param>
        /// <param name="field">Référérence de l'attribut à assigner</param>
        /// <param name="value">Valeur</param>
        protected void SetProperty<T>(string propertyName, ref T field, T value) where T : class
        {
            if ((field == null && value != null) || field?.Equals(value) == false)
            {
                OnPropertyChanging(propertyName);
                field = value;
                OnPropertyChanged(propertyName);
            }
        }


        #endregion
    }
}
