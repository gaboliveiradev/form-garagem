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

using FormGaragem.Helpers;
using FormGaragem.View.modules.menu;
using Google.Protobuf.WellKnownTypes;

namespace FormGaragem.View.modules.cadastrar_automovel
{
    public partial class FormCadastrarCaracteristicas : Form
    {
        public FormCadastrarCaracteristicas()
        {
            InitializeComponent();
        }

        public void ocultarMsg()
        {
            pnl_aviso.Visible = false;
            lbl_aviso.Visible = false;
            pic_cancelar.Visible = false;
            pictureBox4.Visible = false;
        }

        public void exibirMsg(string msg)
        {
            lbl_aviso.Text = msg;
            pnl_aviso.Visible = true;
            lbl_aviso.Visible = true;
            pic_cancelar.Visible = true;
            pictureBox4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cad_combu_Click_1(object sender, EventArgs e)
        {
            ThatExists ttE = new ThatExists();
            if (!ttE.exists(txt_combu.Text.ToUpper(), "Combustivel"))
            {
                if(txt_combu.Text == "") 
                {
                    exibirMsg($"O CAMPO \"COMBUSTIVÉL\" ESTÁ VAZIO, PORFAVOR PREENCHA PARA CADASTRAR-LO");
                } else
                {
                    Combustivel model = new Combustivel()
                    {
                        nome = txt_combu.Text.ToUpper(),
                    };

                    if (model.Incluir())
                    {
                        exibirMsg($"NOVO COMBUSTIVÉL \"{txt_combu.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.");
                    }
                    else
                    {
                        exibirMsg($"OCORREU UM ERRO AO TENTAR ADICIONAR O COMBUSTIVÉL \"{txt_combu.Text.ToUpper()}\"");
                    }
                }
            }
            else
            {
                exibirMsg($"JÁ EXISTE UM COMBUSTIVÉL CADASTRADO COMO \"{txt_combu.Text.ToUpper()}\", TENTE OUTRO.");
            }

            txt_combu.Clear();
        }

        private void cad_fabricante_Click(object sender, EventArgs e)
        {
            ThatExists ttE = new ThatExists();
            if (!ttE.exists(txt_fabricante.Text.ToUpper(), "Fabricante"))
            {
                if (txt_combu.Text == "")
                {
                    exibirMsg($"O CAMPO \"FABRICANTE.\" ESTÁ VAZIO, PORFAVOR PREENCHA PARA CADASTRAR-LO");
                } else
                {
                    Fabricante model = new Fabricante()
                    {
                        nome = txt_fabricante.Text.ToUpper(),
                    };

                    if (model.Incluir())
                    {
                        exibirMsg($"NOVO FABRICANTE \"{txt_fabricante.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.");
                    }
                    else
                    {
                        exibirMsg($"OCORREU UM ERRO AO TENTAR ADICIONAR O FABRICANTE \"{txt_fabricante.Text.ToUpper()}\"");
                    }
                }
            }
            else
            {
                exibirMsg($"JÁ EXISTE UM FABRICANTE CADASTRADO COMO \"{txt_fabricante.Text.ToUpper()}\", TENTE OUTRO.");
            }


            txt_fabricante.Clear();
        }

        private void cad_tipo_Click(object sender, EventArgs e)
        {
            ThatExists ttE = new ThatExists();
            if (!ttE.exists(txt_fabricante.Text.ToUpper(), "Tipo"))
            {
                if (txt_combu.Text == "")
                {
                    exibirMsg($"O CAMPO \"TIPO DO AUTOM.\" ESTÁ VAZIO, PORFAVOR PREENCHA PARA CADASTRAR-LO");
                } else
                {
                    Tipo model = new Tipo()
                    {
                        nome = txt_tipo.Text.ToUpper(),
                    };

                    if (model.Incluir())
                    {
                        exibirMsg($"NOVO TIPO \"{txt_tipo.Text.ToUpper()}\" FOI ADICIONADO COM SUCESSO.");
                    }
                    else
                    {
                        exibirMsg($"OCORREU UM ERRO AO TENTAR ADICIONAR O TIPO \"{txt_tipo.Text.ToUpper()}\"");
                    }
                }
            }
            else
            {
                exibirMsg($"JÁ EXISTE UM TIPO DE AUTOMÓVEL CADASTRADO COMO \"{txt_tipo.Text.ToUpper()}\", TENTE OUTRO.");
            }

            txt_tipo.Clear();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            frm.Show();
            this.Close();
        }

        private void pic_cancelar_Click(object sender, EventArgs e)
        {
            ocultarMsg();
        }
    }
}
