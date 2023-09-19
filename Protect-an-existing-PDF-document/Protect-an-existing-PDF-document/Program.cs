// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VFhhQlVEfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Qd0FjUH5fdX1RR2ZZ");

//Load the PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//PDF document security.
PdfSecurity security = document.Security;
//Specifies encryption key size, algorithm and permission. 
security.KeySize = PdfEncryptionKeySize.Key256Bit;
security.Algorithm = PdfEncryptionAlgorithm.AES;
//Provide owner and user password.
security.OwnerPassword = "ownerPassword256";
security.UserPassword = "userPassword256";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);
