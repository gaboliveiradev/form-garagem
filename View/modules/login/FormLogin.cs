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
using FormGaragem.Model;
using FormGaragem.View.modules.forget_password;
using FormGaragem.View.modules.menu;
using FormGaragem.Helpers;

namespace FormGaragem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Banco.createDB();
        }

        // ================ Métodos Adicionais ================
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

        // ================ Metodos dos Componentes do Forms ================
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

            Usuario model = new Usuario()
            {
                nome = txt_user.Text.ToUpper(),
                senha = txt_password.Text
            };

            bool status = model.autenticarLogin();

            if(status)
            {
                FormMenu form = new FormMenu();
                this.Hide();
                form.Show();
            } else
            {
                lbl_warning.Text = "Usuário e/ou senha incorretos.";
                pnl_aviso.Visible = true;
                lbl_warning.Visible = true;
                pic_exit_warning.Visible = true;
            }
        }

        private void pic_exit_warning_Click(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
            pnl_aviso.Visible = false;
            pic_exit_warning.Visible = false;
        }

        private void pic_confirmar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pic_cancelar_Click(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
            pnl_aviso.Visible = false;
            pic_confirmar.Visible = false;
            pic_cancelar.Visible = false;
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            pic_limpar_username.Visible = true;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            pic_limpar_senha.Visible = true;
        }

        private void pic_limpar_username_Click(object sender, EventArgs e)
        {
            txt_user.Clear();
            pic_limpar_username.Visible = false;
        }

        private void pic_limpar_senha_Click(object sender, EventArgs e)
        {
            txt_password.Clear();
            pic_limpar_senha.Visible = false;
        }

        private void lbl_forget_password_Click(object sender, EventArgs e)
        {
            FormForgetPassword frmForgetPassword = new FormForgetPassword();
            this.Hide();
            frmForgetPassword.Show();
        }
    }
}
