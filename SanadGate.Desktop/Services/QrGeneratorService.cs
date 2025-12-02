using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using QRCoder;
using Newtonsoft.Json;

namespace SanadGate.Desktop.Services;

public class QrGeneratorService
{
    public BitmapImage? GenerateQrCode(Dictionary<string, object> data)
    {
        try
        {
            var jsonString = JsonConvert.SerializeObject(data);
            
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(jsonString, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(qrCodeImage);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();

            return bitmap;
        }
        catch
        {
            return null;
        }
    }
}
