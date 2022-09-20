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
            if (btnInserir.Text == "INSERIR")
            { 
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into agenda (titulo,hora,data,descricao) values ('" + txtTitulo.Text + "', '" + cmbHora.Text + "', '" + dtpData.Text + "', '" + rtbDescricao.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            pegaData();
            mostrarAgenda();
            limparAgenda();
        }





        void limparAgenda()
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






        void mostrarAgenda() // void mostrar é mostrar todas as informações do banco
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306";
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





        void verificaVazioAgenda()
        {
            if (txtTitulo.Text == "" || cmbHora.Text == "" || dtpData.Text == ""|| rtbDescricao.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }

        }




        void pegaData()
        {
            DateTime data = dtpData.Value;
            string dataCurta = data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            string dataNova = vetData[2] + "-" + vetData[1] + "-" + vetData[0];

            MessageBox.Show(dataNova);
        }






        private void dgwAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwAgenda.CurrentRow.Index != -1)
            {

                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                dtpData.Text = dgwAgenda.CurrentRow.Cells[3].Value.ToString();
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();


                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "NOVO";
            }
        }
    }
}
