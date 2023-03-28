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
        public void loadGrid()
        {
            Automovel model = new Automovel();
            dgv_automovel.DataSource = model.Query();
        }

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
            loadGrid();
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

            Automovel model = new Automovel()
            {
                modelo = txt_modelo.Text,
                ano = nud_ano.Value.ToString(),
                placa = txt_placa.Text,
                cor = txt_cor.Text,
                quilometragem = txt_km.Text,
                id_fabricante = int.Parse(id_fabricante.ToString()),
                id_combustivel = int.Parse(id_combustivel.ToString()),
                id_tipo = int.Parse(id_tipo.ToString()),
                revisao = cb_revisao.Checked,
                sinistro = cb_sinistro.Checked,
                furto = cb_furto.Checked,
                aluguel = cb_aluguel.Checked,
                venda = cb_venda.Checked,
                particular = cb_particular.Checked,
                observacao = txt_obs.Text,
            };

            model.Incluir();
            LimparCampos();
        }

        public void LimparCampos()
        {
            txt_cor.Clear();
            txt_km.Clear();
            txt_modelo.Clear();
            txt_obs.Clear();
            txt_placa.Clear();
            nud_ano.Value = 0;
            cb_aluguel.Checked = false;
            cb_furto.Checked = false;
            cb_particular.Checked = false;
            cb_revisao.Checked = false;
            cb_sinistro.Checked = false;
            cb_venda.Checked = false;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
