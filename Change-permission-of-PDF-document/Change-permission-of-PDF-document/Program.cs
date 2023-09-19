// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream, "ownerPassword256");
//Change the permission.
loadedDocument.Security.Permissions = PdfPermissionsFlags.CopyContent | PdfPermissionsFlags.AssembleDocument;

//Save the document into stream
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
//Close the PDF document
loadedDocument.Close(true);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);
