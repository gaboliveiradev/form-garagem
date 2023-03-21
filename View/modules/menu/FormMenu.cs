using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormGaragem.View.modules.cadastrar_automovel;

namespace FormGaragem.View.modules.menu
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btn_cad_caracteristicas_Click(object sender, EventArgs e)
        {
            FormCadastrarCaracteristicas frm = new FormCadastrarCaracteristicas();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_form_cad_automovel_Click(object sender, EventArgs e)
        {
            FormCadastrarAutomovel frm = new FormCadastrarAutomovel();
            frm.Show();
            this.Close();
        }
    }
}
