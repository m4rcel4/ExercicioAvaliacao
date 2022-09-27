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
    public partial class ContasReceber : Form
    {
        public ContasReceber()
        {
            InitializeComponent();
            mostrar();
            btnAlterar.Visible = false;
            btnDeletar.Visible = false;
        }
        string continua = "yes";



        private void btnInserir_Click(object sender, EventArgs e)
        {
          

            verificaVazio();
            pegaData();
            recebimento();


            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                
                try
                {
                    
                   
                    // tipo 0 é definido para contas a receber

                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into contas (nome, descricao,valor,dataVencimento,pago_recebido,tipo) values ('" + txtNome.Text + "', '" + txtDescricao.Text + "','" + txtValor.Text + "','" + Globals.DataVencimento + "' ,'" + Globals.Recebimento + "', '" + 0 +"')";
                        // usei 0 para definir o tipo dessa conta -> receber
                        
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

        // metodos

        void mostrar()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Select * from contas where tipo=0";  // vai mostrar somente os dados de 'contas a RECEBER"
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwContasReceber.DataSource = table;

                    dgwContasReceber.AutoGenerateColumns = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        void limpar()
        {
            txtIdContasReceber.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            cbRecebido.Text = "";
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



       /* private void dtpDataVencimento_ValueChanged(object sender, EventArgs e)
        {
        }*/

        private void dgwContasReceber_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContasReceber.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasReceber.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasReceber.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasReceber.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasReceber.CurrentRow.Cells[4].ToString());
                cbRecebido.Text = dgwContasReceber.CurrentRow.Cells[7].Value.ToString();


                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
            }

        }


        void pegaData()// método para a data que o sitema retorna ser compatível com o modelo exigido pelo banco
        {
            Globals.DataVenc = dtpDataVencimento.Value;// usei a variável criada no GLOBALS, ela vai receber o valor da dtpData
            string dataCurta = Globals.DataVenc.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            Globals.DataVencimento = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";

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
                    string sql = "Update contas set nome='" + txtNome.Text + "', descricao='" + txtDescricao.Text + "',valor='" + txtValor.Text + "', pago_recebido='" + Globals.Recebimento + "' where idContas='" + txtIdContasReceber.Text + "'";
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





        void recebimento()
        {

            if (cbRecebido.Checked)
            {
                Globals.Recebimento = 1;

            }
            else
            {
                Globals.Recebimento = 0;
            }

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
                        string sql = "Delete from contas where idContas = '" + txtIdContasReceber.Text + "'";
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

        private void dtpDataVencimento_ValueChanged(object sender, EventArgs e)
        {

        }
    }

       
}
