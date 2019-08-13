using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace pjConexion2
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=LAB402-12\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Select * from clientes", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "clientes");
                    dgClientes.DataSource = Da.Tables["clientes"];
                    lblTotal.Text = Da.Tables["clientes"].Rows.Count.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'neptunoDataSet.clientes' Puede moverla o quitarla según sea necesario.
            ListaClientes();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
