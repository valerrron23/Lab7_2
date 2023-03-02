using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lst.Items.Add(txt.Text);
            txt.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text; // путь к файлу
            if (File.Exists(fileName))
            {
                File.Delete(fileName); // если файл существует - удаляем его
            }
            using (FileStream fs = File.Create(fileName, 1024)) // класс для работы с файлами
            // класс для работы с данными файла в двоичном виде
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                for (var i = 0; i < lst.Items.Count; i++) // пока не конец списка
                {
                    bw.Write(lst.Items[i].ToString()); // записываем в файл каждый пункт
                }
                bw.Close();
                fs.Close();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text;
            lstFromfile.Items.Clear();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // метод PeekChar() возвращает следующий прочитанный символ
                // если символов нет -возвращается - 1
                while (br.PeekChar() != -1)
                {
                    // добавляем в список очередную прочитанную строку
                    lstFromfile.Items.Add(br.ReadString());
                }
                br.Close();
                fs.Close();
            }
        }
    }
}
