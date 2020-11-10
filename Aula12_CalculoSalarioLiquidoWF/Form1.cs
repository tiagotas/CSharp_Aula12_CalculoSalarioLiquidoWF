using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula12_CalculoSalarioLiquidoWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Formato do número para R$
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;

            // Obtendo valores digitados na interface e convertendo.
            double salario_base = Convert.ToDouble(txtSalarioBase.Text);
            int qnt_dependentes = Convert.ToInt32(txtDependentes.Text);


            // Istanciando a classe que faz o cálculo do salário liquido.
            CalculadoraSalarioLiquido cc = new CalculadoraSalarioLiquido(salario_base, qnt_dependentes);


            // Obtendo os valores dos impostos a calcular.
            txtDescINSS.Text = cc.TotalINSS.ToString("C", nfi);
            txtDescIRPF.Text = cc.TotalIRPF.ToString("C", nfi);


            double salario_liquido = salario_base - (cc.TotalINSS + cc.TotalIRPF);

            txtSalarioLiquido.Text = salario_liquido.ToString("C", nfi);
        }
    }
}
