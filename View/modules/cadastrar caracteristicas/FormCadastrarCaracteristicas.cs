using FormGaragem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormGaragem.View.modules.menu;

namespace FormGaragem.View.modules.cadastrar_automovel
{
    public partial class FormCadastrarCaracteristicas : Form
    {
        public FormCadastrarCaracteristicas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cad_combu_Click_1(object sender, EventArgs e)
        {
            Combustivel model = new Combustivel()
            {
                nome = txt_combu.Text.ToUpper(),
            };

            if (model.Incluir())
            {
                lbl_aviso.Text = $"NOVO COMBUSTIVÉL \"{txt_combu.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.";
                lbl_aviso.Visible = true;
            }
            else
            {
                lbl_aviso.Visible = true;
                lbl_aviso.Text = $"OCORREU UM ERRO AO TENTAR ADICIONAR O COMBUSTIVÉL \"{txt_combu.Text.ToUpper()}\"";
            }

            txt_combu.Clear();
        }

        private void cad_fabricante_Click(object sender, EventArgs e)
        {
            Fabricante model = new Fabricante()
            {
                nome = txt_fabricante.Text.ToUpper(),
            };

            if (model.Incluir())
            {
                lbl_aviso.Text = $"NOVO FABRICANTE \"{txt_fabricante.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.";
                lbl_aviso.Visible = true;
            }
            else
            {
                lbl_aviso.Visible = true;
                lbl_aviso.Text = $"OCORREU UM ERRO AO TENTAR ADICIONAR O FABRICANTE \"{txt_fabricante.Text.ToUpper()}\"";
            }

            txt_fabricante.Clear();
        }

        private void cad_tipo_Click(object sender, EventArgs e)
        {
            Tipo model = new Tipo()
            {
                nome = txt_tipo.Text.ToUpper(),
            };

            if (model.Incluir())
            {
                lbl_aviso.Text = $"NOVO TIPO \"{txt_tipo.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.";
                lbl_aviso.Visible = true;
            }
            else
            {
                lbl_aviso.Visible = true;
                lbl_aviso.Text = $"OCORREU UM ERRO AO TENTAR ADICIONAR O TIPO \"{txt_tipo.Text.ToUpper()}\"";
            }

            txt_tipo.Clear();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            frm.Show();
            this.Close();
        }
    }
}
