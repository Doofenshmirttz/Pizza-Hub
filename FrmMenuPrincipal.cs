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
    public partial class FrmMenuPrincipal : Form
    {
        private static int numero = 1;

        public static  int Numero { get => numero; set => numero = value; }
        private static List<ClsPizza> listaPizza = new List<ClsPizza>();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        internal static List<ClsPizza> ListaPizza { get => listaPizza; set => listaPizza = value; }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(listaPizza.Count() == 0)
            {
                MessageBox.Show("Falta de registros", "No hay registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtgvPedidos.Rows.Clear();
            foreach (ClsPizza pizza in ListaPizza)
            {

                dtgvPedidos.Rows.Add(pizza.Cliente, pizza.Descripcion, pizza.Size, pizza.Precio, pizza.Cantidad, pizza.Id);
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar fagregar = new FrmAgregar();
            fagregar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificar fmodificar = new FrmModificar();
            fmodificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar feliminar = new FrmEliminar();
            feliminar.Show();
        }
    }
}
