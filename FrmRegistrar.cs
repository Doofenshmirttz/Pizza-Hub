using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizza
{
    public partial class FrmRegistrar : Form
    {
        
        public FrmRegistrar()
        {
            InitializeComponent();
        }

        private void FrmRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string correo = txtbCorreo.Text;
            if (!string.IsNullOrEmpty(txtbNClave.Text) && !string.IsNullOrEmpty(txtbNUsuario.Text) && !string.IsNullOrEmpty(txtbCorreo.Text))
            {
                if (FrmLogin.ListaUsuarios.Any(y => y.Nombre == txtbNUsuario.Text && y.Clave == txtbNClave.Text || y.Correo == txtbCorreo.Text))
                {
                    MessageBox.Show("Usuario ya existente","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (correo.Contains('@') && correo.Contains(".com"))
                    {


                        ClsUsuario usuario = new ClsUsuario();
                        usuario.Nombre = txtbNUsuario.Text;
                        usuario.Clave = txtbNClave.Text;
                        usuario.Correo = txtbCorreo.Text;
                        FrmLogin.ListaUsuarios.Add(usuario);
                        MessageBox.Show("Registro exitoso");
                        txtbCorreo.Clear();
                        txtbNClave.Clear();
                        txtbNUsuario.Clear();



                    }
                    else
                    {
                        MessageBox.Show("Correo inválido", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                }
            }
            else
            {
                MessageBox.Show("No deje campos vacíos","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
