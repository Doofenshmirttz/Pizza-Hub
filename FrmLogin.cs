namespace pizza
{
    public partial class FrmLogin : Form
    {
        private static List<ClsUsuario> listaUsuarios = new List<ClsUsuario>();

        public FrmLogin()
        {
            InitializeComponent();
        }

        internal static List<ClsUsuario> ListaUsuarios { get => listaUsuarios; set => listaUsuarios = value; }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtbUsuario.Text == "baldwin" && txtbClave.Text == "mena")
            {
                FrmMenuPrincipal menuprincipal = new FrmMenuPrincipal();
                menuprincipal.ShowDialog();
            }
            else if (ListaUsuarios.Any(y => y.Nombre == txtbUsuario.Text && y.Clave == txtbClave.Text))
            {
                FrmMenuPrincipal menuprincipal = new FrmMenuPrincipal();
                menuprincipal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistrar fregistrar = new FrmRegistrar();
            fregistrar.Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}