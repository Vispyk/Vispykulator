using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Calc46
{

    enum Operation
    {
        none,
        plus,
        minus,
        mult,
        div
    }

    public partial class Form1 : Form
    {
        double stored = 0;
        Operation oper = Operation.none;
        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        private void numberClick(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void operationClick(object sender, EventArgs e)
        {
            stored = double.Parse(textBox1.Text);
            textBox1.Text = "0";

            switch ((sender as Button).Text)
            {
                case "+": oper = Operation.plus; break;
                case "-": oper = Operation.minus; break;
                case "x": oper = Operation.mult; break;
                case "/": oper = Operation.div; break;

            }
        }

        private void equalClick(object sender, EventArgs e)
        {
            double current = double.Parse(textBox1.Text);

            double rez = 0;

            switch (oper)
            {
                case Operation.plus: rez = stored + current; break;
                case Operation.minus: rez = stored - current; break;
                case Operation.mult: rez = stored * current; break;
                case Operation.div: rez = stored / current; break;

            }

            textBox1.Text = rez.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                textBox1.Text = "0";

            if (textBox1.Text.Length > 1 && textBox1.Text[0] == '0')
                textBox1.Text = textBox1.Text.Substring(1);
         }

        private void clearClick(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            stored = 0;
            oper = Operation.none;
        }

        private void sqrtcalc(object sender, EventArgs e)
        {
            double value = double.Parse(textBox1.Text);
            if (value < 0)
            {
                MessageBox.Show("Нельзя извлечь корень из отрицательного числа");
                return;
            }
            double result = Math.Sqrt(value);
            textBox1.Text = result.ToString();
        }

        private void delClick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void musicClick(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("retroVispyk.wav");
            player.Play();
        }

        private void Brain(object sender, EventArgs e)
        {
            int randomNumber = rnd.Next(0, 101); 
            textBox1.Text = randomNumber.ToString();
        }
    }
}
