using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ATLTravelPortal.Utility
{
    public class LogoResizer
    {
        /// <summary>
        /// Gets an image quality
        /// </summary>
        public long ImageQuality
        {
            get
            {
                return 100L;
            }
        }

        /// <summary>
        /// Validates input picture dimensions
        /// </summary>
        /// <param name="pictureBinary">Picture binary</param>
        /// <param name="mimeType">MIME type</param>
        /// <returns>Picture binary or throws an exception</returns>
        public virtual byte[] ValidatePicture(byte[] pictureBinary, string mimeType)
        {
            using (var stream = new MemoryStream(pictureBinary))
            {
                var b = new Bitmap(stream);

                var newSize = new Size(166, 63);
                var newBitMap = new Bitmap(newSize.Width, newSize.Height);
                var g = Graphics.FromImage(newBitMap);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(b, 0, 0, newSize.Width, newSize.Height);

                var m = new MemoryStream();
                var ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, this.ImageQuality);
                ImageCodecInfo ici = GetImageCodecInfoFromMimeType(mimeType);
                if (ici == null)
                    ici = GetImageCodecInfoFromMimeType("image/jpeg");
                newBitMap.Save(m, ici, ep);
                newBitMap.Dispose();
                b.Dispose();
                return m.GetBuffer();
            }
        }

        /// <summary>
        /// Returns the first ImageCodecInfo instance with the specified mime type.
        /// </summary>
        /// <param name="mimeType">Mime type</param>
        /// <returns>ImageCodecInfo</returns>
        private ImageCodecInfo GetImageCodecInfoFromMimeType(string mimeType)
        {
            var info = ImageCodecInfo.GetImageEncoders();
            foreach (var ici in info)
                if (ici.MimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase))
                    return ici;
            return null;
        }
    }
}