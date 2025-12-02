using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using QRCoder;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;

namespace SanadGate.Desktop.Services;

public class QrGeneratorService
{
    /// <summary>
    /// Generates a high-resolution QR code PNG (700x700) at 300 DPI and returns it as a WPF BitmapImage.
    /// Payload is encoded using UTF-8.
    /// </summary>
    public BitmapImage? GenerateQrCode(Dictionary<string, object> data)
    {
        try
        {
            var jsonString = JsonConvert.SerializeObject(data);

            using var qrGenerator = new QRCodeGenerator();
            // force UTF8 encoding when possible
            var qrCodeData = qrGenerator.CreateQrCode(jsonString, QRCodeGenerator.ECCLevel.Q, true);

            using var qrCode = new QRCode(qrCodeData);
            // initial module size; we'll resize to exact 700px afterwards
            using var rawBitmap = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, true);

            // Resize to 700x700 with high quality and set DPI to 300
            using var resized = new Bitmap(700, 700);
            resized.SetResolution(300, 300);
            using (var g = Graphics.FromImage(resized))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.Clear(System.Drawing.Color.White);
                g.DrawImage(rawBitmap, 0, 0, 700, 700);
            }

            using var ms = new MemoryStream();
            resized.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = new MemoryStream(ms.ToArray());
            bitmap.EndInit();
            bitmap.Freeze();

            return bitmap;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"QR generation error: {ex.Message}");
            return null;
        }
    }
}
