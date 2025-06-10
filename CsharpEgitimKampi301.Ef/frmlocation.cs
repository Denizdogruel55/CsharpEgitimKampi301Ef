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
    public partial class frmlocation : Form
    {
        public frmlocation()
        {
            InitializeComponent();
        }
        EgitimkampiEfDBEntities1 db = new EgitimkampiEfDBEntities1();
        private void button3_Click(object sender, EventArgs e)
        {
            var values = db.TBLLocation.ToList();
            dataGridView1.DataSource = values;

        }

        private void frmlocation_Load(object sender, EventArgs e)
        {
            var values = db.TBLGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();







            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TBLLocation location = new TBLLocation();
            location.LocationCity = txtCity.Text;
          
            location.LocationCountry = txtCountry.Text;
            location.LocationPrice = decimal.Parse(txtprice.Text);
            location.DayNight = txtDayNight.Text;
            location.LocationCapasity = byte.Parse(nmrcp.Value.ToString());
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.TBLLocation.Add(location);
            db.SaveChanges();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var values = db.TBLLocation.Find(id);
            db.TBLLocation.Remove(values);
            db.SaveChanges();


        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var updatevalue = db.TBLLocation.Find(id);


            updatevalue.LocationPrice = decimal.Parse(txtprice.Text);
            updatevalue.LocationCity = txtCity.Text;
            updatevalue.LocationCountry = txtCountry.Text;
            updatevalue.LocationCapasity = byte.Parse(nmrcp.Value.ToString());
            updatevalue.DayNight = txtDayNight.Text;
            updatevalue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi Başarili");




        }
    }
}
