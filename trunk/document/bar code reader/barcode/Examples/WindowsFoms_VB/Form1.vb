Imports Lesnikowski.Barcode

Public Class Form1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim b As BaseBarcode
        b = BarcodeFactory.GetBarcode(Symbology.I2of5)

        b.Number = "123456789"
        b.ChecksumAdd = True
        b.Rotation = RotationType.Degrees90
        pictureBox1.Image = b.Render()
    End Sub

    Private Sub printToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printToolStripMenuItem.Click
        If printDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            printDialog1.Document.Print()
        End If
    End Sub

    Private Sub printPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printPreviewToolStripMenuItem.Click
        printPreviewDialog1.ShowDialog()
    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDocument1.PrintPage
        barcodeControl1.Render(e.Graphics, 100, 100)

        Dim b As BaseBarcode
        b = BarcodeFactory.GetBarcode(Symbology.I2of5)

        b.Number = "123456789"
        b.ChecksumAdd = True
        b.Rotation = RotationType.Degrees90
        '92 dots per inch (screen resolution) * 1.5 cm /2.54 inch
        b.Height = 92.0F * 1.5 / 2.54            '1.5 cm
        b.NarrowBarWidth = 92.0F * 0.05 / 2.54   '0.5 mm
        b.Render(e.Graphics, 300, 100)
    End Sub
End Class
