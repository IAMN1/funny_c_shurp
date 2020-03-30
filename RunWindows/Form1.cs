using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RanWindows
{
    public partial class Form1 : Form
    {

        Point tmp_location;
        int _w = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
        int _h = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Переводим кординаты Х и У в строки и записываем в поля ввода
            textBox1.Text = e.X.ToString();
            textBox2.Text = e.Y.ToString();

            if(e.X > 155 && e.X < 269 && e.Y > 157 && e.Y < 208)
            {
                //Запоминаем текущее положение окна
                tmp_location = this.Location;

                //Генерирум новое положение окна
                tmp_location.X += rnd.Next(-100, 100);
                tmp_location.Y += rnd.Next(-100, 100);

                //если окно вылезло за пределы экрана по одной из осей
                if(tmp_location.X < 0 || tmp_location.X > (_w - this.Width / 2) ||
                    tmp_location.Y < 0 || tmp_location.Y > (_h - this.Height / 2))
                {
                    //Новыми координатами станет центр окна
                    tmp_location.X = _w / 2;
                    tmp_location.Y = _h / 2;
                }
                //Обновляем положение окна на новое сгенерированное
                this.Location = tmp_location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы усердны!!!");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Вывести сообщение, с текстом "Мы не сомневались в вешем безразличии"
            // второй параметр - заголовок окна сообщения "Внимание" 
            // MessageBoxButtons.OK - тип размещаемой кнопки на форме сообщения 
            // MessageBoxIcon.Information - тип сообщения - будет иметь иконку 
            //"информация" и соответствующий звуковой сигнал
            MessageBox.Show("Мы не сомневались в вешем безразличии", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
