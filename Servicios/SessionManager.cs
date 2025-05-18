using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class SessionManager
    {
        private static SessionManager _instance_013AL;
        private static readonly object _lock_013AL = new object();
        private string idiomaActual_013AL;
        public Usuario LoggedInUser_013AL { get; private set; }

        
     

        public static SessionManager Instance
        {
            get
            {
                lock (_lock_013AL)
                {
                    if (_instance_013AL == null)
                    {
                        _instance_013AL = new SessionManager();
                    }
                    return _instance_013AL;
                }
            }
        }

        public bool IsLoggedIn_013AL()
        {
            return LoggedInUser_013AL != null;
        }

        public void Login_013AL(Usuario user)
        {
            if (!IsLoggedIn_013AL())
            {
                LoggedInUser_013AL = user;
                
            }
            else
            {
                throw new InvalidOperationException("A user is already logged in.");
            }
        }

        public void Logout_013AL()
        {
            LoggedInUser_013AL = null;
            
        }

        public Usuario GetUsuario_013AL()
        {
            if (IsLoggedIn_013AL())
            {
                return LoggedInUser_013AL;
            }
            else
            {
                throw new InvalidOperationException("No user is currently logged in.");
            }
        }

       
    }
}
