using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kuyucu7._10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labell_Click(object sender, EventArgs e)
        {

        }            
            void listele()

        {
            Tarsus2026Entities db = new Tarsus2026Entities();
            dataGridView1.DataSource = db.Students.ToList();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Students std = new Students
            {
                Name = textBox1.Text,
                SurName = textBox2.Text,
                Email = textBox3.Text,

            };
            Tarsus2026Entities db = new Tarsus2026Entities();
            db.Students.Add(std);
            db.SaveChanges();
            listele();
        }
        int secilenid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tarsus2026Entities db = new Tarsus2026Entities();
            db.Students.Remove(db.Students.Find(secilenid));
            db.SaveChanges();  
            listele();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tarsus2026Entities db = new Tarsus2026Entities();
            var guncelle = db.Students.Find(secilenid);

            guncelle.Name = textBox1.Text; 
            guncelle.SurName = textBox2.Text;   
            guncelle.Email = textBox3.Text; 


            db.SaveChanges();   
            listele();  
        }
    }
}
