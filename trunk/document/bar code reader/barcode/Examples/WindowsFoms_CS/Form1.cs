using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Lesnikowski.Barcode;

namespace WindowsForms_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseBarcode b = BarcodeFactory.GetBarcode(Symbology.I2of5);
            b.Number = "123456789";
            b.ChecksumAdd = true;
            b.Rotation = RotationType.Degrees90;
            pictureBox1.Image = b.Render();
        }

        #region Print

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.barcodeControl1.Render(e.Graphics, 100, 100);

            BaseBarcode b = BarcodeFactory.GetBarcode(Symbology.I2of5);
            b.Number = "123456789";
            b.ChecksumAdd = true;
            b.Rotation = RotationType.Degrees90;

            // 92 dots per inch (screen resolution) * 1.5 cm /2.54 inch
            b.Height = (int)(92.0F * 1.5 / 2.54);            // 1.5 cm
            b.NarrowBarWidth = (int)(92.0F * 0.05 / 2.54);   // 0.5 mm
            b.Render(e.Graphics, 300, 100);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDialog1.Document.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        #endregion

    };
}