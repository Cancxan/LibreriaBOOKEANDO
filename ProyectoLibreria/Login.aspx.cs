using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using Servicios;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private BLLUsuario bllUsuarios = new BLLUsuario();
    
    Usuario usuario;
    private int failedAttempts = 0;
    private const int maxFailedAttempts = 3;
    protected void Button1_Click(object sender, EventArgs e)
    {
        
             
        string passwordHash = HashHelper.CalcularSHA256(TextBox2.Text);

        if (SessionManager.Instance.IsLoggedIn_013AL())
        {
            MessageBox.Show("Ya hay un usuario logueado. Cierre la sesión actual antes de iniciar una nueva.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        var usuarios = bllUsuarios.Listar();
        var usuario = usuarios.FirstOrDefault(u => u.Login == TextBox1.Text);

        if (usuario == null)
        {
            MessageBox.Show("Usuario no encontrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (usuario.Bloqueo)
        {
            MessageBox.Show("El usuario está bloqueado. No puede iniciar sesión.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (usuario.Activo == false)
        {
            MessageBox.Show("El usuario está Desactivado. No puede iniciar sesión.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        if (usuario.Contraseña == passwordHash)
        {

            SessionManager.Instance.Login_013AL(usuario);

            MessageBox.Show("Login exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            
        }
        else
        {
            failedAttempts++;
            if (failedAttempts >= maxFailedAttempts)
            {
                bllUsuarios.BloquearUsuario_013AL(txtUsuario.Text);
                MessageBox.Show("Usuario bloqueado después de 3 intentos fallidos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
            else
            {
                MessageBox.Show($"Usuario y/o Contraseña incorrectos. Intento {failedAttempts} de {maxFailedAttempts}", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*if (SessionManager.Instance.IsLoggedIn_013AL())
        {

            string dni = SessionManager.Instance.GetUsuario_013AL().DNI;


            List<Componente_013AL> permisos = per.ListarPermisos_013AL(dni);

            //List<string> nombresPermisos = new List<string>();
            foreach (var permiso in permisos)
            {
                string nombre = per.ObtenerNombrePermiso_013AL(permiso.Cod_013AL);
                permiso.Nombre_013AL = nombre;
                //permisos.Add(nombre);
            }

            SingletonSession_013AL.Instance.Permisos_013AL = permisos;


            usuario.AsignarPermisos_013AL(permisos);

        }*/

    }
}