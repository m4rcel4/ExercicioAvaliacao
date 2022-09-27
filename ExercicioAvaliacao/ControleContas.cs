using System;
using MySql.Data.MySqlClient;
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
            btnPagar.Visible = false;
            btnReceber.Visible = false;
            MostrarPagar();
            MostrarReceber();
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

        void MostrarPagar() // mostra as contas que tem a pagar na dataGridView desse form
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






        void MostrarReceber() // vai mostrar as contas que faltam ser recebidas na dataGridView apenas
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
                    dgwContasReceber.DataSource = table;
                    dgwContasReceber.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }










        private void btnPagar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Deseja efetuar o pagamento?", "PAGAMENTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {

                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set pago_recebido=1  where idContas = '" + txtIdContasP.Text + "'"; //Comando que coloca o pago_recebido como 'Pago'.
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pagamento efetuado com sucesso!");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
            MostrarPagar();


        }









        private void btnReceber_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("Confirmar o recebimento?", "RECEBIMENTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {


                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "update contas set pago_recebido=1 where idContas = '" + txtIdContasR.Text + "'";  //Comando que coloca o pago_recebido como 'Recebido', inserindo no banco também a data de pagamento dessa conta.
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dinheiro recebido com sucesso!");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            MostrarReceber();



        }









        //private void dgwContasPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}

        //private void dgwContasReceber_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}

        private void dgwContasPagar_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnPagar.Visible = true;


            if (dgwContasPagar.CurrentRow.Index != -1)
            {
                txtIdContasP.Text = dgwContasPagar.CurrentRow.Cells[0].Value.ToString();
            }
            // precisa fazer com que o txtIdContasP seja criado para: fazer puxar id de tal conta, fazer a alteração de pagar.
            // o botão pagar vai usar esse txtIdContasP para fazer o update no banco

        }

        private void dgwContasReceber_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnReceber.Visible = true;
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContasR.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString(); // o txtIdContasR é o único que vai receber uma informação da dataGrid, porque não tem mais txts nesse form
            }
            // o botão receber usa o id para fazer um update no banco

        }
    }
}
