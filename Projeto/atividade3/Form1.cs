using System;
using System.Drawing;
using System.Windows.Forms;

namespace atividade3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarImagens();
            TimerRua.Stop();
            TimerAvenida.Stop();
            TimerEmergencia.Stop();
        }

        private void InicializarImagens()
        {
            // Definir todas as imagens como "Apagado" no início
            PictureBox[] semaforos = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            foreach (var semaforo in semaforos)
            {
                semaforo.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                semaforo.SizeMode = PictureBoxSizeMode.StretchImage;
                semaforo.Tag = "Apagado";
            }
        }

        private void InicializarImagensEmergencia()
        {
            // Definir todas as imagens como "Apagado" no início
            PictureBox[] semaforos = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            foreach (var semaforo in semaforos)
            {
                semaforo.Image = Image.FromFile("C:\\Imagens\\Amarelo.bmp");
                semaforo.SizeMode = PictureBoxSizeMode.StretchImage;
                semaforo.Tag = "Amarelo";
            }
        }

        private bool emergenciaAtiva = false;

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Imagens\\Vermelho.bmp");
            pictureBox1.Tag = "Vermelho";

            pictureBox6.Image = Image.FromFile("C:\\Imagens\\Verde.bmp");
            pictureBox6.Tag = "Verde";

            TimerRua.Interval = 3000;
            TimerAvenida.Interval = 2000;
            TimerRua.Start();
            TimerAvenida.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InicializarImagens();
            TimerRua.Stop();
            TimerAvenida.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void TimerRua_Tick(object sender, EventArgs e)
        {
            if (!TimerRua.Enabled) return;

            if (pictureBox1.Tag.ToString() == "Vermelho")
            {
                TimerRua.Stop();
                pictureBox1.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox1.Tag = "Apagado";

                pictureBox3.Image = Image.FromFile("C:\\Imagens\\Verde.bmp");
                pictureBox3.Tag = "Verde";

                TimerRua.Interval = 2000; // verde para o amarelo
                TimerRua.Start();
            }
            else if (pictureBox3.Tag.ToString() == "Verde")
            {
                TimerRua.Stop();
                pictureBox3.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox3.Tag = "Apagado";

                pictureBox2.Image = Image.FromFile("C:\\Imagens\\Amarelo.bmp");
                pictureBox2.Tag = "Amarelo";

                TimerRua.Interval = 1000; // amarelo para o vermelho
                TimerRua.Start();
            }
            else if (pictureBox2.Tag.ToString() == "Amarelo")
            {
                TimerRua.Stop();
                pictureBox2.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox2.Tag = "Apagado";

                pictureBox1.Image = Image.FromFile("C:\\Imagens\\Vermelho.bmp");
                pictureBox1.Tag = "Vermelho";

                TimerRua.Interval = 3000; // vermelho para o verde
                TimerRua.Start();
            }
        }

        private void TimerAvenida_Tick(object sender, EventArgs e)
        {
            if (!TimerAvenida.Enabled) return;

            if (pictureBox6.Tag.ToString() == "Verde")
            {
                TimerAvenida.Stop();
                pictureBox6.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox6.Tag = "Apagado";

                pictureBox5.Image = Image.FromFile("C:\\Imagens\\Amarelo.bmp");
                pictureBox5.Tag = "Amarelo";

                TimerAvenida.Interval = 1000; // amarelo para o vermelho
                TimerAvenida.Start();
            }
            else if (pictureBox5.Tag.ToString() == "Amarelo")
            {
                TimerAvenida.Stop();
                pictureBox5.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox5.Tag = "Apagado";

                pictureBox4.Image = Image.FromFile("C:\\Imagens\\Vermelho.bmp");
                pictureBox4.Tag = "Vermelho";

                TimerAvenida.Interval = 3000; // vermelho para o verde
                TimerAvenida.Start();
            }
            else if (pictureBox4.Tag.ToString() == "Vermelho")
            {
                TimerAvenida.Stop();
                pictureBox4.Image = Image.FromFile("C:\\Imagens\\Apagado.bmp");
                pictureBox4.Tag = "Apagado";

                pictureBox6.Image = Image.FromFile("C:\\Imagens\\Verde.bmp");
                pictureBox6.Tag = "Verde";

                TimerAvenida.Interval = 2000; // verde para o amarelo
                TimerAvenida.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!emergenciaAtiva)
            {
                emergenciaAtiva = true;
                TimerRua.Stop();
                TimerAvenida.Stop();
                TimerEmergencia.Start();
            }
            else
            {
                emergenciaAtiva = false;
                TimerEmergencia.Stop();
                InicializarImagens(); // Voltar ao normal
                TimerRua.Start();
                TimerAvenida.Start();
            }
        }


        private void TimerEmergencia_Tick(object sender, EventArgs e)
        {
            TimerRua.Stop();
            TimerAvenida.Stop();
            InicializarImagensEmergencia();
        }
    }
}
