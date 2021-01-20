using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FibonacciApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Fibonacci sorozat generálás gomb.
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != String.Empty)
            {
                // Az első TextBox ellenőrzése.
                // Amennyiben nem üres és egy szám, legeneráljuk a az első n Fibonacci számot
                // és kiszámítjuk az összegüket (textBox3 és textBox2).
                int numbersToGenerate;
                if(!int.TryParse(this.textBox1.Text, out numbersToGenerate))
                {
                    MessageBox.Show("A megadott érték nem valid.", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textBox1.Select();
                    this.textBox1.Focus();
                }
                int fibonacciSum = 0;
                ArrayList arrayOfNumbersGenerated = new ArrayList();
                var fibonacciInitialNumber1 = 0;
                var fibonacciInitialNumber2 = 1;
                var sb = new StringBuilder();

                if (numbersToGenerate == 0)
                {
                    this.textBox2.Text = fibonacciSum.ToString();
                    return;
                }

                arrayOfNumbersGenerated.Add(fibonacciInitialNumber1);
                fibonacciSum += fibonacciInitialNumber1;
                if (numbersToGenerate == 1)
                {
                    this.textBox2.Text = fibonacciSum.ToString();
                    foreach (int i in arrayOfNumbersGenerated)
                    {
                        sb.Append(i);
                        sb.Append(" ");
                    }
                    this.textBox3.Text = sb.ToString();
                    return;
                }

                arrayOfNumbersGenerated.Add(fibonacciInitialNumber2);
                fibonacciSum += fibonacciInitialNumber2;
                if (numbersToGenerate == 2)
                {
                    this.textBox2.Text = fibonacciSum.ToString();
                    foreach (int i in arrayOfNumbersGenerated)
                    {
                        sb.Append(i);
                        sb.Append(" ");
                    }
                    this.textBox3.Text = sb.ToString();
                    return;
                }

                for (int i = 2; i < numbersToGenerate; i++)
                {
                    int aux = fibonacciInitialNumber1 + fibonacciInitialNumber2;
                    fibonacciInitialNumber1 = fibonacciInitialNumber2;
                    fibonacciInitialNumber2 = aux;
                    arrayOfNumbersGenerated.Add(fibonacciInitialNumber2);
                    fibonacciSum += fibonacciInitialNumber2;
                }
                this.textBox2.Text = fibonacciSum.ToString();
                foreach (int i in arrayOfNumbersGenerated)
                {
                    sb.Append(i);
                    sb.Append(" ");
                }
                this.textBox3.Text = sb.ToString();
            }
        }

        // Fibonacci szám keresés gomb.
        private void button2_Click(object sender, EventArgs e)
        {
            // Amennyiben a 4. TextBox nem üres és egy szám, akkor a
            // Fibonacci sorozaton belüli szám előfordulásának keresését valósítjuk meg.
            if (this.textBox4.Text != String.Empty)
            {
                int nrToFind;
                if (!int.TryParse(this.textBox4.Text, out nrToFind))
                {
                    MessageBox.Show("A megadott érték nem valid.", "Hibaüzenet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.textBox4.Select();
                    this.textBox4.Focus();
                }
                var fibonacciInitialNumber1 = 0;
                var fibonacciInitialNumber2 = 1;

                if (nrToFind == fibonacciInitialNumber1 || nrToFind == fibonacciInitialNumber2)
                {
                    this.textBox5.Text = "Talált!";
                    return;
                }

                while (nrToFind >= fibonacciInitialNumber2)
                {
                    int aux = fibonacciInitialNumber1 + fibonacciInitialNumber2;
                    fibonacciInitialNumber1 = fibonacciInitialNumber2;
                    fibonacciInitialNumber2 = aux;
                    if (nrToFind == fibonacciInitialNumber2)
                    {
                        this.textBox5.Text = "Talált!";
                        return;
                    }
                }
                this.textBox5.Text = "Nem talált!";
            }
        }
    }
}
