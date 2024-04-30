using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varosok
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (var item in Form1.lista)
            {
                if (!comboBox1.Items.Contains(item.orszag))
                {
                    comboBox1.Items.Add(item.orszag);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kereses = (
                    from sor in Form1.lista
                    where sor.orszag == comboBox1.Text
                    select sor.varos
                    );

            richTextBox1.Clear();
            foreach (var item in kereses)
            {
                richTextBox1.Text += item + "\n";
            }
        }

        private void listaMentéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("szures.txt", RichTextBoxStreamType.PlainText);
        }
    }
}
