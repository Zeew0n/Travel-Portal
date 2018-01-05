using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Drawing.Imaging;

namespace ATLTravelPortal.Helpers
{
    public class ImageThumbnail
    {
        public static bool ChangeHeightWidth(string location, System.Drawing.Image imSourceImage, int iWidth, int iHeight)
        {
            try
            {
                System.Drawing.Bitmap oImage = new System.Drawing.Bitmap(imSourceImage);
                oImage = (System.Drawing.Bitmap)oImage.GetThumbnailImage(iWidth, iHeight, null, IntPtr.Zero);
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                string sFilePath = location.Replace("_sm", "_th");
                oImage.Save(sFilePath, jpgEncoder, myEncoderParameters);
                imSourceImage = oImage;
                return true;
            }
            catch
            {
                throw;
            }
            return false;
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }
        //public static string Image(this HtmlHelper helper,
        //                        string url,
        //                        string altText,
        //                        object htmlAttributes)
        //{
        //    TagBuilder builder = new TagBuilder("img");
        //    builder.Attributes.Add("src", url);
        //    builder.Attributes.Add("alt", altText);
        //    builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
        //    return builder.ToString(TagRenderMode.SelfClosing);
        //}

    }
}