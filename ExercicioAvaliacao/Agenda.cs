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
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        string continua = "yes";


        private void btnInserir_Click(object sender, EventArgs e)
        {
           
           

            verificaVazioAgenda();

            if (continua == "yes")
                pegaData();// colocado antes de fazer a inserção no banco, já que a data precisa ser transformada em "dateTime" antes disso

            {
                try
                {
                   

                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "insert into agenda (titulo,hora,data,descricao) values ('" + txtTitulo.Text + "','" + cmbHora.Text + "','" + Globals.dataNova + "','" + rtbDescricao.Text + "')";
                        // "dataNova" já está convertida em data, pronta para ser inserida no banco.
                        MessageBox.Show("Inserido com sucesso!");
                        MySqlCommand cmd = new MySqlCommand(sql, cnx);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            mostrarAgenda();
            limparAgenda();

        }





        void limparAgenda()// limpa todos os campos e faz o botão, que estava "novo", voltar a "inserir"
        {
            txtIdAgenda.Text = "";
            txtTitulo.Clear();
            cmbHora.Text= "";
            dtpData.Text = "";
            rtbDescricao.Text = ""; 
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }






        void mostrarAgenda() //mostra todas as informações do banco na DataGridView
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Select * from agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;

                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        void verificaVazioAgenda()// não deixa inserir no banco quando esses dois txts não estiverem preenchidos
        {
            if (txtTitulo.Text == "" || rtbDescricao.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }

        }




     
        private void dgwAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {

                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());
                //converte para dateTime, porque o sistema retorna a data em string, mas o banco só aceita date
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();


                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "NOVO";
            }
        }




        void pegaData()// método para a data que o sitema retorna ser compatível com o modelo exigido pelo banco
        {
             Globals.Data = dtpData.Value;// usei a variável criada no GLOBALS, ela vai receber o valor da dtpData
            string dataCurta = Globals.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            Globals.DataNova = $"{vetData[2]}-{vetData[1]}-{vetData[0]}";

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
                    string sql = "Update agenda set titulo='" + txtTitulo.Text + "', hora='" + cmbHora.Text + "',data='" + Globals.DataNova + "', descricao='" + rtbDescricao.Text + "' where idAgenda='" + txtIdAgenda.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            mostrarAgenda();



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
                        string sql = "Delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Deletado com sucesso! ");

                    }
                    limparAgenda();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            mostrarAgenda();

        }
    }
}
