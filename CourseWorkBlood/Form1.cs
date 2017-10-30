using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWorkBlood
{
    public partial class Form1 : Form
    {
        /*
         * Конструктор класса
         */
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * Метод нажатия на кнопку ОК
         * Описание: Данный метод проверяет на заполнение всех полей в форме и открывает следующую форму/выводит сообщение об ошибки.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            bool isAnyRadioButtonChecked = false; //Переменная для проверки выбора Radio кнопки (по умолчанию false - невыбранно)
            Int16 goods_id = 0; //Индекс выбранных продуктов - 0 невыбранно
            foreach (RadioButton rdo in groupBox1.Controls.OfType<RadioButton>()) //Цикл по всем Radio кнопкам в GroupBox на форме
            {
                if (rdo.Checked) //Если Radio кнопка выбрана, то запоминаем ее и прерываем цикл, так как Radio кнопка может быть выбрана только одна
                {
                    goods_id = Convert.ToInt16(rdo.Tag); //Запоминаем индекс выбранной радио кнопки (индекс задается в конструкторе в аттрибуте Tag
                    isAnyRadioButtonChecked = true; //Ставим флаг, что кнопка выбрана
                    break; // досрочно прерываем цикл обхода
                }
            }
            if (isAnyRadioButtonChecked && comboBox1.SelectedIndex != -1) // условие: если выбрана Radio кнопка и выбрана группа крови (индекс группы крови в ComboBox не должен быть равен -1), то открываем окно с формой
            {
                Info info = new Info(); //Создаем объект новой формы
                info.goods_id = goods_id; //Передаем индекс выбранных продуктов в новую форму
                info.blood_id = Convert.ToInt16(comboBox1.SelectedIndex); //Передаем выбранную группу крови в новую форму
                this.Hide(); //Скрываем текущую форму
                info.ShowDialog(); //Показываем новую форму
                this.Show(); //Показываем предыдущую форму, если та новая будет закрыта
            }
            else // если условие не выполнилось, то выдаем ошибку
            {
                MessageBox.Show("Заполните все поля!"); //Отображения окна с ошибкой
            }
        }
    }
}
