﻿namespace ExercicioAvaliacao
{
    partial class ControleContas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwContasPagar = new System.Windows.Forms.DataGridView();
            this.dgwContasReceber = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.btnContasPagar = new System.Windows.Forms.Button();
            this.btnContasReceber = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtIdContasR = new System.Windows.Forms.TextBox();
            this.txtIdContasP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwContasPagar
            // 
            this.dgwContasPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasPagar.Location = new System.Drawing.Point(30, 140);
            this.dgwContasPagar.Name = "dgwContasPagar";
            this.dgwContasPagar.Size = new System.Drawing.Size(584, 190);
            this.dgwContasPagar.TabIndex = 0;
            this.dgwContasPagar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasPagar_CellDoubleClick_1);
            // 
            // dgwContasReceber
            // 
            this.dgwContasReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwContasReceber.Location = new System.Drawing.Point(33, 428);
            this.dgwContasReceber.Name = "dgwContasReceber";
            this.dgwContasReceber.Size = new System.Drawing.Size(584, 190);
            this.dgwContasReceber.TabIndex = 1;
            this.dgwContasReceber.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwContasReceber_CellDoubleClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contas a Pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contas a receber";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(651, 204);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(90, 65);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.Location = new System.Drawing.Point(651, 508);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(90, 65);
            this.btnReceber.TabIndex = 4;
            this.btnReceber.Text = "receber";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnContasPagar
            // 
            this.btnContasPagar.Location = new System.Drawing.Point(741, 12);
            this.btnContasPagar.Name = "btnContasPagar";
            this.btnContasPagar.Size = new System.Drawing.Size(119, 29);
            this.btnContasPagar.TabIndex = 4;
            this.btnContasPagar.Text = "Contas a Pagar";
            this.btnContasPagar.UseVisualStyleBackColor = true;
            this.btnContasPagar.Click += new System.EventHandler(this.btnContasPagar_Click);
            // 
            // btnContasReceber
            // 
            this.btnContasReceber.Location = new System.Drawing.Point(741, 48);
            this.btnContasReceber.Name = "btnContasReceber";
            this.btnContasReceber.Size = new System.Drawing.Size(119, 29);
            this.btnContasReceber.TabIndex = 4;
            this.btnContasReceber.Text = "Contas a Receber";
            this.btnContasReceber.UseVisualStyleBackColor = true;
            this.btnContasReceber.Click += new System.EventHandler(this.btnContasReceber_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(474, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(225, 28);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "PESQUISAR";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // txtIdContasR
            // 
            this.txtIdContasR.Location = new System.Drawing.Point(33, 402);
            this.txtIdContasR.Name = "txtIdContasR";
            this.txtIdContasR.Size = new System.Drawing.Size(51, 20);
            this.txtIdContasR.TabIndex = 6;
            // 
            // txtIdContasP
            // 
            this.txtIdContasP.Location = new System.Drawing.Point(30, 114);
            this.txtIdContasP.Name = "txtIdContasP";
            this.txtIdContasP.Size = new System.Drawing.Size(48, 20);
            this.txtIdContasP.TabIndex = 7;
            // 
            // ControleContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 647);
            this.Controls.Add(this.txtIdContasP);
            this.Controls.Add(this.txtIdContasR);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.btnContasReceber);
            this.Controls.Add(this.btnContasPagar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwContasReceber);
            this.Controls.Add(this.dgwContasPagar);
            this.Name = "ControleContas";
            this.Text = "ControleContas";
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwContasReceber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwContasPagar;
        private System.Windows.Forms.DataGridView dgwContasReceber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.Button btnContasPagar;
        private System.Windows.Forms.Button btnContasReceber;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtIdContasR;
        private System.Windows.Forms.TextBox txtIdContasP;
    }
}