﻿using MySql.Data.MySqlClient;
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
                pegaData();

            {
                try
                {
                   

                    using (MySqlConnection cnx = new MySqlConnection())
                    {
                        cnx.ConnectionString = "server = localhost; database = controle; uid = root; pwd =; port = 3306; Convert Zero DateTime = true";
                        cnx.Open();
                        string sql = "insert into agenda (titulo,hora,data,descricao) values ('" + txtTitulo.Text + "','" + cmbHora.Text + "','" + Globals.dataNova + "','" + rtbDescricao.Text + "')";
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





        void verificaVazioAgenda()
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
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();


                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "NOVO";
            }
        }




        void pegaData()
        {
             Globals.Data = dtpData.Value;
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
