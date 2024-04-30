using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varosok
{
    public partial class Form1 : Form
    {
        public static List<Varos> lista = new List<Varos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void megnyításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuSzures.Enabled = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                var elsosor = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    lista.Add(new Varos(sr.ReadLine()));
                }
                sr.Close();

                foreach (var sor in lista)
                {
                    listBox1.Items.Add(sor.varos);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrszag.Text = lista[listBox1.SelectedIndex].orszag;  
            txtNepesseg.Text = lista[listBox1.SelectedIndex].nepesseg.ToString("#,##0") + " millió";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var legkisebb = (from sor in lista
                                     select sor.varos).Last();
            textBox1.Text = legkisebb.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var legnagyobb = (from sor in lista
                                 select sor.varos).First();
            textBox1.Text = legnagyobb.ToString();
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            /*var novekvo = (
                from sor in lista
                orderby sor.nepesseg
                select sor).Last();*/

            //listBox1.Items = lista.OrderBy(x => x.nepesseg).ToList();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            /*var csokkeno = (
                from sor in lista
                orderby sor.nepesseg
                select sor).Last();*/
        }

        private void mnuSzures_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 szures = new Form2();
            szures.ShowDialog();
            szures.Dispose();
            this.Show();
        }
    }

    public class Varos
    {
        public string helyezes { get; set; }
        public string varos { get; set; }
        public string orszag { get; set; }
        public int nepesseg { get; set; }

        public Varos(string sor)
        {
            string[] s = sor.Split(';');
            helyezes = s[0];
            varos = s[1];
            orszag = s[2];
            nepesseg = int.Parse(s[3]);
        }
    }
}
