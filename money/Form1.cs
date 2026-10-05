using System;
using System.Windows.Forms;

namespace money
{
    public partial class Form1 : Form
    {
        // Ən böyükdən kiçiyə
        int[] nominallar = { 500, 200, 100, 50, 20, 10, 5, 1 };
        Label[] labellar;
        PictureBox[] sekiller;

        public Form1()
        {
            InitializeComponent();

            // sıra: 500, 200, 100, 50, 20, 10, 5, 1
            labellar = new Label[] { label9, label8, label7, label6, label5, label4, label3, label2 };
            sekiller = new PictureBox[] { pictureBox7, pictureBox8, pictureBox5, pictureBox6,
                                          pictureBox3, pictureBox4, pictureBox2, pictureBox1 };
            Gizlet();
        }

        void Gizlet()
        {
            for (int i = 0; i < nominallar.Length; i++)
            {
                labellar[i].Visible = false;
                sekiller[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gizlet();

            // Xana boşdursa və ya rəqəm deyilsə
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox1.Text.Trim(), out int mebleg))
            {
                errorProvider1.SetError(textBox1, "Məbləğ daxil edin");
                return;
            }

            // Məbləğ daxil edilib, ErrorProvider işini bitirir
            errorProvider1.SetError(textBox1, "");

            // Mənfi və ya sıfır məbləğ
            if (mebleg <= 0)
            {
                MessageBox.Show("Mənfi və ya sıfır məbləğ xırdalanmaz", "Diqqət",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ən böyük nominallarla xırdalama
            for (int i = 0; i < nominallar.Length; i++)
            {
                int say = mebleg / nominallar[i];
                mebleg %= nominallar[i];

                if (say > 0)
                {
                    labellar[i].Text = say + " ədəd";
                    labellar[i].Visible = true;
                    sekiller[i].Visible = true;
                }
            }
        }
    }
}