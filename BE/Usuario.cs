using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int Cod { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Rol Rol { get; set; }
        public string DNI{ get; set; }
        public string Login { get; set; }
        public bool Bloqueo { get; set; }
        public bool Activo { get; set; }


       /* public List<Componente_013AL> _permisos { get; set; }

        public void AsignarPermisos_013AL(List<Componente_013AL> permisos)
        {
            _permisos = permisos;
        }*/
    }
}
