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
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }
        EgitimkampiEfDBEntities1 db = new EgitimkampiEfDBEntities1();
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            lblCount.Text = db.TBLLocation.Count().ToString();
            lblCap.Text = db.TBLLocation.Sum(x => x.LocationCapasity).ToString();
            lblRehber.Text = db.TBLGuide.Count().ToString();
            lblavgcap.Text = db.TBLLocation.Average(x => x.LocationCapasity).ToString();
            double average = Convert.ToDouble(db.TBLLocation.Average(x => x.LocationPrice));
            lblortalamatur.Text = average.ToString("0.00");
            int lastCountryId = db.TBLLocation.Max(x => x.LocationId);
            lblsonulke.Text = db.TBLLocation.Where(x => x.LocationId == lastCountryId).Select(x => x.LocationCountry).FirstOrDefault();
            lblkapadokyaCap.Text = db.TBLLocation.Where(x => x.LocationCity == "Kapadokya").Select(x => x.LocationCapasity).FirstOrDefault().ToString();
            lblturkiyeturkapasite.Text = db.TBLLocation.Where(x => x.LocationCountry == "Türkiye").Average(x => x.LocationCapasity).ToString();
            var Guideid = db.TBLLocation.Where(x => x.LocationCity == "Roma").Select(x => x.GuideId).FirstOrDefault();
            lblRomeRehber.Text = db.TBLGuide.Where(x => x.GuideId == Guideid).Select(x => x.GuideName + " " + x.GuideSurname).FirstOrDefault();


            var tur = db.TBLLocation.Max(x => x.LocationCapasity).Value;
            lblenyuksekkapasite.Text = db.TBLLocation.Where(x => x.LocationCapasity == tur).Select(x => x.LocationCountry).FirstOrDefault();

            var enpahalıtur = db.TBLLocation.Max(x => x.LocationPrice);
            lblEnpahalı.Text = db.TBLLocation.Where(x => x.LocationPrice == enpahalıtur).Select(x => x.LocationCountry).FirstOrDefault();
            var aliyildiz=db.TBLGuide.Where(x=>x.GuideName=="Ali" && x.GuideSurname=="Yıldız").Select(x=>x.GuideId).FirstOrDefault();
            lblAliyildiztur.Text=db.TBLLocation.Where(x=>x.GuideId==aliyildiz).Count().ToString();
        }
    }
}
