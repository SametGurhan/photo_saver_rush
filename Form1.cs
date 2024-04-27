using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class formScSaver : Form
    {

        List<Image> kediImages = new List<Image>();
        List<kalpPict> kediPictures = new List<kalpPict>();
        Random rnd = new Random();



        class kalpPict
        {
            public int PictNum;
            public float X;
            public float Y;
            public float Speed;
        }
        public formScSaver()
        {
            InitializeComponent();
        }

        private void formScSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void formScSaver_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("fotos");
            foreach(string item in images)
            {
                kediImages.Add(new Bitmap(item));

            }
            for (int i=0; i<2000; i++)
            {
                kalpPict mp = new kalpPict();
                mp.PictNum = i%kediImages.Count;
                mp.X = rnd.Next(0,Width);
                mp.Y = rnd.Next(0, Height);
                kediPictures.Add(mp);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
         
        }

        private void formScSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach (kalpPict kp in kediPictures)
            {
                e.Graphics.DrawImage(kediImages[kp.PictNum],kp.X,kp.Y);
                kp.X -=2;
                if (kp.X<-250)
                {
                    kp.X = Width + rnd.Next(20, 100);

                }
            }
        }

        private void formScSaver_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
