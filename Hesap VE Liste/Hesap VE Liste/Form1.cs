using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hesap_VE_Liste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void islem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen tüm sayıları girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Lütfen tüm sayıları girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(textBox3.Text))
                    {
                        MessageBox.Show("Lütfen tüm sayıları girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        {
                            int sayi1 = int.Parse(textBox1.Text);
                            int sayi2 = int.Parse(textBox2.Text);
                            int sayi3 = int.Parse(textBox3.Text);
                            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                            {
                                MessageBox.Show("Lütfen tüm sayıları girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                int sayi4 = sayi3 * (sayi1 + sayi2);
                                label1.Text = sayi4.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void zigzag_Click(object sender, EventArgs e)
        {   //Form içerisinde görünümü değiştirilebilir
            listBox1.Items.Clear();
            for (int i = 1; i <= 200; i++)
            {
                string item = i.ToString();
                if (i % 3 == 0) item = "zig";
                if (i % 5 == 0) item = "zag";
                if (i % 15 == 0 && i < 100) item = "zigzag";
                if (i % 15 == 0 && i >= 100) item = "zagzig";
                listBox1.Items.Add(item);
            }
        }

        private void Çarpım_Click(object sender, EventArgs e)
        {   //Farklı bir değerde çıkartılabilirdi
            groupBox1.Controls.Clear();
            int n = int.Parse(textBox5.Text);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Label label = new Label();
                    label.Text = (i * j).ToString();
                    label.Location = new Point((j - 1) * 20, (i - 1) * 20);
                    label.Size = new Size(20, 20);
                    groupBox1.Controls.Add(label);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {  //Dosya tipi değişkeni arttırılabilir
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin dosyaları|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                List<int> numbers = new List<int>();

                try
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] words = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string word in words)
                            {
                                int number;
                                if (int.TryParse(word, out number))
                                {
                                    numbers.Add(number);
                                }
                            }
                        }
                    }

                    numbers.Sort();
                    numbers.Reverse();

                    MessageBox.Show(string.Join(Environment.NewLine, numbers));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            //Görsel geliştirilebilir bunun dışında kod şuan kısa gözüktü yeterince
            int n = int.Parse(textBox6.Text);
            //geçiçi değer ve toplanacak değerler eklenir
            int fib1 = 0, fib2 = 1, fibN = 0;
            for (int i = 2; i <= (n - 1); i++)//0 baz alındığı için n-1
            {
                fibN = fib1 + fib2;
                fib1 = fib2;
                fib2 = fibN;
            }

            MessageBox.Show($"Fibonacci sırasında {n}. sayı: {fibN}");
        }
    }
}
