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
    /// Generates a high-resolution QR code PNG (800x800) at 300 DPI and returns it as a WPF BitmapImage.
    /// Payload is encoded using UTF-8 and only includes the specified reduced fields.
    /// </summary>
    public BitmapImage? GenerateQrCode(Dictionary<string, object> data)
    {
        try
        {
            // Build minimal payload with required keys
            var payloadObj = new Dictionary<string, object>
            {
                { "amount", data.ContainsKey("amount") ? data["amount"] : 0 },
                { "ref", data.ContainsKey("ref") ? data["ref"] : data.GetValueOrDefault("invoiceRef", "") },
                { "cashier", data.ContainsKey("cashier") ? data["cashier"] : data.GetValueOrDefault("cashier", "") },
                { "merchant", data.ContainsKey("merchant") ? data["merchant"] : data.GetValueOrDefault("merchantName", "") },
                { "account", data.ContainsKey("account") ? data["account"] : data.GetValueOrDefault("merchantAccount", "") }
            };

            var jsonString = JsonConvert.SerializeObject(payloadObj);

            using var qrGenerator = new QRCodeGenerator();
            // Use ECC Level M and enforce UTF8
            var qrCodeData = qrGenerator.CreateQrCode(jsonString, QRCodeGenerator.ECCLevel.M, true);

            using var qrCode = new QRCode(qrCodeData);
            // Generate raw bitmap (modules * pixelsPerModule)
            using var rawBitmap = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, true);

            // Add white quiet zone (border) of 40px around raw bitmap, then resize to 800x800
            int targetSize = 800;
            int quietZone = 40;

            // Create bitmap with white background and centered QR with quiet zone
            using var canvas = new Bitmap(targetSize, targetSize);
            canvas.SetResolution(300, 300);
            using (var g = Graphics.FromImage(canvas))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.Clear(System.Drawing.Color.White);

                // compute scaled size for rawBitmap to fit with quiet zone
                int innerSize = targetSize - 2 * quietZone;
                g.DrawImage(rawBitmap, quietZone, quietZone, innerSize, innerSize);
            }

            using var ms = new MemoryStream();
            canvas.Save(ms, ImageFormat.Png);
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

    // Test QR generator with fixed values for readability validation
    public BitmapImage? GenerateTestQr()
    {
        var data = new Dictionary<string, object>
        {
            { "amount", 123.45m },
            { "ref", "TESTREF12345" },
            { "cashier", "TestCashier" },
            { "merchant", "TestMerchant" },
            { "account", "000111222" }
        };

        return GenerateQrCode(new Dictionary<string, object>(data));
    }
}

