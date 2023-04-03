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
    public partial class FrmAgregar : Form
    {
        public void calcular()
        {
            txtbPrecio.Text = Convert.ToString((nudSize.Value * 150) * (nudCantidad.Value));
        }

        

        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbCliente.Text) && !string.IsNullOrEmpty(cmbbDescripcion.Text))
            {

                if (nudSize.Value > 0 && nudCantidad.Value > 0)
                {
                    ClsPizza pizza = new ClsPizza();

                    pizza.Size = Convert.ToInt32(nudSize.Value);
                    pizza.Cliente = txtbCliente.Text;
                    
                    pizza.Descripcion = cmbbDescripcion.Text;
                    pizza.Cantidad = Convert.ToInt32(nudCantidad.Value);
                    pizza.Precio = Convert.ToDouble(txtbPrecio.Text);
                    pizza.Id = FrmMenuPrincipal.Numero;


                    FrmMenuPrincipal.ListaPizza.Add(pizza);
                    lstbPizzas.Items.Add("\n\n");
                    lstbPizzas.Items.Add(string.Format("---- Pedido {0} ----", FrmMenuPrincipal.Numero));
                    lstbPizzas.Items.Add("\n");
                    lstbPizzas.Items.Add(string.Format("Cliente: {0}", pizza.Cliente));
                    lstbPizzas.Items.Add(string.Format("Tipo de pizza: {0}", pizza.Descripcion));
                    lstbPizzas.Items.Add(string.Format("Pedazos: {0}", pizza.Size));
                    lstbPizzas.Items.Add(string.Format("Cantidad: {0}", pizza.Cantidad));
                    lstbPizzas.Items.Add(string.Format("Precio: {0}", pizza.Precio));
                    FrmMenuPrincipal.Numero++;

                    MessageBox.Show("Pedido Agregado Exitosamente");

                }
                else
                {
                    MessageBox.Show("Cantidad o Tamaño de pedido inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Llene los campos necesarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            calcular();
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
