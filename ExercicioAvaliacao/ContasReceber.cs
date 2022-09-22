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
        }
        string continua = "yes";



        private void btnInserir_Click(object sender, EventArgs e)
        {
            DateTime data = dtpDataVencimento.Value;
            string dataCurta = data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            string dataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";







            verificaVazio();


            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                int recebido;

                try
                {
                    if (cbRecebido.Checked)
                    {
                        recebido = 0;
                    }
                    else
                    {
                        recebido = 1;
                    }


                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into contas (nome, descricao,valor,dataVencimento,pago_recebido,tipo) values ('" + txtNome.Text + "', '" + txtDescricao.Text + "','" + txtValor.Text + "', dataNova,recebido, 0 )";
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
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                    cnn.Open();
                    string sql = "Select * from contas";
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










        private void dtpDataVencimento_ValueChanged(object sender, EventArgs e)
        {


        }

        private void dgwContasReceber_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdContasReceber.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgwContasReceber.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = dgwContasReceber.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = dgwContasReceber.CurrentRow.Cells[3].Value.ToString();
            cbRecebido.Text = dgwContasReceber.CurrentRow.Cells[4].Value.ToString();

            btnDeletar.Visible = true;
            btnAlterar.Visible = true;
            btnInserir.Text = "Novo";
        }
    }

       
}
