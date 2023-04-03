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
    public partial class FrmModificar : Form
    {
        bool existencia = false;
        int indice;

        public void calcular()
        {
            txtbPrecio.Text = Convert.ToString((nudSize.Value * 150) * (nudCantidad.Value));
        }
        public FrmModificar()
        {
            InitializeComponent();
            txtbNombreCliente.Enabled = true;
            nudId.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach(ClsPizza pizza in FrmMenuPrincipal.ListaPizza)
            {
                if (pizza.Id == nudId.Value && pizza.Cliente == txtbNombreCliente.Text)
                {
                    txtbCliente.Enabled = true;
                    cmbbDescripcion.Enabled = true;
                    nudCantidad.Enabled = true;
                    nudSize.Enabled = true;
                    txtbNombreCliente.Enabled = false;
                    nudId.Enabled = false;

                    txtbCliente.Text = pizza.Cliente;
                    cmbbDescripcion.Text = pizza.Descripcion;
                    nudCantidad.Value = pizza.Cantidad;
                    nudSize.Value = pizza.Size;
                    txtbPrecio.Text = Convert.ToString(pizza.Precio);
                    existencia = true;
                    btnBuscar.Enabled = false;
                    btnAgregar.Enabled = true;
                    indice = FrmMenuPrincipal.ListaPizza.IndexOf(pizza);
                    
                    MessageBox.Show("Se encontró una incidencia", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break; 
                }

            }

            if(existencia == false)
            {
                MessageBox.Show("No se encontraron incidencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if(!string.IsNullOrEmpty(txtbCliente.Text) && !string.IsNullOrEmpty(cmbbDescripcion.Text)) 
            {
                DialogResult resultado = MessageBox.Show("¿Desea guardar las modificaciones?", "Guardar modificaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    FrmMenuPrincipal.ListaPizza[indice].Size = Convert.ToInt32(nudSize.Value);
                    FrmMenuPrincipal.ListaPizza[indice].Cliente = txtbCliente.Text;

                    FrmMenuPrincipal.ListaPizza[indice].Descripcion = cmbbDescripcion.Text;
                    FrmMenuPrincipal.ListaPizza[indice].Cantidad = Convert.ToInt32(nudCantidad.Value);
                    FrmMenuPrincipal.ListaPizza[indice].Precio = Convert.ToDouble(txtbPrecio.Text);
                    MessageBox.Show("Modificación realizada", "Genial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnAgregar.Enabled = false;
                    txtbCliente.Enabled = false;
                    cmbbDescripcion.Enabled = false;
                    nudCantidad.Enabled = false;
                    nudSize.Enabled = false;
                    txtbNombreCliente.Enabled = true;
                    nudId.Enabled = true;
                    btnBuscar.Enabled = true;
                    txtbCliente.Text = "";
                    cmbbDescripcion.Text = "";
                    nudCantidad.Value = nudCantidad.Minimum;
                    nudSize.Value = nudSize.Minimum;
                    txtbNombreCliente.Text = "";
                    nudId.Value = nudId.Minimum;

                }
                else
                {
                    btnAgregar.Enabled = false;
                    txtbCliente.Enabled = false;
                    cmbbDescripcion.Enabled = false;
                    nudCantidad.Enabled = false;
                    nudSize.Enabled = false;
                    txtbNombreCliente.Enabled = true;
                    nudId.Enabled = true;
                    btnBuscar.Enabled = true;
                    txtbCliente.Text = "";
                    cmbbDescripcion.Text = "";
                    nudCantidad.Value = nudCantidad.Minimum;
                    nudSize.Value = nudSize.Minimum;
                    txtbNombreCliente.Text = "";
                    nudId.Value = nudId.Minimum;
                }
            }
            else
            {
                MessageBox.Show("Llene los datos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            calcular();
        }
    }
}
