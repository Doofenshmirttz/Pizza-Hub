using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizza
{
    
    public partial class FrmEliminar : Form
    {
        int indice;
        bool existencia = false;
        public FrmEliminar()
        {
            InitializeComponent();
            txtbNombreCliente.Enabled = true;
            nudId.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Los datos borrados NO SE VOLVERAN A RECUPERAR", "¿Desea Borrar los datos? ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(resultado== DialogResult.Yes)
            {
                FrmMenuPrincipal.ListaPizza.RemoveAt(indice);

                txtbNombreCliente.Enabled = true;
                nudId.Enabled = true;

                
                btnBuscar.Enabled = true;
                btnEliminar.Enabled = false;
                txtbNombreCliente.Text = "";
                nudId.Value = nudId.Minimum;
                MessageBox.Show("Datos borrados exitosamente", "Datos borrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstbPizzas.Items.Clear();
            }
            else
            {
                txtbNombreCliente.Enabled = true;
                nudId.Enabled = true;


                btnBuscar.Enabled = true;
                btnEliminar.Enabled = false;
                txtbNombreCliente.Text = "";
                nudId.Value = nudId.Minimum;
                lstbPizzas.Items.Clear();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (ClsPizza pizza in FrmMenuPrincipal.ListaPizza)
            {
                if (pizza.Id == nudId.Value && pizza.Cliente == txtbNombreCliente.Text)
                {
                    
                    txtbNombreCliente.Enabled = false;
                    nudId.Enabled = false;
                    existencia = true;
                    
                    btnBuscar.Enabled = false;
                    btnEliminar.Enabled = true;
                    indice = FrmMenuPrincipal.ListaPizza.IndexOf(pizza);

                    
                    lstbPizzas.Items.Add(string.Format("Cliente: {0}", pizza.Cliente));
                    lstbPizzas.Items.Add(string.Format("Tipo de pizza: {0}", pizza.Descripcion));
                    lstbPizzas.Items.Add(string.Format("Pedazos: {0}", pizza.Size));
                    lstbPizzas.Items.Add(string.Format("Cantidad: {0}", pizza.Cantidad));
                    lstbPizzas.Items.Add(string.Format("Precio: {0}", pizza.Precio));

                    MessageBox.Show("Se encontró una incidencia", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }

            }

            if (existencia == false)
            {
                MessageBox.Show("No se encontraron incidencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
