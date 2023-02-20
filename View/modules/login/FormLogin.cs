using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGaragem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void exit_form()
        {
            lbl_warning.Text = "Você tem certeza que deseja sair?";
            lbl_warning.Visible = true;
            pnl_aviso.Visible = true;
            pic_cancelar.Visible = true;
            pic_confirmar.Visible = true;

        }

        private void usuario_senha_obrigatorio()
        {
            if (txt_user.Text == "" || txt_password.Text == "")
            {
                lbl_warning.Text = "Usuário e/ou senha são obrigatórios.";
                pnl_aviso.Visible = true;
                lbl_warning.Visible = true;
                pic_exit_warning.Visible = true;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            exit_form();
        }

        private void pic_exit_Click(object sender, EventArgs e)
        {
            exit_form();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            usuario_senha_obrigatorio();
        }

        private void pic_exit_warning_Click(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
            pnl_aviso.Visible = false;
            pic_exit_warning.Visible = false;
        }

        private void pic_confirmar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_cancelar_Click(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
            pnl_aviso.Visible = false;
            pic_confirmar.Visible = false;
            pic_cancelar.Visible = false;
        }
    }
}
