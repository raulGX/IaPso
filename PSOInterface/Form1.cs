using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PSO;

namespace PSOInterface
{
    public partial class Form1 : Form
    {
        List<TextBox> textBoxList = new List<TextBox>();
        List<Double> paramList = new List<Double>();
        Parametrii param = new Parametrii();
        ProblemaDeBaza p;
        Boolean validInput = false;
        public Form1()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);
            textBoxList.Add(textBox6);
            textBoxList.Add(textBox7);
            textBoxList.Add(textBox8);
            textBoxList.Add(textBox9);

            paramList.Add(param.W);
            paramList.Add(param.C1);
            paramList.Add(param.C2);
            paramList.Add(param.DimensiuneProblema);
            paramList.Add(param.Min);
            paramList.Add(param.Max);
            paramList.Add(param.NumarIteratii);
            paramList.Add(param.NumarParticule);
            paramList.Add(param.VitezaMaxima);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selectati o functie !");
                return;
            }
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Ackley":
                    for(var i = 0; i < textBoxList.Count; ++i)
                    {
                        validInput = true;
                        if (textBoxList[i].Text.Length == 0)
                        {
                            MessageBox.Show("Introduceti valori valide !");
                            validInput = false;
                            break;
                        }
                    }

                    if(validInput == true)
                    {
                        double doubleValue;
                        var param = new Parametrii();
                        for(var i = 0; i<textBoxList.Count; ++i)
                        {
                            if (Double.TryParse(textBoxList[i].Text, out doubleValue))
                            {
                                paramList[i] = doubleValue;
                            }
                            else
                            {
                                MessageBox.Show(textBoxList[i].Text + " nu este un numar real !");
                                validInput = false;
                                break;
                            }
                        }
                        if(validInput == true)
                        {
                            p = new Ackley();
                            param.W = paramList[0];
                            param.C1 = paramList[1];
                            param.C2 = paramList[2];
                            param.DimensiuneProblema = Convert.ToInt32(paramList[3]);
                            param.Min = paramList[4];
                            param.Max = paramList[5];
                            param.NumarIteratii = Convert.ToInt32(paramList[6]);
                            param.NumarParticule = Convert.ToInt32(paramList[7]);
                            param.VitezaMaxima = paramList[8];
                            var rez = p.Rezolva(param);
                            richTextBox1.Text = "Cost: " + rez.Cost + '\n';
                            foreach (var weight in rez.Pozitie)
                                richTextBox1.Text += weight + "  ";
                        }

                    }
                    break;
                case "Griewank":
                    for (var i = 0; i < textBoxList.Count; ++i)
                    {
                        validInput = true;
                        if (textBoxList[i].Text.Length == 0)
                        {
                            MessageBox.Show("Introduceti valori valide !");
                            validInput = false;
                            break;
                        }
                    }

                    if (validInput == true)
                    {
                        double doubleValue;
                        var param = new Parametrii();
                        for (var i = 0; i < textBoxList.Count; ++i)
                        {
                            if (Double.TryParse(textBoxList[i].Text, out doubleValue))
                            {
                                paramList[i] = doubleValue;
                            }
                            else
                            {
                                MessageBox.Show(textBoxList[i].Text + " nu este un numar real !");
                                validInput = false;
                                break;
                            }
                        }
                        if (validInput == true)
                        {
                            p = new Griewank();
                            param.W = paramList[0];
                            param.C1 = paramList[1];
                            param.C2 = paramList[2];
                            param.DimensiuneProblema = Convert.ToInt32(paramList[3]);
                            param.Min = paramList[4];
                            param.Max = paramList[5];
                            param.NumarIteratii = Convert.ToInt32(paramList[6]);
                            param.NumarParticule = Convert.ToInt32(paramList[7]);
                            param.VitezaMaxima = paramList[8];
                            var rez = p.Rezolva(param);
                            richTextBox1.Text = "Cost: " + rez.Cost + '\n';
                            foreach (var weight in rez.Pozitie)
                                richTextBox1.Text += weight + "  ";
                        }

                    }
                    break;
                case "Rastrigin":
                    for (var i = 0; i < textBoxList.Count; ++i)
                    {
                        validInput = true;
                        if (textBoxList[i].Text.Length == 0)
                        {
                            MessageBox.Show("Introduceti valori valide !");
                            validInput = false;
                            break;
                        }
                    }

                    if (validInput == true)
                    {
                        double doubleValue;
                        var param = new Parametrii();
                        for (var i = 0; i < textBoxList.Count; ++i)
                        {
                            if (Double.TryParse(textBoxList[i].Text, out doubleValue))
                            {
                                paramList[i] = doubleValue;
                            }
                            else
                            {
                                MessageBox.Show(textBoxList[i].Text + " nu este un numar real !");
                                validInput = false;
                                break;
                            }
                        }
                        if (validInput == true)
                        {
                            p = new Rastrigin();
                            param.W = paramList[0];
                            param.C1 = paramList[1];
                            param.C2 = paramList[2];
                            param.DimensiuneProblema = Convert.ToInt32(paramList[3]);
                            param.Min = paramList[4];
                            param.Max = paramList[5];
                            param.NumarIteratii = Convert.ToInt32(paramList[6]);
                            param.NumarParticule = Convert.ToInt32(paramList[7]);
                            param.VitezaMaxima = paramList[8];
                            var rez = p.Rezolva(param);
                            richTextBox1.Text = "Cost: " + rez.Cost + '\n';
                            foreach (var weight in rez.Pozitie)
                                richTextBox1.Text += weight + "  ";
                        }

                    }
                    break;
                case "Rosenbrock":
                    for (var i = 0; i < textBoxList.Count; ++i)
                    {
                        validInput = true;
                        if (textBoxList[i].Text.Length == 0)
                        {
                            MessageBox.Show("Introduceti valori valide !");
                            validInput = false;
                            break;
                        }
                    }

                    if (validInput == true)
                    {
                        double doubleValue;
                        var param = new Parametrii();
                        for (var i = 0; i < textBoxList.Count; ++i)
                        {
                            if (Double.TryParse(textBoxList[i].Text, out doubleValue))
                            {
                                paramList[i] = doubleValue;
                            }
                            else
                            {
                                MessageBox.Show(textBoxList[i].Text + " nu este un numar real !");
                                validInput = false;
                                break;
                            }
                        }
                        if (validInput == true)
                        {
                            p = new Rosenbrock();
                            param.W = paramList[0];
                            param.C1 = paramList[1];
                            param.C2 = paramList[2];
                            param.DimensiuneProblema = Convert.ToInt32(paramList[3]);
                            param.Min = paramList[4];
                            param.Max = paramList[5];
                            param.NumarIteratii = Convert.ToInt32(paramList[6]);
                            param.NumarParticule = Convert.ToInt32(paramList[7]);
                            param.VitezaMaxima = paramList[8];
                            var rez = p.Rezolva(param);
                            richTextBox1.Text = "Cost: " + rez.Cost + '\n';
                            foreach (var weight in rez.Pozitie)
                                richTextBox1.Text += weight + "  ";
                        }

                    }
                    break;
            }
        }

    }
}