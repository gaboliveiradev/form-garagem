using FormGaragem.Model;
using FormGaragem.View.modules.menu;
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

            if (txt_modelo.Text == "" || txt_placa.Text == "" || txt_cor.Text == "" || txt_obs.Text == "")
            {
                exibirMsg("Porfavor, preencha todos os campos para cadastrar um automovél.");
            } else
            {
                Automovel model = new Automovel()
                {
                    modelo = txt_modelo.Text.ToUpper(),
                    ano = nud_ano.Value.ToString(),
                    placa = txt_placa.Text.ToUpper(),
                    cor = txt_cor.Text.ToUpper(),
                    quilometragem = num_km.Value.ToString(),
                    id_fabricante = int.Parse(id_fabricante.ToString()),
                    id_combustivel = int.Parse(id_combustivel.ToString()),
                    id_tipo = int.Parse(id_tipo.ToString()),
                    revisao = cb_revisao.Checked,
                    sinistro = cb_sinistro.Checked,
                    furto = cb_furto.Checked,
                    aluguel = cb_aluguel.Checked,
                    venda = cb_venda.Checked,
                    particular = cb_particular.Checked,
                    observacao = txt_obs.Text.ToUpper(),
                };

                model.Incluir();
                LimparCampos();
            }

            loadGrid();
        }

        public void LimparCampos()
        {
            txt_cor.Clear();
            num_km.Value = 0;
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

        private void pic_cancelar_Click(object sender, EventArgs e)
        {
            ocultarMsg();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            FormMenu form = new FormMenu();
            form.Show();
            this.Close();
        }
    }
}
