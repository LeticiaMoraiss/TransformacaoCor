using System;
using System.Windows.Forms;

namespace TransformacaoEspacoCor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Lado Esquerdo da tela -- Conversão de R G B para as demais formas
        private void convertEscalas_Click(object sender, EventArgs e)
        {
            double r, g, b;
            r = Convert.ToDouble(inputR.Text);
            g = Convert.ToDouble(inputG.Text);
            b = Convert.ToDouble(inputB.Text);

            converterEscalaMedia(r, g, b);

            converterEscalaCoeficiente(r, g, b);

            converterXYZ(r, g, b);

            converterHSV(r, g, b);

            converterCMYK(r, g, b);
        }

        public void converterEscalaCoeficiente(double r, double g, double b)
        {
            double escalaCoeficiente;

            escalaCoeficiente = (0.2989 * r) + (0.5870 * g) + (0.1140 * b);

            outputEscalaCoeficiente.Text = Math.Round(escalaCoeficiente, 2).ToString();
        }

        public void converterEscalaMedia(double r, double g, double b)
        {
            double escalaMedia;

            escalaMedia = (r + g + b) / 3;

            outputEscalaMedia.Text = Math.Round(escalaMedia, 2).ToString();
        }

        public void converterXYZ(double r, double g, double b)
        {
            double x, y, z;

            x = (2.3646138 * r) + (-0.8965405 * g) + (-0.4680732 * b);
            y = (-0.5151662 * r) + (1.4264081 * g) + (0.0887581 * b);
            z = (0.0052036 * r) + (-0.0144081 * g) + (1.0092044 * b);

            outputX.Text = Math.Round(x, 2).ToString();
            outputY.Text = Math.Round(y, 2).ToString();
            outputZ.Text = Math.Round(z, 2).ToString();
        }

        public void converterHSV(double r, double g, double b)
        {
            double h = 0, s, v;

            r /= 255;
            g /= 255;
            b /= 255;

            double min = minimo(r, g, b);
            double max = maximo(r, g, b);

            v = max;
            if (max != 0)
            {
                s = (max - min) / max;
            }
            else
            {
                s = 0;
            }

            if ((max == r) && (g >= b))
            {
                h = 60 * ((g - b) / (max - min));
            }
            else if ((max == r) && (g < b))
            {
                h = 60 * ((g - b) / (max - min)) + 360;
            }
            else if (max == g)
            {
                h = 60 * ((b - r) / (max - min)) + 120;
            }
            else if (max == b)
            {
                h = 60 * ((r - g) / (max - min)) + 240;
            }

            s *= 100;
            v *= 100;

            outputH.Text = Math.Round(h, 2).ToString();
            outputS.Text = Math.Round(s, 2).ToString();
            outputV.Text = Math.Round(v, 2).ToString();
        }

        public void converterCMYK(double r, double g, double b)
        {
            double c, m, y, k;

            r /= 255;
            g /= 255;
            b /= 255;

            k = 1 - maximo(r, g, b);
            c = (1 - r - k) / (1 - k);
            m = (1 - g - k) / (1 - k);
            y = (1 - b - k) / (1 - k);

            c *= 100;
            m *= 100;
            y *= 100;
            k *= 100;

            outputC.Text = Math.Round(c, 2).ToString();
            outputM.Text = Math.Round(m, 2).ToString();
            output_Y.Text = Math.Round(y, 2).ToString();
            outputK.Text = Math.Round(k, 2).ToString();
        }

        public double minimo(double r, double g, double b)
        {
            double min = r;
            if (min > g)
            {
                min = g;
            }
            if (min > b)
            {
                min = b;
            }
            return min;
        }

        public double maximo(double r, double g, double b)
        {
            double max = r;
            if (max < g)
            {
                max = g;
            }
            if (max < b)
            {
                max = b;
            }
            return max;
        }

        //Lado Direito da tela -- Conversão de X Y Z para R G B
        private void convertRGB_Click(object sender, EventArgs e)
        {
            double x, y, z;
            x = Convert.ToDouble(inputX.Text);
            y = Convert.ToDouble(inputY.Text);
            z = Convert.ToDouble(inputZ.Text);

            converterRGB(x, y, z);
        }

        public void converterRGB(double x, double y, double z)
        {
            double r, g, b;

            r = (0.4868870 * x) + (0.3062984 * y) + (0.1710347 * z);
            g = (0.1746583 * x) + (0.8247541 * y) + (0.0005877 * z);
            b = (-0.0012563 * x) + (0.0169832 * y) + (0.8094831 * z);

            outputR.Text = Math.Round(r, 2).ToString();
            outputG.Text = Math.Round(g, 2).ToString();
            outputB.Text = Math.Round(b, 2).ToString();
        }
    }
}