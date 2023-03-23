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
        public FormCadastrarAutomovel()
        {
            InitializeComponent();
            Fabricante fbt = new Fabricante();
            int i = 0;
            foreach (string fabricante in fbt.GetFabricantes())
            {
                Console.WriteLine(fabricante);
                i++;
            }

        }

        private void btn_cad_caracteristicas_Click(object sender, EventArgs e)
        {
            FormCadastrarCaracteristicas frm = new FormCadastrarCaracteristicas();
            frm.Show();
            this.Close();
        }
    }
}
