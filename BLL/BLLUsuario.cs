using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE; 

namespace BLL
{
    public class BLLUsuario
    {
        private DALConexiones dal = new DALConexiones();

        public List<Usuario> Listar()
        {
            return dal.Listar();
        }
    }
}
