// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using System.Reflection.Metadata;

//Load an existing PDF document.
FileStream docStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream, "ownerPassword256");
//Change the user password.
loadedDocument.Security.UserPassword = "NewUserPassword";
//Change the owner password.
loadedDocument.Security.OwnerPassword = "NewOwnerPassword";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);
