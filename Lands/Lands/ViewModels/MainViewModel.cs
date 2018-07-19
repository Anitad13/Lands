using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    class MainViewModel
    {
        #region ViewModel
        public LoginViewModel Login
        {
            get;
            set;
        }
        public LandsViewModel Lands
        {
            get;
            set;
        }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            //acá no instancio lands porque sería cargarla sin necesidad
        }
        #endregion

        #region Singleton
        //permite poder hacer un llamado de la mainviewmodel desde cualquier clase para que no se creen varias instancias de una clase
        //https://www.youtube.com/watch?v=JIFT4GY1qFg&t=61s 12:27

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
