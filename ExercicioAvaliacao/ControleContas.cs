using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class ControleContas : Form
    {
        public ControleContas()
        {
            InitializeComponent();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            ContasPagar contasPagar =   new ContasPagar();  
            //contasPagar.MdiParent = this;
            contasPagar.Show(); 
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            ContasReceber contasreceber = new ContasReceber();
            //contasreceber.MdiParent = this;
            contasreceber.Show();   
        }

        void MostrarPagar()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where tipo=1 && pago_recebido=0";     // vai mostrar na dataGridView as contas que NÃO foram pagas
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContasPagar.DataSource = table;
                    dgwContasPagar.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        void MostrarReceber()
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection())
                {
                    cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                    cnx.Open();
                    string sql = "select * from contas where tipo=0 && pago_recebido=0";     // vai mostrar na dataGridView as contas que NÃO foram pagas
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cnx);
                    adapter.Fill(table);
                    dgwContasPagar.DataSource = table;
                    dgwContasPagar.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
