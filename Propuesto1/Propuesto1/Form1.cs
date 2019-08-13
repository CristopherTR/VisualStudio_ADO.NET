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
using System.Configuration;


namespace Propuesto1
{
    public partial class Form1 : Form
    {
        public Form1()
           
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Propuesto1.Properties.Settings.Valor"].ConnectionString);
        public void ListaClientes()
        {
            string Variable = txtBuscar.Text;
            using (SqlDataAdapter df = new SqlDataAdapter("USP_LISTACLIENTES_NEPTUNO", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.Value = Variable;
                sqlParameter.Size = 100;
                sqlParameter.ParameterName = "@Nombre";

                df.SelectCommand.Parameters.Add(sqlParameter);

                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Clientes");
                    dgClientes.DataSource = Da.Tables["Clientes"];
                    lblCantidad.Text = Da.Tables["Clientes"].Rows.Count.ToString();


                }
            }
        }
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            ListaClientes();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ListaClientes();
        }
   
    }

}
