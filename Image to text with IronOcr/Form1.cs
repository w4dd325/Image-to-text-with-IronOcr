using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace Image_to_text_with_IronOcr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //www.c-sharpcorner.com/article/ocr-using-tesseract-in-C-Sharp/
        }

        public void imageSelect()
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            // open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                //image file path  
                textBox1.Text = open.FileName;
            }
        }

        public void OCR()
        {
            var Ocr = new IronTesseract(); // nothing to configure
            Ocr.Language = OcrLanguage.English;
            Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            using (var Input = new OcrInput())
            {
                //Input.AddImage(@"OCR_Test.png");
                //Input.AddImage("C:/Users/James/Desktop/e35yh53.png");
                var a = textBox1.Text;
                Input.AddImage(a);
                var Result = Ocr.Read(Input);
                //Console.WriteLine(Result.Text);
                //Debug.WriteLine(Result.Text);
                textBox2.Text = Result.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageSelect();
            OCR();
        }
    }
}
