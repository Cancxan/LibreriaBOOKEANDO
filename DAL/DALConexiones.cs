using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DALConexiones
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QM84P0N\SQLEXPRESS;Initial Catalog=LibreriaProyecto;Integrated Security=True");
        SqlCommand com;

        public List<Usuario> Listar()
        {
            List<Usuario> Lista = new List<Usuario>();
            try
            {
                com = new SqlCommand("ListarUsuarios", con);
                com.CommandType = CommandType.StoredProcedure;

                con.Open();


                using (SqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int idRol = Convert.ToInt32(dr["CodRol"]);
                        Rol rol = new Rol { CodRol = idRol };
                        Lista.Add(new Usuario()
                        {
                            Login = dr["Login"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                            //ID = Convert.ToInt32(dr["Id"]),
                            DNI = dr["DNI"].ToString(),
                            Bloqueo = (bool)dr["Bloqueo"],
                            Rol = rol,
                            Activo = (bool)dr["Activo"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios", ex);
            }
            finally
            {
                con.Close();
            }

            return Lista;
        }
    }
}
