namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    class LoginViewModel : INotifyPropertyChanged
     {
        #region Events
        //https://www.youtube.com/watch?v=SGx8dAdiua4&t=367s 15:45
        // a los campos que necesito refrescar como el password debo definirle una propiedad privada region attributes
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        //recomendación llamar elatributo igual que el campo pero en minúscula la primera. campo Email atributo email
        //por defecto los booleanos arrancan en False

        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        //pregunta si cambió el valor de la propiedad y si es así llama el evento de refresque
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }
        public bool IsRemembered
        {
            get;
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            //acá no se coloca todo el nombre LoginCommand sino que se quita el Command
            get
            {
                return new RelayCommand(Login);
            }

        }

        

        private async void Login()
        {
            //validar que el usuario haya digitado email y password, toca colocar async porque esa librería nuget 
            //maneja este tipo de metodos https://www.youtube.com/watch?v=SGx8dAdiua4 parte 008 min 1:20
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter un email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter un password.",
                    "Accept");
                return;
            }
            //preguntar por el mail y password, se puede hace acá directamente pero no es aconsejable tener constantes
            //acá sino en un archivo de recursos || es o y && es y

            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "aliscortes@hotmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                  "Error",
                  "Email or password incorrect.",
                  "Accept");
                  this.Password = string.Empty; // pero con esto no se coloca en vacío, es necesario actualizar inotifyproperychange
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                  "Ok",
                  "The information is correct.",
                  "Accept");
            return;
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
               
               
        }

      
        #endregion


    }
}
