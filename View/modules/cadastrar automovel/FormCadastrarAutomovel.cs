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

namespace FormGaragem.View.modules.cadastrar_automovel
{
    public partial class FormCadastrarAutomovel : Form
    {
        public void carregarDadosComboBox()
        {
            Fabricante fabricante = new Fabricante();
            comb_fabricante.DataSource = fabricante.GetFabricantes();
            comb_fabricante.ValueMember = "id";
            comb_fabricante.DisplayMember = "nome";

            Combustivel combustivel = new Combustivel();
            comb_combustivel.DataSource = combustivel.GetCombustivel();
            comb_combustivel.ValueMember = "id";
            comb_combustivel.DisplayMember = "nome";

            Tipo tipo = new Tipo();
            comb_tipo.DataSource = tipo.GetTipo();
            comb_tipo.ValueMember = "id";
            comb_tipo.DisplayMember = "nome";
        }

        public FormCadastrarAutomovel()
        {
            InitializeComponent();
            carregarDadosComboBox();
        }

        private void btn_cad_caracteristicas_Click(object sender, EventArgs e)
        {
            FormCadastrarCaracteristicas frm = new FormCadastrarCaracteristicas();
            frm.Show();
            this.Close();
        }

        private void btn_cad_automovel_Click(object sender, EventArgs e)
        {
            string id_fabricante = comb_fabricante.SelectedValue.ToString();
            string id_combustivel = comb_combustivel.SelectedValue.ToString();
            string id_tipo = comb_tipo.SelectedValue.ToString();
        }
    }
}
