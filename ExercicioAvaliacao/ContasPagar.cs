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
    public partial class ContasPagar : Form
    {
        public ContasPagar()
        {
            InitializeComponent();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
            mostrar();
        }

        string continua = "yes";

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private void btnInserir_Click(object sender, EventArgs e)
        {

            verificaVazio();
            pegaData();
            pagamento();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {

                try
                {


                    // tipo 1 é definido para contas a pagar

                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into contas (nome, descricao,valor,dataVencimento,pago_recebido,tipo) values ('" + txtNome.Text + "', '" + txtDescricao.Text + "','" + txtValor.Text + "','" + Globals.DataVencimento + "' ,'"+ Globals.Pago+"', '" + 1 + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();



                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

            mostrar();
            limpar();


        }







        void mostrar()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Select * from contas where tipo=1";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwContasPagar.DataSource = table;

                    dgwContasPagar.AutoGenerateColumns = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        void limpar()
        {
            txtIdContasPagar.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            cbPago.Checked = false;
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;



        }

        void verificaVazio()
        {
            if (txtNome.Text == "" || txtDescricao.Text == "" || txtValor.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }

        }




        void pegaData()// método para a data que o sitema retorna ser compatível com o modelo exigido pelo banco
        {
            Globals.DataVenc = dtpDataVencimento.Value;// usei a variável criada no GLOBALS, ela vai receber o valor da dtpData
            string dataCurta = Globals.DataVenc.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            Globals.DataVencimento = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";

        }



        void pagamento()
        {

            if (cbPago.Checked)
            {
                Globals.Pago = 1;

            }
            else
            {
                Globals.Pago = 0;
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pegaData();

            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Update contas set nome='" + txtNome.Text + "', descricao='" + txtDescricao.Text + "',valor='" + txtValor.Text + "', pago_recebido='" + Globals.pago + "' where idContas='" + txtIdContasPagar.Text + "'";
                    //idContas vai ser igual ao txtIdContasRecber. é a mesma tabela, mas o id vai diferenciar se é a pagar ou receber
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            mostrar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir", "Confirmação", MessageBoxButtons.YesNo))
            {

                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Delete from contas where idContas = '" + txtIdContasPagar.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Deletado com sucesso! ");

                    }
                    limpar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            mostrar();
        }

        private void dgwContasPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContasPagar.CurrentRow.Index != -1)
            {
                txtIdContasPagar.Text = dgwContasPagar.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasPagar.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasPagar.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasPagar.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasPagar.CurrentRow.Cells[4].ToString());
                cbPago.Text = dgwContasPagar.CurrentRow.Cells[5].Value.ToString();

                string pago = cbPago.Text;

                if (pago == "Pago")             //Condição que vai checkar se no banco estiver escrito 'Pago', se não ele mudará a condição.
                {
                    cbPago.Checked = true;

                }
                else if (pago == "N/E")
                {
                    cbPago.Text = "Pago";
                    cbPago.Checked = false;
                }

                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
            }

        }
    }
}
