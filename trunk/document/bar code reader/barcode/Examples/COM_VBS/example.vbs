Dim bf
Dim b

Set bf = CreateObject("Lesnikowski.Barcode.BarcodeFactory")
Set b = bf.CreateBarcode(4)			'=Code39. Check Symbology enum for other values.

' Set some barcode properites.
b.FontStyle = 1					'=Bold. Check FontStyleType enum for other values. 
b.Number = "12345"
b.Rotation = 1					'=Degrees90. Check RotationType enum for other values. 

' Save barcode image to file as PNG.
b.Save "c:\vbs.png", 2				'=Png. Check ImageType enum for other values.

MsgBox "Barcode saved to c:\vbs.png", , "Information"