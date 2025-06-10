using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEgitimKampi301.Ef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimkampiEfDBEntities1 db = new EgitimkampiEfDBEntities1();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TBLGuide.ToList();
            dataGridView1.DataSource= values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TBLGuide guide=new TBLGuide();
            
            guide.GuideName = txtad.Text;
            guide.GuideSurname = txtsurname.Text;
            db.TBLGuide.Add(guide);
            db.SaveChanges();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var removevalues = db.TBLGuide.Find(id);
            db.TBLGuide.Remove(removevalues);

            db.SaveChanges();
            var values = db.TBLGuide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtid.Text);
            var value=db.TBLGuide.Find(id);
            value.GuideName = txtad.Text;
            value.GuideSurname= txtsurname.Text;
            db.SaveChanges();
            var values = db.TBLGuide.ToList();
            dataGridView1.DataSource = values;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtid.Text);
            var values=db.TBLGuide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
